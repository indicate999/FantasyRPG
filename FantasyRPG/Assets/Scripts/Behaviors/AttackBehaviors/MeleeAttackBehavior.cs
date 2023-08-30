using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackBehavior : IAttackable
{
    private MobAnimatorController _animatorController;

    public MeleeAttackBehavior(MobAnimatorController animatorController)
    {
        _animatorController = animatorController;
    }

    public void StartAttack()
    {
        _animatorController.SetAttackAnimation();
    }

    public void Attack()
    {

    }

    
}
