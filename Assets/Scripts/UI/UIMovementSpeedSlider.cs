using UnityEngine;
using Game.Player;
using UnityEngine.UI;
using TMPro;

namespace Game.UI
{
    public class UIMovementSpeedSlider : MonoBehaviour
    {

        [SerializeField] private TMP_Text _speedValueText;
        [SerializeField] private PlayerType _playerType;

        private float _currentSpeed;

        private Slider _speedSlider;


        private void Awake()
        {
            _speedSlider = GetComponent<Slider>();
            _speedSlider.onValueChanged.AddListener(OnSpeedChanged);
            
            UIEvents.OnSpeedSliderValueInitialized += InitializeSpeed;
        }

        private void Start()
        {
            UIEvents.RaiseRequestSpeedValue(_playerType);            
        }

        private void OnDestroy()
        {
            _speedSlider.onValueChanged.RemoveAllListeners();

            UIEvents.OnSpeedSliderValueInitialized -= InitializeSpeed;
        }

        private void InitializeSpeed(PlayerType playerType, float speed)
        {
            if (_playerType != playerType) return;

            _currentSpeed = speed;
            _speedSlider.value = _currentSpeed;
            UpdateSpeedText();
        }

        private void OnSpeedChanged(float speed)
        {
            PlayerEvents.RaisePlayerMovementSpeedChangeRequested(_playerType, speed);
            _currentSpeed = speed;
            UpdateSpeedText();            
        }

        private void UpdateSpeedText()
        {
            int speedPercentage = (int)(_currentSpeed / _speedSlider.maxValue * 100);
            _speedValueText.text = speedPercentage.ToString() + " %";
        }        
    }
}

