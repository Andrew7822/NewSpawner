using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Target _target;
    [SerializeField] private Pool _pool;

    [SerializeField] private float _sleepTimer;

    private WaitForSeconds _sleepTime;

    private void Awake()
    {
        _sleepTime = new WaitForSeconds(_sleepTimer);
    }

    private void Start()
    {
        StartCoroutine(Spawn()); 
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            Warrior warrior = _pool.GetWarrior(transform.position);

            warrior.SetTarget(_target);

            warrior.Dead += ReturnToPool;

            yield return _sleepTime;
        }
    }

    private void ReturnToPool(Warrior warrior)
    {
        _pool.Return(warrior);

        warrior.Dead -= ReturnToPool;
    }
}