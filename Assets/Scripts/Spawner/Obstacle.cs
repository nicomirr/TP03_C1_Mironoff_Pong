using UnityEngine;

[CreateAssetMenu(fileName = "Obstacle", menuName = "Scriptable Objects/Obstacle")]
public class Obstacle : ScriptableObject
{
    [SerializeField] private ObstacleType _obstacleType;
    public ObstacleType ObstacleType => _obstacleType;

    [SerializeField] private GameObject _obstaclePrefab;
    public GameObject ObstaclePrefab => _obstaclePrefab;
}
