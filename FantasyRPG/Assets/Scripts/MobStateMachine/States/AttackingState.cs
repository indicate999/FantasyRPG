using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackingState : MobBaseState
{
    private IAttackable _attackBehavior;
    private IMoveable _moveBehavior;
    private float _attackDistance;

    public AttackingState(IAttackable attackBehavior, IMoveable moveBehavior, IMobStateSwitcher stateSwitcher, float attackDistance) : base(stateSwitcher)
    {
        _attackBehavior = attackBehavior;
        _moveBehavior = moveBehavior;
        _attackDistance = attackDistance;
    }

    public override void Enter()
    {
        _attackBehavior.StartAttack();
    }

    public override void Update()
    {
        _attackBehavior.Attack();

        if (!_moveBehavior.CanAttack(_attackDistance))
            _stateSwitcher.SwitchState<MovingState>();
    }
}
