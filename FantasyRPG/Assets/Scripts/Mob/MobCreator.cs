using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobCreator : MonoBehaviour
{
    [SerializeField] private Transform PlayerTransform;
    [SerializeField] private GameObject SpyPrefab;
    [SerializeField] private GameObject GolemPrefab;

    private void Start()
    {
        //GameObject mobObject = Instantiate(SpyPrefab);
        GameObject mobObject = Instantiate(GolemPrefab);

        //MobAnimatorController mobAnimator = mobObject.AddComponent<MobAnimatorController>();

        //mobAnimator.SetWalkAnimation();

        MobController mobController = mobObject.AddComponent<MobController>();
        MobAnimatorController mobAnimator = mobObject.GetComponent<MobAnimatorController>();
        Rigidbody mobRigidbody = mobObject.GetComponent<Rigidbody>();

        //mobController.Init(new StandStillWalkBehavior(mobObject.transform, transform.position, 270f));
       //var walkBehavior = new StandStillWalkBehavior(mobObject.transform, transform.position, 270f);
        var walkBehavior = new StraightPatrolWalkBehavior
            (mobAnimator, mobRigidbody, mobObject.transform, transform.position, 270f, 25f, 5f, 1f);

        //var attackBehavior = new StandStillAttackBehavior(mobAnimator, PlayerTransform, mobObject.transform, 5);

        var moveBehavior = new GoToPlayerMoveBehavior(mobAnimator, mobRigidbody, PlayerTransform, mobObject.transform, 5f, 5f);

        var attackBehavior = new MeleeAttackBehavior(mobAnimator);

        mobController.Init(new MobStateMachine(walkBehavior, moveBehavior, attackBehavior, PlayerTransform, mobObject.transform, 8, 3));


    }

}
