using UnityEngine;

[CreateAssetMenu(fileName = "PlayerInitialSettings", menuName = "Scriptable Objects/PlayerInitialSettings")]
public class PlayerInitialSettings : ScriptableObject
{
    [Range(0, 10)][SerializeField] private float _movementSpeed;
    public float MovementSpeed => _movementSpeed;
}
