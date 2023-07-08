using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobAnimatorController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    private string _intName = "animNum";

    private void Awake()
    {
        //_animator = GetComponent<Animator>();
    }

    public void SetIdleAnimation()
    {
        _animator.SetInteger(_intName, 0);
        Debug.Log(_animator.GetInteger(_intName));
    }

    public void SetWalkAnimation()
    {
        _animator.SetInteger(_intName, 1);
        Debug.Log(_animator.GetInteger(_intName));
    }
}
