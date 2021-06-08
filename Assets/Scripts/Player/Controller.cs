using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Controller : MonoBehaviour
    {
        public Joystick moveJoy;
        [SerializeField] private float speed = 5f;
        private Vector2 move;
        private Rigidbody2D rb;

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        private void Update()
        {
            move = new Vector2(moveJoy.Horizontal, moveJoy.Vertical);
            if (move == Vector2.zero)
                move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        }

        private void FixedUpdate()
        {
            rb.MovePosition((Vector2) transform.position + move * (speed * Time.fixedDeltaTime));
        }
    }
}