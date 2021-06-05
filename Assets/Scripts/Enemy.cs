using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class Enemy : MonoBehaviour, IEntity
{
    [SerializeField] private Transform player;
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

    public void TakeDamage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
            //TODO:Enemy die
            Die();
    }

    private void Die()
    {
        if (parentRoom)
            parentRoom.OnEnemyDie();
        Destroy(gameObject);
    }
}