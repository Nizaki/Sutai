using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using EasyMobile;

namespace EasyMobile.Demo
{
    public class SharingDemo : MonoBehaviour
    {
        public Image clockRect;
        public Text clockText;

        public InputField twoStepShareMessage;
        public InputField oneStepShareMessage;
        public InputField shareTextMessage;

        // Screenshot names don't need to include the extension (e.g. ".png")
        private string TwoStepScreenshotName = "EM_Screenshot";
        private string OneStepScreenshotName = "EM_OneStepScreenshot";
        private string TwoStepScreenshotPath;
        private string sampleURL = "https://assetstore.unity.com/packages/slug/75476";

        private void Awake()
        {
            // Init EM runtime if needed (useful in case only this scene is built).
            if (!RuntimeManager.IsInitialized())
                RuntimeManager.Init();
        }

        private void OnEnable()
        {
            ColorChooser.colorSelected += ColorChooser_colorSelected;
        }

        private void OnDisable()
        {
            ColorChooser.colorSelected -= ColorChooser_colorSelected;
        }

        private void ColorChooser_colorSelected(Color obj)
        {
            clockRect.color = obj;
        }

        private void Update()
        {
            clockText.text = System.DateTime.Now.ToString("hh:mm:ss");
        }

        public void ShareText()
        {
            if (string.IsNullOrEmpty(shareTextMessage.text))
                NativeUI.Alert("Alert", "Please enter a share message first!");
            else
                Sharing.ShareText(shareTextMessage.text);
        }

        public void ShareURL()
        {
            Sharing.ShareURL(sampleURL);
        }

        public void SaveScreenshot()
        {
            StartCoroutine(CRSaveScreenshot());
        }

        public void ShareScreenshot()
        {
            if (!string.IsNullOrEmpty(TwoStepScreenshotPath))
                Sharing.ShareImage(TwoStepScreenshotPath, twoStepShareMessage.text);
            else
                NativeUI.Alert("Alert", "Please save a screenshot first.");
        }

        public void OneStepSharing()
        {
            StartCoroutine(CROneStepSharing());
        }

        private IEnumerator CRSaveScreenshot()
        {
            yield return new WaitForEndOfFrame();

            TwoStepScreenshotPath = Sharing.SaveScreenshot(TwoStepScreenshotName);

            NativeUI.Alert("Alert", "A new screenshot was saved at " + TwoStepScreenshotPath);
        }

        private IEnumerator CROneStepSharing()
        {
            yield return new WaitForEndOfFrame();

            Sharing.ShareScreenshot(OneStepScreenshotName, oneStepShareMessage.text);
        }
    }
}