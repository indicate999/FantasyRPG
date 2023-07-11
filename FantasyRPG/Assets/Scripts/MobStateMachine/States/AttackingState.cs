using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackingState : MobBaseState
{
    private IAttackable _attackBehavior;

    public AttackingState(IAttackable attackBehavior, IMobStateSwitcher stateSwitcher) : base(stateSwitcher)
    {
        _attackBehavior = attackBehavior;
    }

    public override void Enter()
    {
        _attackBehavior.StartAttack();
    }

    public override void Update()
    {
        _attackBehavior.Attack();
    }
}
