using System.Collections;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class Room : MonoBehaviour
{
    public bool spawnable;
    public int monsterCount = 3;


    public RoomTemplates rt;
    private Transform cTransform;

    private bool generated;
    private readonly Vector2 offset = new Vector2(8, -8);

    private UnityEvent onMonsterDeath;

    private RoomDoor rd;
    private int remainEnemy;

    private MonsterTemplate template;

    // Start is called before the first frame update
    private void Start()
    {
        if (!cTransform) cTransform = Camera.main.transform;
        template = GameObject.FindGameObjectWithTag("Template").GetComponent<MonsterTemplate>();
        onMonsterDeath ??= new UnityEvent();
        rd = GetComponent<RoomDoor>();
        StartCoroutine(nameof(Wait));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player") || !generated) return;
        var pos = transform.position;
        cTransform.DOMove(new Vector3(pos.x, pos.y, -10), 1f);
        if (!spawnable) return;
        rd.ShowDoor();
        Invoke(nameof(SpawnMonster), 2f);

        spawnable = false;
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(3f);
        generated = true;
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
            rd.HideDoor();
            UiManger.Instance.upgradePanel.SetActive(true);
            Debug.Log("Toggle update Panel");
            rt.cleared += 1;
        }
    }
}