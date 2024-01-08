using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private ScoreData _scoreData;

    private void OnEnable()
    {
        _scoreData.ScoreChanged += OnScoreChanged;
    }

    private void OnDisable()
    {
        _scoreData.ScoreChanged -= OnScoreChanged;
    }

    private void OnScoreChanged(int count)
    {
        transform.DOScale(1.07f, 0.1f).OnComplete(() => {
            transform.DOScale(1f, 0.15f);
        });
        _scoreText.text = $"SCORE: {count}";
    }
}
