using UnityEngine;
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
        [SerializeField] private float attackDelay = 5f;
        private float currentDelay = 0f;
        private readonly Collider2D[] results = new Collider2D[2];
        [SerializeField] private int damage = 1;
        private int hp = 9999;

        private void Awake()
        {
            if (!camera) camera = Camera.main;
        }

        // Start is called before the first frame update
        private void Start()
        {
            Debug.Log(enemyLayer);
        }

        // Update is called once per frame
        private void Update()
        {
            currentDelay += 1 * Time.deltaTime;

            if (!attackjoy.touched || !(currentDelay >= attackDelay)) return;
            currentDelay = 0;
            var go = Instantiate(bullet, transform);
            var angle = Mathf.Atan2(attackjoy.Vertical, attackjoy.Horizontal) * Mathf.Rad2Deg;
            go.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            var b = go.GetComponent<Bullet>();
            b.targetTag = "Enemy";
            b.damage = damage;
        }

        public void TakeDamage(int damage)
        {
            Debug.Log("Take Damage");
            hp--;
            if (hp <= 0)
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}