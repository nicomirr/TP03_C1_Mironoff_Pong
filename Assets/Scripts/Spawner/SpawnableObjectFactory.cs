using UnityEngine;
using System.Collections.Generic;

namespace Game.Spawner
{
    public class SpawnableObjectFactory : MonoBehaviour
    {
        [SerializeField] private List<SpawnableObject> _spawnableObjects = new List<SpawnableObject>();
        private Dictionary<SpawnableObjectType, SpawnableObject> _spawnableObjectsDictionary;

        public int Count => _spawnableObjects.Count;

        public void Initialize()
        {
            _spawnableObjectsDictionary = new Dictionary<SpawnableObjectType, SpawnableObject>();

            foreach (var obstacle in _spawnableObjects)
            {
                _spawnableObjectsDictionary.Add(obstacle.Type, obstacle);
            }
        }

        public SpawnableObject GetSpawnableObjectData(int index)
        {
            return _spawnableObjects[index];
        }

        public GameObject CreateSpawnableObject(SpawnableObjectType spawnableObjectType)
        {
            return Instantiate(_spawnableObjectsDictionary[spawnableObjectType].Prefab);
        }
    }
}

