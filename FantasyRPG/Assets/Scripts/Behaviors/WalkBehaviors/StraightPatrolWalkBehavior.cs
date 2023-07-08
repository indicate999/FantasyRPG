using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightPatrolWalkBehavior : IWalkable
{
    private MobAnimatorController _animatorController;
    private Rigidbody _rigidbody;
    private Transform _transform;
    private Vector3 _position;
    private float _YRotationAngle;
    private float _speed;
    private float _patrolDistance;
    private float _rotationDuration;

    private bool _route = true;
    private Vector3 _forward;
    private float _initialYRotation;
    private Vector2 _firstPoint;
    private Vector2 _secondPoint;
    private Vector2 _targetPoint;
    private float _elapsedRotationTime = 0f;

    public StraightPatrolWalkBehavior(MobAnimatorController animatorController, Rigidbody rigidbody, Transform transform, Vector3 position, float YRotationAngle, float patrolDistance, float speed, float rotationDuration)
    {
        _animatorController = animatorController;
        _rigidbody = rigidbody;
        _transform = transform;
        _position = position;
        _YRotationAngle = YRotationAngle;
        _patrolDistance = patrolDistance;
        _speed = speed;
        _rotationDuration = rotationDuration;


    }

    public void StartWalk()
    {
        _transform.position = _position;
        _transform.eulerAngles = new Vector3(0, _YRotationAngle, 0);

        _forward = _transform.forward;
        _initialYRotation = _YRotationAngle;

        _firstPoint = new Vector2(_position.x, _position.z);
        _secondPoint = new Vector2(_position.x, _position.z) + new Vector2(_forward.x, _forward.z) * _patrolDistance;

        _targetPoint = _secondPoint;

        _animatorController.SetWalkAnimation();
    }

    public void Walk()
    {
        Vector2 currentPoint = new Vector2(_transform.position.x, _transform.position.z);

        float distance = Vector2.Distance(currentPoint, _targetPoint);

        if (distance > 0.5f)
        {
            Vector3 direction;

            if (_route)
                direction = (_position + _forward * _patrolDistance) - _transform.position;
            else
                direction = _position - _transform.position;

            Quaternion targetRotation = Quaternion.LookRotation(direction);

            float currentAngleY = _transform.rotation.eulerAngles.y;
            float targetAngleY = targetRotation.eulerAngles.y;

            float angle = targetAngleY - currentAngleY;

            Quaternion rotation = Quaternion.Euler(0f, angle, 0f);

            _transform.rotation = _transform.rotation * rotation;

            _rigidbody.MovePosition(_transform.position + (_transform.forward * _speed * Time.fixedDeltaTime));
        }
        else
        {
            _elapsedRotationTime += Time.fixedDeltaTime;

            float progress = _elapsedRotationTime / _rotationDuration;

            float newYRotation = Mathf.LerpAngle(_initialYRotation, _initialYRotation + 180f, progress);

            _transform.eulerAngles = new Vector3(_transform.eulerAngles.x, newYRotation, _transform.eulerAngles.z);

            if (progress >= 1)
            {
                _forward = _transform.forward;
                _initialYRotation = _transform.eulerAngles.y;
                _route = !_route;
                _elapsedRotationTime = 0f;

                if (_route)
                    _targetPoint = _secondPoint;
                else
                    _targetPoint = _firstPoint;
            }
        }
    }
}
