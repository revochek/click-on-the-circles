using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[RequireComponent(typeof(CircleCollider2D))]
public class Circle : MonoBehaviour, IPointerClickHandler
{
    private bool _isClicked;

    public event UnityAction<Circle> Died;

    private void OnEnable()
    {
        _isClicked = false;

        float outerCircleSize = UnityEngine.Random.Range(0.8f, 1.5f);
        transform.localScale = new Vector2(outerCircleSize, outerCircleSize);

        SpawnAnimation(transform.localScale * 1.2f);
    }

    private void SpawnAnimation(Vector2 startScale)
    {
        transform.DOScale(startScale, 0.8f).From(startScale * 0.5f).SetEase(Ease.InOutSine);
    }

    public void SetOrderInLayer(int order)
    {
        transform.GetComponent<SpriteRenderer>().sortingOrder = order;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!_isClicked)
        {
            StartCoroutine(DeathCoroutine());
            SoundManager.instance.PlaySound(SoundManager.instance.Pop, 1);
            _isClicked = true;
        }
    }

    private void Die()
    {
        gameObject.SetActive(false);
        Died?.Invoke(this);
    }

    private IEnumerator DeathCoroutine()
    {
        yield return transform.DOScale(Vector3.zero, 0.2f).WaitForCompletion();
        Die();
    }
}