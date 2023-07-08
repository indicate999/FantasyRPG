using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobController : MonoBehaviour
{
    private IWalkable _walkBehavior;
    private MobStateMachine _MSM;
    private WalkingState _walkingState;

    public void Init(IWalkable walkBehavior) 
    {
        _walkBehavior = walkBehavior;
        _MSM = new MobStateMachine();
        _walkingState = new WalkingState(_walkBehavior);
        _MSM.Initialize(_walkingState);

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
}
