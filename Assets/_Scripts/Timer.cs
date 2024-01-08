using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    private float _time;
    private float _remaingTime;

    private bool _isRunning;

    public event UnityAction<float> HasBeenUpdated;
    public event UnityAction TimeIsOver;

    public void ConfigureTimer(float time)
    {
        _time = time;
        _remaingTime = time;

        _isRunning = true;

        HasBeenUpdated?.Invoke(_remaingTime);
    }

    private void Update()
    {
        if (!_isRunning) return;

        if (_remaingTime > 0)
        {
            _remaingTime -= Time.deltaTime;
        }
        else
        {
            TimeIsOver?.Invoke();
            _remaingTime = 0;

            _isRunning = false;
        }

        HasBeenUpdated?.Invoke(_remaingTime);
    }
}
