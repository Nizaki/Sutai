using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using EasyMobile.Internal;

namespace EasyMobile.Demo
{
    public class DemoHomeController : MonoBehaviour
    {
        [Header("Object References")] public Text installationTime;

        private void Awake()
        {
            // Initialize EM runtime.
            if (!RuntimeManager.IsInitialized())
                RuntimeManager.Init();
        }

        private void Start()
        {
            var installTime = RuntimeHelper.GetAppInstallationTime();
            installationTime.text = "Install Date: " + installTime.ToShortDateString() + " " +
                                    installTime.ToShortTimeString();
        }

        private void Update()
        {
#if UNITY_ANDROID
            if (Input.GetKeyUp(KeyCode.Escape))
            {
                // Ask if user wants to exit
                var alert = NativeUI.ShowTwoButtonAlert("Exit App",
                    "Do you want to exit?",
                    "Yes",
                    "No");

                if (alert != null)
                    alert.OnComplete += delegate(int button)
                    {
                        if (button == 0)
                            Application.Quit();
                    };
            }

#endif
        }

        public void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}