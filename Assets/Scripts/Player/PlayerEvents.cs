using System;

namespace Game.Player
{
    public static class PlayerEvents
    {
        public static event Action<PlayerType, float> OnPlayerMovementSpeedChanged;

        public static void RaisePlayerMovementSpeedChanged(PlayerType playerType, float speed)
        {
            OnPlayerMovementSpeedChanged?.Invoke(playerType, speed);
        }
    }
}

