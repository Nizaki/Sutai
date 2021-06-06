using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering.UI;
using UnityEngine.SceneManagement;

namespace Player
{
    public class Player : MonoBehaviour, IEntity
    {
        public LayerMask enemyLayer;
        [SerializeField] private Joystick attackjoy;
        private new Camera camera;
        [SerializeField] private GameObject bullet;
        private float attackDelay;
        private readonly Collider2D[] results = new Collider2D[2];
        public PlayerStats stats;
        public UnityEvent<int> onHealthChange;
        private void Awake()
        {
            if (!camera) camera = Camera.main;
        }

        // Start is called before the first frame update
        private void Start()
        {
            onHealthChange ??= new UnityEvent<int>();
            stats.CalStats();
        }

        // Update is called once per frame
        private void Update()
        {
            if (!attackjoy.touched || !(attackDelay <= Time.time)) return;
            attackDelay = Time.time + stats.attackDelay;
            var go = Instantiate(bullet, transform);
            var angle = Mathf.Atan2(attackjoy.Vertical, attackjoy.Horizontal) * Mathf.Rad2Deg;
            go.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            var b = go.GetComponent<Bullet>();
            b.targetTag = "Enemy";
            b.damage = Mathf.RoundToInt(stats.attackDamage);
        }

        public void TakeDamage(int damage)
        {
            Debug.Log("Take Damage");
            if(stats.barrier)
                return;
            stats.hp -= 1;
            onHealthChange.Invoke(stats.hp);
            if (stats.hp <= 0)
                Debug.Log("Death !");
        }
    }
}