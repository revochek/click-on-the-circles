using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Config", menuName = "Config")]
public class LevelConfiguration : ScriptableObject
{
    [SerializeField] private CircleFactory _circleFactory;
    [SerializeField] private float _secondsToCompleteLevel;
    [SerializeField] private float _secondsBetweenSpawnCircle;

    public float SecondsToCompleteLevel => _secondsToCompleteLevel;
    public CircleFactory CircleFactory => _circleFactory;
    public float SecondsBetweenSpawnCircle => _secondsBetweenSpawnCircle;
}

