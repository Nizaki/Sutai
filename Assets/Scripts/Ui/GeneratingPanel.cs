using System.Collections;
using TMPro;
using UnityEngine;

public class GeneratingPanel : MonoBehaviour
{
    private TextMeshProUGUI text;

    // Start is called before the first frame update
    private void Start()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
        StartCoroutine(nameof(UpdateText));
    }

    private IEnumerator UpdateText()
    {
        yield return new WaitForSeconds(2);
        text.text = "Generate Complete !";
        yield return new WaitForSeconds(1);
        text.text = "Game about to start";
        yield return new WaitForSeconds(0.3f);
        gameObject.SetActive(false);
    }
}