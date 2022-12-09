using System.Collections;
using UnityEngine;

namespace FlyingFlurry.Gameplay
{
    public class ObstacleSpawner : MonoBehaviour
    {
        [SerializeField] float MaxPosY;
        [SerializeField] float SpawnTime;
        [SerializeField] float Speed;
        [SerializeField] float TimeToDeactive;

        public bool SpawnActive;

        float spawnDelay;

        [SerializeField] ObjectPool ObstaclePool;

        private void Update()
        {
            transform.Translate(Vector2.left * Speed * Time.deltaTime);

            SpawnObstacles();
        }

        void SpawnObstacles()
        {
            if (!SpawnActive) return;

            spawnDelay -= Time.deltaTime;

            if(spawnDelay <= 0)
            {
                GameObject obstacles = ObstaclePool.GetObjectFromPool();

                obstacles.transform.SetPositionAndRotation(new Vector2(5f, Random.Range(-MaxPosY, MaxPosY)), Quaternion.identity);

                obstacles.transform.parent = transform;

                obstacles.SetActive(true);

                for (int i = 0; i < obstacles.transform.childCount; i++)
                {
                    obstacles.transform.GetChild(i).gameObject.SetActive(true);
                }

                spawnDelay = SpawnTime;
            }
        }

        IEnumerator RemoveAfterSeconds(float seconds, GameObject obj)
        {
            yield return new WaitForSeconds(seconds);
            obj.SetActive(false);
        }

        public void ResetObstacles()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
}
