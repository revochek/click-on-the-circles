using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class ObjectPool<T> : MonoBehaviour where T : MonoBehaviour
{
    private List<T> _pool = new List<T>();

    [SerializeField] private GameObject _container;
    [SerializeField] private int _capacity;

    protected void InitializePool(IFactory<T> factory)
    {
        for (int i = 0; i < _capacity; i++)
        {
            T spawned = factory.Create(_container.transform);
            spawned.gameObject.SetActive(false);

            _pool.Add(spawned);
        }
    }

    protected bool TryGetObject(out T result)
    {
        result = _pool.Find(p => !p.gameObject.activeSelf);

        if (result != null)
        {
            _pool.Remove(result);
            _pool.Add(result);   
            return true;
        }

        return false;
    }
}