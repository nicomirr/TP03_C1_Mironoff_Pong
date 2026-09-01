using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Player
{
    public class PlayerInputs : MonoBehaviour
    {
        [SerializeField] private PlayerType _playerType;
        public PlayerType PlayerType => _playerType;

        private GameControls _playerControls;        

        private InputAction _moveAction;
        public Vector2 MovementDirection => _moveAction.ReadValue<Vector2>();

        private InputAction _rotateAction;  //p1 = Q E   p2 = 7 9 (numpad) 
        private InputAction _changeColorAction; //p1 = R   p2 = 5 (numpad)

        public bool ChangeColorReleased => _changeColorAction.WasReleasedThisFrame();

        public bool RotationPressed(out float value)
        {
            value = _rotateAction.ReadValue<float>();

            return _rotateAction.WasPressedThisFrame();
        }

        private void Awake()
        {
            _playerControls = new GameControls();
            EnablePlayerInputs();
        }

        private void OnEnable()
        {
            _moveAction.Enable();
            _rotateAction.Enable();
            _changeColorAction.Enable();        
        }

        private void OnDisable()
        {
            _moveAction.Disable();
            _rotateAction.Disable();
            _changeColorAction.Disable();            
        }

        private void EnablePlayerInputs()
        {
            switch (_playerType)
            {
                case PlayerType.PlayerOne:
                    _moveAction = _playerControls.PlayerOne.Move;
                    _rotateAction = _playerControls.PlayerOne.Rotate;
                    _changeColorAction = _playerControls.PlayerOne.ChangeColor;
                    break;

                case PlayerType.PlayerTwo:
                    _moveAction = _playerControls.PlayerTwo.Move;
                    _rotateAction = _playerControls.PlayerTwo.Rotate;
                    _changeColorAction = _playerControls.PlayerTwo.ChangeColor;
                    break;

            }
        }       
                
    }
}


