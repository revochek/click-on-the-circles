using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleSpawner : ObjectPool<Circle>
{
    private Camera _camera;

    private float _secondsBetweenSpawn;
    private float _elapsedTime = 0;

    private int _spawned;

    [SerializeField] private ScoreData _scoreData;

    public void Initialize()
    {
        _camera = Camera.main;
    }

    public void ConfigureSpawner(CircleFactory circleFactory, float secondsBetweenSpawn)
    {
        _secondsBetweenSpawn = secondsBetweenSpawn;
        InitializePool(circleFactory);

        _scoreData.Clear();
    }


    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _secondsBetweenSpawn)
        {
            if (TryGetObject(out Circle circle))
            {
                _elapsedTime = 0;

                SetCircle(circle, GetRandomSpawnPoint());
            }
        }
    }

    private Vector3 GetRandomSpawnPoint()
    {
        float minX = _camera.ViewportToWorldPoint(new Vector2(0.2f, 0)).x;
        float maxX = _camera.ViewportToWorldPoint(new Vector2(0.8f, 0)).x;
        float minY = _camera.ViewportToWorldPoint(new Vector2(0, 0.1f)).y;
        float maxY = _camera.ViewportToWorldPoint(new Vector2(0, 0.9f)).y;

        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        return new Vector3(randomX, randomY, 0);
    }

    private void SetCircle(Circle circle, Vector3 spawnPoint)
    {
        circle.gameObject.SetActive(true);
        circle.Died += OnCircleDying;
        circle.SetOrderInLayer(_spawned);
        circle.transform.position = spawnPoint;

        _spawned++;
    }
    private void OnCircleDying(Circle circle)
    {
        circle.Died -= OnCircleDying;
        _scoreData.Collect();
    }
}
