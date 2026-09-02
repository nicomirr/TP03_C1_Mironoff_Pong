using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Player
{
    public class PlayerSettings : MonoBehaviour
    {
        private static PlayerSettings _instance;

        [SerializeField] private PlayerInitialSettings _initialSettings;

        private Dictionary<PlayerType, float> _movementSpeeds;

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

            PlayerEvents.OnPlayerInitialized += SendPlayerMovementSpeed;
            PlayerEvents.OnPlayerMovementSpeedChangeRequested += UpdateSpeedValues;
            UIEvents.OnRequestSpeedValue += SendUISpeedValue;
        }

        private void OnDestroy()
        {
            PlayerEvents.OnPlayerInitialized -= SendPlayerMovementSpeed;
            PlayerEvents.OnPlayerMovementSpeedChangeRequested -= UpdateSpeedValues;
            UIEvents.OnRequestSpeedValue -= SendUISpeedValue;

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
    }
}


