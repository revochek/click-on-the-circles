using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "ScoreData", menuName = "Stats Data/Score Data")]
public class ScoreData : ScriptableObject
{
    private int _count;

    public event UnityAction<int> ScoreChanged;

    public void Collect()
    {
        _count++;
        ScoreChanged?.Invoke(_count);
    }

    public void Clear()
    {
        _count = 0;
    }
}
