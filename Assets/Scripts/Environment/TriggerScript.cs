using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour {

    public int triggerLayer;

    public float totalLerpTime;

    public GameObject DoorObject;

    public Transform[] LerpPoints;

    public bool startTheAction;

    UtilityManager utility;

    void Start()
    {
        utility = new UtilityManager();
    }

    void Update()
    {
        if(startTheAction)
        {
            DoorObject.transform.position = utility.StartLerping(LerpPoints[0].transform.position, LerpPoints[1].transform.position, totalLerpTime);
        }
    }

    void OnTriggerEnter2D(Collider2D o)
    {
        if(o.gameObject.layer == triggerLayer)
        {
            startTheAction = true;
        }
    }
    

}
