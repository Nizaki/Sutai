using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace EasyMobile.Demo
{
    [AddComponentMenu("")]
    [RequireComponent(typeof(Text))]
    public class DigitalClock : MonoBehaviour
    {
        private Text clockText;

        // Use this for initialization
        private void Start()
        {
            clockText = GetComponent<Text>();
        }

        // Update is called once per frame
        private void Update()
        {
            clockText.text = System.DateTime.Now.ToString("hh:mm:ss");
        }
    }
}