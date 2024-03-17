using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletObjectPool : MonoBehaviour
{
    public static BulletObjectPool Instance;

    [SerializeField] private int _startingPoolSize;
    [SerializeField] private GameObject _bulletRef;
    [SerializeField] private Transform _spawnPos;
    public List<GameObject> _pool = new List<GameObject>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        for (int i = 0; i < _startingPoolSize; i++)
        {
            CreateObject();
        }
    }

    public GameObject GetBulletFromPool()
    {
        for (int i = 0; i < _pool.Count; i++)
        {
            if (!_pool[i].activeInHierarchy)
            {
                ResizePool(i);
                return _pool[i];
            }
        }
        return null;
    }

    private void CreateObject()
    {
        GameObject obj = Instantiate(_bulletRef);
        obj.SetActive(false);
        _pool.Add(obj);
    }

    private void ResizePool(int i)
    {
        if (i <= _pool.Count / 2)
        {
            return;
        }
        int count = _pool.Count;
        for (int j = 0; j < count; j++)
        {
            CreateObject();
        }
    }
}
