using UnityEngine;
using UnityEngine.EventSystems;

namespace FlyingFlurry.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] float JumpForce;

        private bool isDead;
        public bool IsDead { get { return isDead; } set { isDead = value; } }

        Vector2 startPosition;

        Touch touch;
        Rigidbody2D rb;
        Animator animator;

        private int score;
        public int Score { get { return score; } set { score = value; } }

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
            startPosition = transform.position;
        }

        private void Update()
        {
            TouchInput();
            KeyboardInput();
        }

        void TouchInput()
        {
            if (!EventSystem.current.IsPointerOverGameObject(touch.fingerId))
            {
                foreach (Touch touch in Input.touches)
                {
                    if (touch.phase == TouchPhase.Began)
                    {
                        Jump();
                        return;
                    }
                }
            }
        }

        void KeyboardInput()
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
                return;
            }
        }

        void Jump()
        {
            rb.velocity = Vector2.up * JumpForce;
            animator.SetTrigger("Jump");
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Hazard"))
            {
                isDead = true;
                return;
            }

            if (other.gameObject.CompareTag("Collectable"))
            {
                score++;
            }
        }

        public void Respawn()
        {
            transform.position = startPosition;
            rb.velocity = Vector2.zero;
            score = 0;
            isDead = false;
        }
    }
}
