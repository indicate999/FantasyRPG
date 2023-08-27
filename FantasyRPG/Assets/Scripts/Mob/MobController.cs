using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobController : MonoBehaviour
{
    private MobStateMachine _MSM;

    public void Init(MobStateMachine MSM) 
    {
        _MSM = MSM;
    }

    private void FixedUpdate()
    {
        _MSM.CurrentState.Update();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, 8);
    }
}
