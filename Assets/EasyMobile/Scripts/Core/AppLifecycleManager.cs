using UnityEngine;
using System.Collections;
using EasyMobile.Internal;

namespace EasyMobile
{
    public class AppLifecycleManager : MonoBehaviour
    {
        public static AppLifecycleManager Instance { get; private set; }

        private static IAppLifecycleHandler sAppLifecycleHandler = GetPlatformAppLifecycleHandler();

        #region MonoBehavior Events

        private void Awake()
        {
            if (Instance != null)
                Destroy(this);
            else
                Instance = this;
        }

        private void OnDestroy()
        {
            if (Instance == this)
                Instance = null;
        }

        private void OnApplicationFocus(bool isFocus)
        {
            sAppLifecycleHandler.OnApplicationFocus(isFocus);
        }

        private void OnApplicationPause(bool isPaused)
        {
            sAppLifecycleHandler.OnApplicationPause(isPaused);
        }

        private void OnApplicationQuit()
        {
            sAppLifecycleHandler.OnApplicationQuit();
        }

        #endregion

        private static IAppLifecycleHandler GetPlatformAppLifecycleHandler()
        {
#if UNITY_EDITOR
            return new DummyAppLifecycleHandler();
#elif UNITY_IOS
            return new DummyAppLifecycleHandler();
#elif UNITY_ANDROID
            return new AndroidAppLifecycleHandler();
#else
            return new DummyAppLifecycleHandler();
#endif
        }
    }
}