using System.Collections;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private GameObject[] _points;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private int _speed;
    [SerializeField] private float _sleepTimer;
    [SerializeField] private WaitForSeconds _sleepTime;

    private void Awake()
    {
        _sleepTime = new WaitForSeconds(_sleepTimer);
    }

    private int _indexPoints = 0;

    private IEnumerator Start()
    {
        while (true)
        {
            SetDetermineVector();

            yield return _sleepTime;
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        _rigidbody.velocity = (_points[_indexPoints].transform.position - transform.position).normalized * _speed;
    }

    private void SetDetermineVector()
    {
        _indexPoints++;

        if (_indexPoints == _points.Length)
        {
            _indexPoints = 0;
        }

        Vector3 determineVector = _points[_indexPoints].transform.position;
        transform.forward = determineVector - transform.position;
    }
}