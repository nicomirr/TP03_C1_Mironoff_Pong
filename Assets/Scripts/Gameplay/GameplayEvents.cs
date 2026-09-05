using System;

namespace Game.Gameplay
{
    public static class GameplayEvents
    {
        public static event Action OnRoundStarted;
        public static event Action OnRoundFinished;

        public static void RaiseRoundStarted()
        {
            OnRoundStarted?.Invoke();
        }

        public static void RaiseRoundFinished()
        {
            OnRoundFinished?.Invoke();
        }
    }
}

