using System.Collections;
using EasyMobile;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(nameof(WaitForAd));
    }

    private IEnumerator WaitForAd()
    {
        yield return new WaitForSeconds(3);
        Debug.Log(Advertising.IsInitialized());
        Advertising.ShowBannerAd(BannerAdPosition.Bottom);
    }

    public void NextScene()
    {
        Advertising.DestroyBannerAd();
        SceneManager.LoadScene("Gameplay");
    }
}