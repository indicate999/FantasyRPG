using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingState : MobBaseState
{
    private IAttackable _attackBehavior;
    private float _attackDistance;

    public MovingState(IAttackable attackBehavior, IMobStateSwitcher stateSwitcher, float attackDistance) : base(stateSwitcher)
    {
        _attackBehavior = attackBehavior;
        _attackDistance = attackDistance;
    }

    public override void Enter()
    {
        _attackBehavior.StartMove();
    }

    public override void Update()
    {
        _attackBehavior.Move();

        if (_attackBehavior.CanAttack(_attackDistance))
            _stateSwitcher.SwitchState<AttackingState>();
    }
}
