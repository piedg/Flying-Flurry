using UnityEngine;

namespace FlyingFurry.Environment
{
    public class BackgroundLoopMover : MonoBehaviour
    {
        [SerializeField] float Speed;
        Vector3 initialPos;

        float bgLength;

        private void Start()
        {
            initialPos = transform.position;
            bgLength = transform.GetChild(0).transform.position.x;
        }

        void Update()
        {
            transform.Translate(Vector3.left * Speed * Time.deltaTime);

            if (transform.position.x < -bgLength)
            {
                transform.position = initialPos;
            }
        }
    }
}
