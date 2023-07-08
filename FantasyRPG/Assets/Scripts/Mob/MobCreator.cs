using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobCreator : MonoBehaviour
{
    [SerializeField] GameObject SpyPrefab;
    [SerializeField] GameObject GolemPrefab;

    // Start is called before the first frame update
    void Start()
    {
        //GameObject mobObject = Instantiate(SpyPrefab);
        GameObject mobObject = Instantiate(GolemPrefab);

        //MobAnimatorController mobAnimator = mobObject.AddComponent<MobAnimatorController>();

        //mobAnimator.SetWalkAnimation();

        MobController mobController = mobObject.AddComponent<MobController>();

        //mobController.Init(new StandStillWalkBehavior(mobObject.transform, transform.position, 270f));
        mobController.Init(new StraightPatrolWalkBehavior
            (mobObject.GetComponent<MobAnimatorController>(), mobObject.GetComponent<Rigidbody>(), mobObject.transform, transform.position, 270f, 25f, 5f, 1f));


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
