using UnityEngine;

public class UiManger : MonoBehaviour
{
    public GameObject upgradePanel;
    public static UiManger Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        if (Instance == null) Instance = this;
    }
}