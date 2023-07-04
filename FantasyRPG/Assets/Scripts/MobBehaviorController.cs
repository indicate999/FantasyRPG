using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobBehaviorController : MonoBehaviour
{
    private IWalkable _walkBehavior;


    public void Init(IWalkable walkBehavior) 
    {
        _walkBehavior = walkBehavior;
    }

    private void Start()
    {
        _walkBehavior.SetStartWalkPoint();
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
        _walkBehavior.Walk();
        //rigidbody.AddForce(rigidbody.transform.forward * moveSpeed);
        //rigidbody.MovePosition(transform.position + (transform.forward * moveSpeed * Time.fixedDeltaTime));
    }
}
