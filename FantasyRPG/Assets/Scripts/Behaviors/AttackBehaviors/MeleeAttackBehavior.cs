using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackBehavior : IAttackable
{
    private MobAnimatorController _animatorController;
    Rigidbody _rigidbody;
    Transform _playerTransform;
    Transform _mobTransform;
    float _moveSpeed;
    float _rotationSpeed;

    public MeleeAttackBehavior(MobAnimatorController animatorController, Rigidbody rigidbody, Transform playerTransform, Transform mobTransform, float moveSpeed, float rotationSpeed)
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

    public void StartAttack()
    {
        _animatorController.SetAttackAnimation();
    }

    public void Attack()
    {

    }

    public bool CanStartAttack(float startAttackDistance)
    {
        var distance = Vector3.Distance(_playerTransform.position, _mobTransform.position);

        if (distance < startAttackDistance)
            return true;
        else
            return false;
    }
}
