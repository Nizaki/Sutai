using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    public class Player : MonoBehaviour, IEntity
    {
        public LayerMask enemyLayer;
        [SerializeField] private Joystick attackjoy;
        [SerializeField] private GameObject bullet;
        public PlayerStats stats;
        public UnityEvent<int> onHealthChange;
        public RoomTemplates rt;
        private readonly Collider2D[] results = new Collider2D[2];
        private float attackDelay;
        private new Camera camera;
        public GameObject deathPanel;
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
            if (stats.barrier)
            {
                stats.barrier = false;
                return;
            }

            stats.hp -= 1;
            camera.DOShakePosition(0.25f);
            onHealthChange.Invoke(stats.hp);
            if (stats.hp <= 0)
            {
                stats.hp = 0;
                Time.timeScale = 0;
                deathPanel.SetActive(true);
            }
        }

        public void Heal(int value)
        {
            stats.hp += value;
            onHealthChange.Invoke(stats.hp);
            if (stats.hp > stats.maxHp) stats.hp = stats.maxHp;
        }
    }
}