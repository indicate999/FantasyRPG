using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public void SetAnimation(string animationName)
    {
        animator.CrossFade(animationName, 0.1f);
    }

}
