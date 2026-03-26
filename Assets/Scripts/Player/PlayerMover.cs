using System;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _stepSize;
    [SerializeField] private float _maxHeight;
    [SerializeField] private float _minHeight;

    private const float Epsilon = 0.00001f;
    
    private Vector3 _targetPosition;

    private void Start()
    {
        _targetPosition = transform.position;
    }

    private void Update()
    {
        if (transform.position.y >= _maxHeight)
        {
            transform.position = new Vector2(transform.position.x, _maxHeight - Epsilon);
            _targetPosition = transform.position;
        }
        else if (transform.position.y <= _minHeight)
        {
            transform.position = new Vector2(transform.position.x, _minHeight + Epsilon);
            _targetPosition = transform.position;
        }
        else
        {
            if (transform.position != _targetPosition)
                transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _moveSpeed * Time.deltaTime);
        }
    }

    public void MoveUp()
    {
        SetNextPosition(_stepSize);
    }

    public void MoveDown()
    {
        SetNextPosition(-_stepSize);
    }

    private void SetNextPosition(float stepSize)
    {
        _targetPosition = new Vector2(_targetPosition.x, _targetPosition.y + stepSize);
    }
    
}
