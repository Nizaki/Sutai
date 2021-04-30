using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class Enemy : MonoBehaviour, IEntity
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform player;

    [SerializeField] private float minFireRate = 1f;
    [SerializeField] private float maxFireRate = 5f;

    [SerializeField] private int maxHp;
    private int hp;
    private float nextFire;

    public Room parentRoom;

    // Start is called before the first frame update
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        nextFire = Time.time + Random.Range(0f, 1f);
        hp = maxHp;
    }

    private void Update()
    {
        // if (!(Time.time > nextFire)) return;
        // nextFire = Time.time + Random.Range(minFireRate, maxFireRate);
        // //TODO:shoot at player
        // var pos = player.position - transform.position;
        // var dir = Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg;
        // var go = Instantiate(bullet, transform);
        // go.transform.rotation = Quaternion.AngleAxis(dir, Vector3.forward);
        // go.GetComponent<Bullet>().targetTag = "Player";
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("Take Damage");
        hp -= damage;
        if (hp <= 0)
            //TODO:Enemy die
            Die();
    }

    private void Die()
    {
        parentRoom.OnEnemyDie();
        Destroy(gameObject);
    }
}