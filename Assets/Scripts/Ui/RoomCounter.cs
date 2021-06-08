using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class RoomCounter : MonoBehaviour
{
    [SerializeField] private RoomTemplates rt;

    private TextMeshProUGUI _text;

    // Start is called before the first frame update
    private void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();

    }

    private void Update()
    {
        UpdateText();;
    }
    
    
    private void UpdateText()
    {
        _text.text = rt.cleared + "/" + rt.rooms.Count;
    }
}