using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandStillMoveBehavior : IMoveable
{
    private MobAnimatorController _animatorController;
    Transform _playerTransform;
    Transform _mobTransform;
    float _rotationSpeed;

    public StandStillMoveBehavior(MobAnimatorController animatorController, Transform playerTransform, Transform mobTransform, float rotationSpeed)
    {
        _animatorController = animatorController;
        _playerTransform = playerTransform;
        _mobTransform = mobTransform;
        _rotationSpeed = rotationSpeed;
    }

    public void StartMove()
    {
        _animatorController.SetIdleAnimation();
    }

    public void Move()
    {
        Vector3 direction = _playerTransform.position - _mobTransform.position;
        direction.y = 0f;

        Quaternion lookRotation = Quaternion.LookRotation(direction);
        _mobTransform.rotation = Quaternion.Slerp(_mobTransform.rotation, lookRotation, _rotationSpeed * Time.fixedDeltaTime);
    }

    public bool CanAttack(float startAttackDistance)
    {
        return false;
    }
}
