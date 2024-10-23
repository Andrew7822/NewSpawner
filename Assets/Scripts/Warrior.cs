using System;
using UnityEngine;

public class Warrior : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private int _speed;

    private Target _target;

    private float _deadDistanse = 1f;

    public event Action<Warrior> Dead;

    public void SetTarget(Target target)
    {
        _target = target;
    }

    private void Move()
    {
       _rigidbody.velocity = (_target.transform.position - transform.position).normalized * _speed;
    }

    private void FixedUpdate()
    {
        Move();

        if ((transform.position - _target.transform.position).sqrMagnitude <= _deadDistanse * _deadDistanse)
        {
            Dead.Invoke(this);
        }
    }
}