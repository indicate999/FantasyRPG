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
        GameObject mobObject = Instantiate(SpyPrefab);
        //GameObject mobObject = Instantiate(GolemPrefab);

        MobBehaviorController mobController = mobObject.AddComponent<MobBehaviorController>();

        //mobController.Init(new StandStillWalkBehavior(mobObject.transform, transform.position, 270f));
        mobController.Init(new StraightPatrolWalkBehavior
            (mobObject.GetComponent<Rigidbody>(), mobObject.transform, transform.position, 270f, 25f, 5f, 2f));


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
