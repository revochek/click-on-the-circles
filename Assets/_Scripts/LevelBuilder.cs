using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour
{
    private CircleSpawner _circleSpawner;
    private Timer _timer;

    [SerializeField] private LevelConfiguration _config;

    public void Initialize(CircleSpawner circleSpawner, Timer timer)
    {
        _circleSpawner = circleSpawner;
        _timer = timer;
    }

    public void BuildLevel()
    {
       _timer.ConfigureTimer(_config.SecondsToCompleteLevel);
       _circleSpawner.ConfigureSpawner(_config.CircleFactory, _config.SecondsBetweenSpawnCircle);
    }
}
