using UnityEngine;

namespace FlyingFurry.Gameplay
{
    public class Collectable : MonoBehaviour, ICollectable
    {
        public void OnPick()
        {
            // Play sound
            // Play particle effects
            gameObject.SetActive(false);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                OnPick();
            }
        }
    }
}
