using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class PowerUpButton : MonoBehaviour
{
    public Image image;
    public TextMeshProUGUI title;
    public TextMeshProUGUI descriptionText;
    public PowerUpObj powerUp;
    public PlayerStats player;
    public PuList pl;
    private Button btn;

    private void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(OnClick);
    }

    private void OnEnable()
    {
        Set(pl.list[Random.Range(0, pl.list.Count)]);
    }

    private void Set(PowerUpObj pu)
    {
        powerUp = pu;
        image.sprite = pu.image;
        title.text = pu.name;
        descriptionText.text = pu.description;
    }

    private void OnClick()
    {
        if (!powerUp) throw new Exception("PowerUp not defined");

        player.AddPu(powerUp);
    }
}