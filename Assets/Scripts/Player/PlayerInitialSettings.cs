using UnityEngine;

namespace Game.Player
{
    [CreateAssetMenu(fileName = "PlayerInitialSettings", menuName = "Scriptable Objects/PlayerInitialSettings")]
    public class PlayerInitialSettings : ScriptableObject
    {
        [Range(0, 10)][SerializeField] private float _movementSpeed;
        public float MovementSpeed => _movementSpeed;

        [Range(1.2f, 1.8f)][SerializeField] private float _padSize;
        public float PadSize => _padSize;

        [SerializeField] private Color _padColor;
        public Color PadColor => _padColor;
    }
}

