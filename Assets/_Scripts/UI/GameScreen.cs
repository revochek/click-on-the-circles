using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScreen : Screen
{
    [SerializeField] private TimerLabel _timerLabel;

    public void Initialize(Timer timer)
    {
        _timerLabel.Initialize(timer);
    }

    public override void Close()
    {
        CanvasGroup.alpha = 0;
        Deactivate();
    }
    public override void Open()
    {
        CanvasGroup.alpha = 1;
        Activate();
    }
}
