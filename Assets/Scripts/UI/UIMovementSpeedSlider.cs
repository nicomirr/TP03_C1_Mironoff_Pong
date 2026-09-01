using UnityEngine;
using Game.Player;
using UnityEngine.UI;
using TMPro;

namespace Game.UI
{
    public class UIMovementSpeedSlider : MonoBehaviour
    {
        //[SerializeField] private TMP_Text _speedText;
        //[SerializeField] private PlayerType _player;

        //private IMovementSpeedReader _movementSpeedReader;

        //private Slider _speedSlider;


        //private void OnEnable()
        //{
        //    _speedSlider.value = _movementSpeedReader.MovementSpeed;
        //    UpdateSpeedText();
        //}

        //private void OnDestroy()
        //{
        //    _speedSlider.onValueChanged.RemoveAllListeners();
        //}

        //private void OnSpeedChanged(float speed)
        //{
        //    PlayerEvents.RaisePlayerMovementSpeedChanged(_player, speed);
        //    _speedSlider.value = speed;
        //    UpdateSpeedText();            
        //}

        //private void UpdateSpeedText()
        //{
        //    int speedPercentage = (int)(_movementSpeedReader.MovementSpeed / _speedSlider.maxValue * 100);
        //    _speedText.text = speedPercentage.ToString() + " %";
        //}

        //public void Initialize(IMovementSpeedReader movementSpeedReader)
        //{
        //    _speedSlider = GetComponent<Slider>();
        //    _movementSpeedReader = movementSpeedReader;

        //    _speedSlider.onValueChanged.AddListener(OnSpeedChanged);
        //}
    }
}

