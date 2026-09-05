using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Game.Gameplay;

namespace Game.Spawner
{
    public class SpawnDirector : MonoBehaviour
    {
        [SerializeField] private List<SpawnableObjectSpawner> _spawners = new List<SpawnableObjectSpawner>();

        //tiempos de spawneo / despawneo a scriptable object

        [SerializeField] private float _minSpawnTime;
        [SerializeField] private float _maxSpawnTime;

        [SerializeField] private float _minDespawnTime = 4f;
        [SerializeField] private float _maxDespawnTime = 7f;


        private void Awake()
        {
            GameplayEvents.OnRoundStarted += StartSpawnObjectsRoutine;
        }

        private void OnDestroy()
        {
            GameplayEvents.OnRoundStarted -= StartSpawnObjectsRoutine;
        }

        private void StartSpawnObjectsRoutine()
        {
            StartCoroutine(SpawnObjectsRoutine());
        }

        private IEnumerator SpawnObjectsRoutine()
        {
            SpawnableObjectCategory[] categories = (SpawnableObjectCategory[])System.Enum.GetValues(typeof(SpawnableObjectCategory));

            while (true)
            {
                float spawnTime = Random.Range(_minSpawnTime, _maxSpawnTime);

                yield return new WaitForSeconds(spawnTime);
                
                SpawnableObjectCategory randomCategory = categories[Random.Range(0, categories.Length)];

                GameObject spawnableObject = null;
                SpawnableObjectSpawner currentSpawner = null;

                foreach (SpawnableObjectSpawner spawner in _spawners)
                {
                    spawnableObject = spawner.TrySpawnObject(randomCategory);

                    if (spawnableObject != null)
                    {
                        currentSpawner = spawner;
                        break;
                    }
                }

                float despawnTime = Random.Range(_minDespawnTime, _maxDespawnTime);
                yield return new WaitForSeconds(despawnTime);

                currentSpawner?.ReleaseObject(spawnableObject);                
            }
        }
    }
}

