using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Game.Spawner
{
    public class ObstacleSpawner : MonoBehaviour
    {
        [SerializeField] private ObstaclesPool _obstaclesPool;

        [SerializeField] private float _minSpawnTime;
        [SerializeField] private float _maxSpawnTime;

        [SerializeField] private float _minDespawnTime = 4f;
        [SerializeField] private float _maxDespawnTime = 7f;

        private Bounds _spawnerBounds;

        private void Awake()
        {
            _spawnerBounds = GetComponentInChildren<BoxCollider2D>().bounds;
        }

        private void Start()
        {            
            StartCoroutine(SpawnObstaclesRoutine());
        }


        //ESTA CORRUTINA DEBERIA INICIAR AL LANZARSE LA PELOTA Y TERMINAR CUANDO SE ANOTA UN PUNTO. EVENTOS DE GAMEPLAY
        private IEnumerator SpawnObstaclesRoutine()
        {
            ObstacleType[] obstacleTypes = (ObstacleType[])System.Enum.GetValues(typeof(ObstacleType));

            while (true)
            {
                float spawnTime = Random.Range(_minSpawnTime, _maxSpawnTime);

                yield return new WaitForSeconds(spawnTime);

                float randomX = Random.Range(_spawnerBounds.min.x, _spawnerBounds.max.x);
                float randomY = Random.Range(_spawnerBounds.min.y, _spawnerBounds.max.y);

                Vector2 spawnPos = new Vector2(randomX, randomY);

                ObstacleType randomType = obstacleTypes[Random.Range(0, obstacleTypes.Length)];
                                
                GameObject obstacle = _obstaclesPool.GetObstacle(randomType);         
                
                if(obstacle != null)
                {
                    obstacle.transform.position = spawnPos;
                    obstacle.SetActive(true);

                    float despawnTime = Random.Range(_minDespawnTime, _maxDespawnTime);

                    yield return new WaitForSeconds(despawnTime);

                    _obstaclesPool.ReleaseObstacle(obstacle);
                }                            
            }           
        }       

        
    }
}

