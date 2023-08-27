using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobAnimatorController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    private string _intName = "animNum";

    public void SetIdleAnimation()
    {
        _animator.SetInteger(_intName, 0);
    }

    public void SetWalkAnimation()
    {
        _animator.SetInteger(_intName, 1);
    }

    public void SetAttackAnimation()
    {
        _animator.SetInteger(_intName, 2);
    }
}
