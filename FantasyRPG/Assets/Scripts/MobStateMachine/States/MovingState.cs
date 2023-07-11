using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingState : MobBaseState
{
    private IAttackable _attackBehavior;
    private float _startAttackDistance;

    public MovingState(IAttackable attackBehavior, IMobStateSwitcher stateSwitcher, float startAttackDistance) : base(stateSwitcher)
    {
        _attackBehavior = attackBehavior;
        _startAttackDistance = startAttackDistance;
    }

    public override void Enter()
    {
        _attackBehavior.StartMove();
    }

    public override void Update()
    {
        _attackBehavior.Move();

        if (_attackBehavior.CanStartAttack(_startAttackDistance))
            _stateSwitcher.SwitchState<AttackingState>();
    }
}
