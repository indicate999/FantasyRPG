using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingState : MobBaseState
{
    private IMoveable _moveBehavior;
    private float _attackDistance;

    public MovingState(IMoveable moveBehavior, IMobStateSwitcher stateSwitcher, float attackDistance) : base(stateSwitcher)
    {
        _moveBehavior = moveBehavior;
        _attackDistance = attackDistance;
    }

    public override void Enter()
    {
        _moveBehavior.StartMove();
    }

    public override void Update()
    {
        _moveBehavior.Move();

        if (_moveBehavior.CanAttack(_attackDistance))
            _stateSwitcher.SwitchState<AttackingState>();
    }
}
