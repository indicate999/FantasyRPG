using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToPlayerMoveBehavior : IMoveable
{
    private MobAnimatorController _animatorController;
    private Rigidbody _rigidbody;
    private Transform _playerTransform;
    private Transform _mobTransform;
    private float _moveSpeed;
    private float _rotationSpeed;

    public GoToPlayerMoveBehavior(MobAnimatorController animatorController, Rigidbody rigidbody, Transform playerTransform, Transform mobTransform, float moveSpeed, float rotationSpeed)
    {
        _animatorController = animatorController;
        _rigidbody = rigidbody;
        _playerTransform = playerTransform;
        _mobTransform = mobTransform;
        _moveSpeed = moveSpeed;
        _rotationSpeed = rotationSpeed;
    }

    public void StartMove()
    {
        _animatorController.SetWalkAnimation();
    }

    public void Move()
    {
        Vector3 direction = _playerTransform.position - _mobTransform.position;
        direction.y = 0f;

        Quaternion lookRotation = Quaternion.LookRotation(direction);
        _mobTransform.rotation = Quaternion.Slerp(_mobTransform.rotation, lookRotation, _rotationSpeed * Time.fixedDeltaTime);

        _rigidbody.MovePosition(_mobTransform.position + (_mobTransform.forward * _moveSpeed * Time.fixedDeltaTime));
    }
    public bool CanAttack(float startAttackDistance)
    {
        var distance = Vector3.Distance(_playerTransform.position, _mobTransform.position);

        if (distance < startAttackDistance)
            return true;
        else
            return false;
    }
}
