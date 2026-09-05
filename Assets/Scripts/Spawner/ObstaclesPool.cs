using System;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesPool : MonoBehaviour
{
    [SerializeField] private int _similarObjectsAmount = 3;
    [SerializeField] private ObstaclesFactory _obstaclesFactory;

    private Dictionary<ObstacleType,List<GameObject>> _pool = new Dictionary<ObstacleType, List<GameObject>>();   

    private void Awake()
    {
        _obstaclesFactory.Initialize();

        foreach (ObstacleType obstacleType in Enum.GetValues(typeof(ObstacleType)))
        {
            _pool.Add(obstacleType, new List<GameObject>());

            for (int i = 0; i < _similarObjectsAmount; i++)
            {
                GameObject obstacle = _obstaclesFactory.CreateObstacle(obstacleType);

                obstacle.transform.parent = this.transform;
                obstacle.SetActive(false);

                _pool[obstacleType].Add(obstacle);
            }
        }
    }

    public GameObject GetObstacle(ObstacleType obstacleType)
    {
        foreach (GameObject obstacle in _pool[obstacleType])
        {
            if (!obstacle.activeSelf)
                return obstacle;
        }

        return null;

    }

    public void ReleaseObstacle(GameObject obstacle)
    {
        obstacle.SetActive(false);
    }
}
