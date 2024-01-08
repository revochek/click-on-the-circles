using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private GameController _gameController;
    [SerializeField] private LevelBuilder _levelBuilder;
    [SerializeField] private CircleSpawner _circleSpawner;
    [SerializeField] private Timer _timer;

    private void Awake()
    {
        _circleSpawner.Initialize();
        _levelBuilder.Initialize(_circleSpawner, _timer);
        _gameController.Initialize(_timer);

        _levelBuilder.BuildLevel();
    }
}
