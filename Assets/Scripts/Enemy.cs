using UnityEngine;

public class Enemy : MonoBehaviour, IEntity
{
    [SerializeField] private Transform player;
    [SerializeField] private int maxHp;

    public Room parentRoom;
    private int hp;
    private float nextFire;

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