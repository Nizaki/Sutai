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
        for (var i = 0; i < hp; i++)
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
        if (value < 0)
            return;

        if (healthObj.Count > value)
        {
            var dif = healthObj.Count - value;
            for (var i = 0; i < dif; i++)
            {
                Destroy(healthObj[healthObj.Count - 1]);
                healthObj.RemoveAt(healthObj.Count - 1);
            }
        }
        else if (healthObj.Count < value)
        {
            var dif = value - healthObj.Count;
            for (var i = 0; i < dif; i++)
            {
                var obj = Instantiate(hearthPrefab, transform);
                healthObj.Add(obj);
            }
        }
    }
}