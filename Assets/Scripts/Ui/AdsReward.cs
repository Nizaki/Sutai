using EasyMobile;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdsReward : MonoBehaviour
{
    public Player.Player player;

    public GameObject text;

    public GameObject btn;
    // Subscribe to rewarded ad events
    private void OnEnable()
    {
        Advertising.RewardedAdCompleted += RewardedAdCompletedHandler;
        if (DataBank.resurect)
        {
            text.SetActive(false);
            btn.SetActive(false);
        }
    }

// Unsubscribe events
    private void OnDisable()
    {
        Advertising.RewardedAdCompleted -= RewardedAdCompletedHandler;
    }

    public void Show()
    {
        var isReady = Advertising.IsRewardedAdReady();

// Show it if it's ready
        if (isReady) Advertising.ShowRewardedAd();
    }

    public void ShowGameover()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }

// Event handler called when a rewarded ad has completed
    private void RewardedAdCompletedHandler(RewardedAdNetwork network, AdPlacement location)
    {
        DataBank.resurect = true;
        player.Heal(player.stats.maxHp);
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
}