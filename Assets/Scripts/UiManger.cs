using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManger : MonoBehaviour
{
    public static UiManger Instance { get; private set; }
    public GameObject upgradePanel;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        if (Instance == null) Instance = this;
    }

    // Update is called once per frame
    private void Update()
    {
    }
}