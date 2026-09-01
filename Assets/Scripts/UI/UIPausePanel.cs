using Game.Pause;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public class UIPausePanel : UIPanel
    {
        [SerializeField] private Button _btnPlay;
        [SerializeField] private Button _btnSettings;
        [SerializeField] private Button _btnCredits;
        [SerializeField] private Button _btnExit;

        private void Awake()
        {
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
            HidePanel();
            PauseEvents.RaiseContinueClicked();
        }

        private void OnSettingsClicked()
        {
            HidePanel();
            UIEvents.RaiseSettingsClicked();
        }

        private void OnCreditsClicked()
        {
            HidePanel();
            UIEvents.RaiseCreditsClicked();
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
