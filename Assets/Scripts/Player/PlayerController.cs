using UnityEngine;
using UnityEngine.EventSystems;

namespace FlyingFurry.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] float JumpForce;
        [field: SerializeField] public int Score { get; private set; }
        [field: SerializeField] public bool IsDead { get; private set; }

        private Touch touch;
        Rigidbody2D rb;
        Animator animator;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
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

        private void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log(other.name);

            if (other.gameObject.CompareTag("Hazard"))
            {
                IsDead = true;
                return;
            }

            if (other.gameObject.CompareTag("Collectable"))
            {
                Score++;
            }
        }
    }
}
