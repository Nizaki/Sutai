using System;
using DG.Tweening;
using Unity.Mathematics;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class Room : MonoBehaviour
{
    private Transform cTransform;
    public bool spawnable;
    public int monsterCount = 3;
    private MonsterTemplate template;
    private Vector2 offset = new Vector2(8, -8);

    private UnityEvent onMonsterDeath;

    private int remainEnemy;

    // Start is called before the first frame update
    private void Start()
    {
        if (!cTransform) cTransform = Camera.main.transform;
        template = GameObject.FindGameObjectWithTag("Template").GetComponent<MonsterTemplate>();
        onMonsterDeath ??= new UnityEvent();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"Enter {other.tag}");
        if (!other.CompareTag("Player")) return;
        var pos = transform.position;
        cTransform.DOMove(new Vector3(pos.x, pos.y, -10), 1f);
        if (!spawnable) return;
        Invoke(nameof(SpawnMonster), 2f);

        spawnable = false;
    }

    private void SpawnMonster()
    {
        var pos = transform.position;
        var rcount = Random.Range(1, monsterCount);
        for (var i = 0; i < rcount; i++)
        {
            remainEnemy += 1;
            var rand = Random.Range(0, template.monsters.Count);
            var obj = Instantiate(template.monsters[rand],
                new Vector2(pos.x + Random.Range(offset.y, offset.x), pos.y + Random.Range(offset.y, offset.x)),
                quaternion.identity);
            obj.GetComponent<Enemy>().parentRoom = this;
        }
    }

    public void OnEnemyDie()
    {
        remainEnemy -= 1;
        if (remainEnemy <= 0)
        {
            UiManger.Instance.upgradePanel.SetActive(true);
            Debug.Log("Toggle update Panel");
        }
    }
}