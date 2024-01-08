using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerLabel : MonoBehaviour
{
    private Timer _timer;
    [SerializeField] private TMP_Text _scoreText;

    public void Initialize(Timer timer) 
    { 
        _timer = timer;
        _timer.HasBeenUpdated += OnValueChanged;
    }

    private void OnDisable()
    {
        _timer.HasBeenUpdated -= OnValueChanged;
    }

    private void OnValueChanged(float value)
    {
        _scoreText.text = DisplayTime(value);
    }

    private string DisplayTime(float value)
    {
        int minutes = Mathf.FloorToInt(value / 60f);
        int seconds = Mathf.FloorToInt(value % 60f);

        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}

