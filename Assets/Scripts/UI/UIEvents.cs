using Game.Player;
using System;

public static class UIEvents
{
    public static event Action OnSettingsClicked;
    public static event Action OnCreditsClicked;
    public static event Action OnBackClicked;

    public static event Action<PlayerType> OnRequestSpeedValue;
    public static event Action<PlayerType, float> OnSpeedSliderValueInitialized;

    public static void RaiseSettingsClicked()
    {
        OnSettingsClicked?.Invoke();
    }

    public static void RaiseCreditsClicked()
    {
        OnCreditsClicked?.Invoke();
    }

    public static void RaiseBackClicked()
    {
        OnBackClicked?.Invoke();
    }

    public static void RaiseRequestSpeedValue(PlayerType playerType)
    {
        OnRequestSpeedValue?.Invoke(playerType);
    }

    public static void RaiseSpeedSliderValueInitialized(PlayerType playerType, float speed)
    {
        OnSpeedSliderValueInitialized?.Invoke(playerType, speed);
    }
}
