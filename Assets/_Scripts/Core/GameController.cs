using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private Timer _timer;

    [SerializeField] private EndScreen _endScreen;
    [SerializeField] private GameScreen _gameScreen;

    public void Initialize(Timer timer)
    {
        _timer = timer;
        _timer.TimeIsOver += OnTimeEnded;
        _gameScreen.Initialize(_timer);
    }

    private void OnEnable()
    {
        _endScreen.RestartButtonClick += OnRestartButtonClick;
    }

    private void OnDisable()
    {
        _endScreen.RestartButtonClick -= OnRestartButtonClick;
    }

    private void Start()
    {
        Time.timeScale = 1;
    }

    private void OnTimeEnded()
    {
        Time.timeScale = 0;
        _endScreen.Open();
    }

    private void OnRestartButtonClick()
    {
        DOTween.KillAll();
        SceneManager.LoadScene(1);
    }
}
