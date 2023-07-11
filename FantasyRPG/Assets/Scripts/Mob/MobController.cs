using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobController : MonoBehaviour
{
    //private IWalkable _walkBehavior;
    private MobStateMachine _MSM;
    //private WalkingState _walkingState;

    public void Init(MobStateMachine MSM) 
    {
        //_walkBehavior = walkBehavior;
        _MSM = MSM;
        //_walkingState = new WalkingState(_walkBehavior);
        //_MSM.Initialize(_walkingState);

    }

    private void Start()
    {
        //_walkBehavior.StartWalk();
    }

    //private Rigidbody rigidbody;
    //[SerializeField] private float moveSpeed = 5f;

    // Start is called before the first frame update
    void Awake()
    {
        //rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _MSM.CurrentState.Update();
        //_walkBehavior.Walk();
        //rigidbody.AddForce(rigidbody.transform.forward * moveSpeed);
        //rigidbody.MovePosition(transform.position + (transform.forward * moveSpeed * Time.fixedDeltaTime));
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, 8);
    }
}
