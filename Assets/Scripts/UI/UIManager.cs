using Game.Pause;
using UnityEngine;

namespace Game.UI
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private UIPanel _pausePanel;
        [SerializeField] private UIPanel _settingsPanel;
        [SerializeField] private UIPanel _creditsPanel;

        private UIPanel _currentPanel;
        private UIPanel _previousPanel;

        private void Awake()
        {
            PauseEvents.OnGamePausedByInput += OpenPause;
            PauseEvents.OnGameUnpausedByInput += ClosePause;

            UIEvents.OnSettingsClicked += OpenSettings;

            UIEvents.OnCreditsClicked += OpenCredits;

            UIEvents.OnBackClicked += GoBack;

        }

        private void OnDestroy()
        {
            PauseEvents.OnGamePausedByInput -= OpenPause;
            PauseEvents.OnGameUnpausedByInput -= ClosePause;

            UIEvents.OnSettingsClicked -= OpenSettings;

            UIEvents.OnCreditsClicked -= OpenSettings;

            UIEvents.OnBackClicked -= GoBack;
        }

        private void OpenPause()
        {
            _pausePanel.DisplayPanel();
            _currentPanel = _pausePanel;
        }

        private void ClosePause()
        {
            _currentPanel.HidePanel();
            _currentPanel = null;
        }

        private void OpenSettings()
        {
            OpenPanel(_settingsPanel);
        }

        private void OpenCredits()
        {
            OpenPanel(_creditsPanel);
        }

        private void OpenPanel(UIPanel panel)
        {
            _previousPanel = _currentPanel;

            _currentPanel.HidePanel();
            panel.DisplayPanel();

            _currentPanel = panel;
        }

        private void GoBack()
        {            
            _currentPanel.HidePanel();
            _previousPanel.DisplayPanel();

            _currentPanel = _previousPanel;
            _previousPanel = null;
        }
    }
}

