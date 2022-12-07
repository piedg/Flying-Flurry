using System.Collections;
using UnityEngine;

namespace FlyingFurry.Gameplay
{
    public class ObstacleSpawner : MonoBehaviour
    {
        [SerializeField] float MaxPosY;
        [SerializeField] float SpawnTime;
        [SerializeField] float Speed;

        [SerializeField] ObjectPool ObstaclePool;

        [SerializeField] float TimeToDeactive;

        private void Start()
        {
            StartCoroutine(SpawnObstacles());
        }

        private void Update()
        {
            transform.Translate(Vector2.left * Speed * Time.deltaTime);
        }

        IEnumerator SpawnObstacles()
        {
            while(true)
            {
                GameObject obstacles = ObstaclePool.GetObjectFromPool();

                obstacles.transform.SetPositionAndRotation(new Vector2(10f, Random.Range(-MaxPosY, MaxPosY)), Quaternion.identity);

                obstacles.transform.parent = transform;

                obstacles.SetActive(true);

                for (int i = 0; i < obstacles.transform.childCount; i++)
                {
                    obstacles.transform.GetChild(i).gameObject.SetActive(true);
                }

                StartCoroutine(RemoveAfterSeconds(TimeToDeactive, obstacles));

                yield return new WaitForSeconds(SpawnTime);
            }
        }

        IEnumerator RemoveAfterSeconds(float seconds, GameObject obj)
        {
            yield return new WaitForSeconds(seconds);
            obj.SetActive(false);
        }
    }
}
