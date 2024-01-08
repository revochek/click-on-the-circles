using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
public class CircleFactory : IFactory<Circle>
{
    [SerializeField] private Circle[] _circleTemplates;

    public Circle Create(Transform parent)
    {
        return GameObject.Instantiate(_circleTemplates[UnityEngine.Random.Range(0, _circleTemplates.Length)], Vector2.zero, Quaternion.identity, parent);
    }
}
