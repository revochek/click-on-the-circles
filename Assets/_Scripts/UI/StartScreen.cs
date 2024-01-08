using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartScreen : Screen
{
    [SerializeField] private Button _startButton;

    private void OnEnable()
    {
        _startButton.onClick.AddListener(OnStartButtonClick);
    }

    private void OnDisable()
    {
        _startButton.onClick.RemoveListener(OnStartButtonClick);
    }

    private void Start()
    {
        Time.timeScale = 0;
        _startButton.transform.DOScale(1.1f, 1f).SetEase(Ease.InOutQuad).SetLoops(-1, LoopType.Yoyo).SetUpdate(true);
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

    private void OnStartButtonClick()
    {
        StartCoroutine(LoadNextSceneCoroutine());
    }

    private IEnumerator LoadNextSceneCoroutine()
    {
        yield return CanvasGroup.DOFade(0f, 1f).SetUpdate(true).WaitForCompletion();
        DOTween.KillAll();
        SceneManager.LoadScene(1);
    }
}