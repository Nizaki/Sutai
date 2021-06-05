using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using ThreeDISevenZeroR.UnityGifDecoder;
using UnityEngine;

namespace EasyMobile
{
    public class EM_3DI70R_GIF
    {
        public class DecodeRequest
        {
            public event Action Completed = delegate { };

            private bool requestLaunched = false;

            private string error = null;
            private AnimatedClip animatedClip = null;

            private bool isCompleted;

            public bool IsCompleted
            {
                get => isCompleted;
                private set
                {
                    isCompleted = value;
                    if (isCompleted) Completed.Invoke();
                }
            }

            public string Error => error;
            public bool HasError => !string.IsNullOrEmpty(error);
            public AnimatedClip AnimatedClip => animatedClip;

            private readonly string filePath;
            public int frameToRead = 0;
            public System.Threading.ThreadPriority threadPriority = System.Threading.ThreadPriority.Normal;

            private struct FrameData
            {
                public Color32[] colors;
                public float delay;
            }

            private struct DecodeProcParams
            {
                public MainThreadRunner runner;
                public string filePath;
                public int frameToRead;
            }

            public DecodeRequest(string filePath)
            {
                this.filePath = filePath;
            }

            public void Request()
            {
                if (requestLaunched) return;
                requestLaunched = true;
                var runner = new GameObject("GIF decode runner")
                    .AddComponent<MainThreadRunner>();
                runner.gameObject.hideFlags = HideFlags.HideInHierarchy;

                var t = new Thread(DecodeProc);
                t.Priority = threadPriority;

                t.Start(new DecodeProcParams()
                {
                    filePath = filePath,
                    runner = runner,
                    frameToRead = frameToRead
                });
            }

            private void DecodeProc(object param)
            {
                var request = (DecodeProcParams) param;
                var frames = new List<FrameData>();
                var width = 0;
                var height = 0;

                var gifStream = new GifStream(request.filePath);
                var readFrame = 0;
                while (gifStream.HasMoreData)
                {
                    if (readFrame >= request.frameToRead && request.frameToRead > 0) break;
                    switch (gifStream.CurrentToken)
                    {
                        case GifStream.Token.Image:
                            var image = gifStream.ReadImage();
                            width = gifStream.Header.width;
                            height = gifStream.Header.height;
                            var copiedColors = new Color32[image.colors.Length];
                            image.colors.CopyTo(copiedColors, 0);
                            frames.Add(new FrameData()
                            {
                                colors = copiedColors,
                                delay = image.DelaySeconds
                            });
                            readFrame++;
                            break;
                        default:
                            gifStream.SkipToken();
                            break;
                    }
                }

                gifStream.Dispose();

                request.runner.RunInMainThread(() =>
                {
                    var textures = new Texture2D[frames.Count];
                    var fps = 2;
                    float totalTime = 0;
                    for (var i = 0; i < frames.Count; i++)
                    {
                        textures[i] = new Texture2D(width, height, TextureFormat.ARGB32, false, false);
                        textures[i].name = i.ToString();
                        textures[i].SetPixels32(frames[i].colors);
                        textures[i].Apply();
                        totalTime += frames[i].delay;
                        fps = Mathf.RoundToInt(frames.Count / totalTime);
                    }

                    animatedClip = new AnimatedClip(width, height, fps, textures);
                    IsCompleted = true;
                    request.runner.DestroySelf();
                });
            }

            private class MainThreadRunner : MonoBehaviour
            {
                private Queue<Action> callbackQueue = new Queue<Action>();
                private object _queueLock = 0;

                private void Awake()
                {
                    StartCoroutine(QueueWatchCR());
                }

                private IEnumerator QueueWatchCR()
                {
                    while (true)
                    {
                        ProccessRequestQueue();
                        yield return null;
                    }
                }

                private void ProccessRequestQueue()
                {
                    lock (_queueLock)
                    {
                        while (callbackQueue.Count > 0)
                        {
                            var callback = callbackQueue.Dequeue();
                            if (callback != null)
                                callback();
                        }
                    }
                }

                public void RunInMainThread(Action callback)
                {
                    lock (_queueLock)
                    {
                        callbackQueue.Enqueue(callback);
                    }
                }

                public void DestroySelf()
                {
                    RunInMainThread(() => DestroyImmediate(gameObject));
                }
            }
        }
    }
}