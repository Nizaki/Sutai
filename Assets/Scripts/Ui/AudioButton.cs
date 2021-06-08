using TMPro;
using UnityEngine;

public class AudioButton : MonoBehaviour
{
    private int i;

    private TextMeshProUGUI text;

    // Start is called before the first frame update
    private void Start()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
        i = PlayerPrefs.GetInt("audio", 1);
        AudioListener.volume = i;
        text.text = "Audio:" + (i == 1 ? "on" : "off");
    }

    public void Toggle()
    {
        i = i == 1 ? 0 : 1;
        PlayerPrefs.SetInt("audio", i);
        PlayerPrefs.Save();
        AudioListener.volume = i;

        text.text = "Audio:" + (i == 1 ? "on" : "off");
    }
}