using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using DG.Tweening;

public class EndScreen : Screen
{
    [SerializeField] private Button _restartButton;

    public event UnityAction RestartButtonClick;

    private void OnEnable()
    {
        _restartButton.onClick.AddListener(OnRestartButtonClick);
    }

    private void OnDisable()
    {
        _restartButton.onClick.RemoveListener(OnRestartButtonClick);
    }

    public override void Close()
    {
        CanvasGroup.alpha = 0;
        Deactivate();
    }

    public override void Open()
    {
        CanvasGroup.DOFade(1f, 0.1f).SetUpdate(true);
        SoundManager.instance.PlaySound(SoundManager.instance.LevelEnd, 0.5f);
        Activate();
    }

    private void OnRestartButtonClick()
    {
        RestartButtonClick?.Invoke();
    }

}
