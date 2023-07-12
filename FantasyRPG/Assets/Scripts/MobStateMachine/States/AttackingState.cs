using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackingState : MobBaseState
{
    private IAttackable _attackBehavior;
    private float _attackDistance;

    public AttackingState(IAttackable attackBehavior, IMobStateSwitcher stateSwitcher, float attackDistance) : base(stateSwitcher)
    {
        _attackBehavior = attackBehavior;
        _attackDistance = attackDistance;
    }

    public override void Enter()
    {
        _attackBehavior.StartAttack();
    }

    public override void Update()
    {
        _attackBehavior.Attack();

        if (!_attackBehavior.CanAttack(_attackDistance))
            _stateSwitcher.SwitchState<MovingState>();
    }
}
