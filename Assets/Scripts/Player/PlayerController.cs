using UnityEngine;

namespace Game.Player
{
    public enum PlayerType
    {
        PlayerOne, //WASD 
        PlayerTwo  //NUMPAD
    }

    [RequireComponent(typeof(PlayerInputs))]
    [RequireComponent(typeof(Movement))]
    [RequireComponent(typeof(Rotation))]
    [RequireComponent(typeof(Appearance))]

    public class PlayerController : MonoBehaviour, IMovementSpeedReader
    {                 
        private float _movementSpeed;
        public float MovementSpeed => _movementSpeed;

        private PlayerInputs _playerInputs;
        private Movement _movement;
        private Rotation _rotation;
        private Appearance _appearance;


        private void Awake()
        {
            _playerInputs = GetComponent<PlayerInputs>();
            _movement = GetComponent<Movement>();
            _rotation = GetComponent<Rotation>();
            _appearance = GetComponent<Appearance>();
        }

        private void OnEnable()
        {
            PlayerEvents.OnPlayerMovementSpeedUpdated += TryChangeMovementSpeed;
        }

        private void Start()
        {
            PlayerEvents.RaisePlayerInitialized(_playerInputs.PlayerType);
        }

        private void FixedUpdate()
        {
            HandleMovement();            
        }

        private void Update()
        {
            HandleRotation();       
            HandleColorChange();
        }

        private void OnDisable()
        {
            PlayerEvents.OnPlayerMovementSpeedUpdated -= TryChangeMovementSpeed;
        }

        private void HandleMovement()
        {
            _movement.Move(_playerInputs.MovementDirection, _movementSpeed);
        }

        private void HandleRotation()
        {
            float rotation;

            if (_playerInputs.RotationPressed(out rotation))
            {
                _rotation.Rotate(rotation);
            }
        }

        private void HandleColorChange()
        {
            if(_playerInputs.ChangeColorReleased)
            {
                _appearance.RandomizeColor();
            }
        }        

        private void TryChangeMovementSpeed(PlayerType player, float speed)
        {
            if (_playerInputs.PlayerType != player) return;

            _movementSpeed = speed;
        }

    }
}

