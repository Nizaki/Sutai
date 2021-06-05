using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUi : MonoBehaviour
{
    public List<GameObject> healthObj;

    public GameObject hearthPrefab;

    public Player.Player player;

    private void Start()
    {
        transform.RemoveAllChild();
        var hp = player.stats.hp;
        for (int i = 0; i < hp; i++)
        {
            var obj = Instantiate(hearthPrefab, transform);
            healthObj.Add(obj);
        }
        
    }

    private void OnEnable()
    {
        player.onHealthChange.AddListener(UpdateHealth);
    }

    private void UpdateHealth(int value)
    {
        if(value<0)
            return;
        
        if (healthObj.Count > value)
        {
            Destroy(healthObj[healthObj.Count-1]);
            healthObj.RemoveAt(healthObj.Count-1);
        }
    }
    
}