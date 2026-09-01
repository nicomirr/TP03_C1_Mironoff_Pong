using UnityEngine;
using UnityEngine.UI;
using Game.Player;
using Game.Pause;

namespace Game.UI
{
    public class MenuController : MonoBehaviour
    {
        [Header("Jugadores")]
        [SerializeField] private GameObject _playerOne;
        [SerializeField] private GameObject _playerTwo;

        [Header("Sliders")]
        [SerializeField] private UIMovementSpeedSlider _playerOneSlider;
        [SerializeField] private UIMovementSpeedSlider _playerTwoSlider;

        [Header("Botones")]
        [SerializeField] private Button _btnPlay;
        [SerializeField] private Button _btnSettings;
        [SerializeField] private Button _btnCredits;
        [SerializeField] private Button _btnExit;

        [Header("Contenedor")]
        [SerializeField] private GameObject _menu;

        [Header("Paneles")]
        [SerializeField] private GameObject _menuPanel;
        [SerializeField] private GameObject _settingsPanel;
        [SerializeField] private GameObject _creditsPanel;

        private void Awake()
        {
            //if (_playerOne.TryGetComponent<IMovementSpeedReader>(out var playerOneReader))
            //    _playerOneSlider.Initialize(playerOneReader);
            //else
            //    Debug.LogError("Player One no implementa IMovementSpeedReader.");

            //if (_playerTwo.TryGetComponent<IMovementSpeedReader>(out var playerTwoReader))
            //    _playerTwoSlider.Initialize(playerTwoReader);
            //else
            //    Debug.LogError("Player Two no implementa IMovementSpeedReader.");

            _btnPlay.onClick.AddListener(OnPlayClicked);
            _btnSettings.onClick.AddListener(OnSettingsClicked);
            _btnCredits.onClick.AddListener(OnCreditsClicked);
            _btnExit.onClick.AddListener(OnExitClicked);
        }

        private void OnDestroy()
        {
            _btnPlay.onClick.RemoveAllListeners();
            _btnSettings.onClick.RemoveAllListeners();
            _btnCredits.onClick.RemoveAllListeners();
            _btnExit.onClick.RemoveAllListeners();
        }

        private void OnPlayClicked()
        {
            _menu.SetActive(false);
            PauseEvents.RaiseContinueClicked();
        }

        private void OnSettingsClicked()
        {
            _menuPanel.SetActive(false);
            _settingsPanel.SetActive(true);
        }

        private void OnCreditsClicked()
        {
            _menuPanel.SetActive(false);
            _creditsPanel.SetActive(true);
        }

        private void OnExitClicked()
        {
            Application.Quit();

#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }
    }
}

