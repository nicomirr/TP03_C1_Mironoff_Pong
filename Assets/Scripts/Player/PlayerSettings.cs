using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Player
{
    //REFACTORIZAR CON GENERICS

    public class PlayerSettings : MonoBehaviour
    {
        private static PlayerSettings _instance;

        [SerializeField] private PlayerInitialSettings _initialSettings;

        private Dictionary<PlayerType, float> _movementSpeeds;

        private Dictionary<PlayerType, Color32> _colors;

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
                return;
            }

            _movementSpeeds = new Dictionary<PlayerType, float>();

            foreach (PlayerType playerType in Enum.GetValues(typeof(PlayerType)))
            {
                _movementSpeeds.Add(playerType, _initialSettings.MovementSpeed);
            }

            _colors = new Dictionary<PlayerType, Color32>();

            foreach (PlayerType playerType in Enum.GetValues(typeof(PlayerType)))
            {
                _colors.Add(playerType, _initialSettings.PadColor);
            }

            PlayerEvents.OnPlayerInitialized += SendPlayerMovementSpeed;

            PlayerEvents.OnPlayerMovementSpeedChangeRequested += UpdateSpeedValues;
            PlayerEvents.OnPlayerColorChangeRequested += UpdateColorValues;

            UIEvents.OnSpeedSliderInitialValueRequested += SendUISpeedValue;
            UIEvents.OnColorInitialValueRequested += SendUIColorValue;
        }

        private void OnDestroy()
        {
            PlayerEvents.OnPlayerInitialized -= SendPlayerMovementSpeed;

            PlayerEvents.OnPlayerMovementSpeedChangeRequested -= UpdateSpeedValues;
            PlayerEvents.OnPlayerColorChangeRequested -= UpdateColorValues;

            UIEvents.OnSpeedSliderInitialValueRequested -= SendUISpeedValue;
            UIEvents.OnColorInitialValueRequested -= SendUIColorValue;

            if (_instance == this)
            {
                _instance = null;
            }
        }

        private void UpdateSpeedValues(PlayerType playerType, float speed)
        {
            _movementSpeeds[playerType] = speed;
            SendPlayerMovementSpeed(playerType);
        }

        private void SendPlayerMovementSpeed(PlayerType playerType)
        {
            PlayerEvents.RaisePlayerMovementSpeedUpdated(playerType, _movementSpeeds[playerType]);           
        }

        private void SendUISpeedValue(PlayerType playerType)
        {
            UIEvents.RaiseSpeedSliderValueInitialized(playerType, _movementSpeeds[playerType]);
        }

        private void UpdateColorValues(PlayerType playerType, Color32 color)
        {
            _colors[playerType] = color;
            SendPlayerColor(playerType);
        }

        private void SendPlayerColor(PlayerType playerType)
        {
            PlayerEvents.RaisePlayerColorUpdated(playerType, _colors[playerType]);
        }

        private void SendUIColorValue(PlayerType playerType)
        {
            UIEvents.RaiseColorValueInitialized(playerType, _colors[playerType]);
        }
    }
}


