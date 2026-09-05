using UnityEngine;
using System.Collections.Generic;

public class ObstaclesFactory : MonoBehaviour
{
    [SerializeField] private List<Obstacle> obstacles = new List<Obstacle>();
    private Dictionary<ObstacleType, Obstacle> _obstacles;

    public void Initialize()
    {
        _obstacles = new Dictionary<ObstacleType, Obstacle>();

        foreach (var obstacle in obstacles)
        {
            _obstacles.Add(obstacle.ObstacleType, obstacle);
        }
    }

    public GameObject CreateObstacle(ObstacleType obstacleType)
    {        
        return Instantiate(_obstacles[obstacleType].ObstaclePrefab);
    }
}
