using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformTrigger : MonoBehaviour {

    PlatformController mparent;

    private void Start()
    {
        mparent = GetComponentInParent<PlatformController>();
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.layer == 9)
        {
            mparent.isPlayerOn = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.layer == 9)
        {
            mparent.isPlayerOn = false;
        }
    }


}
