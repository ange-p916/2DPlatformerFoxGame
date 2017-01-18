using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggersTouching : MonoBehaviour {

    PlatformController pfmc;

    private void Start()
    {
        pfmc = GetComponentInParent<PlatformController>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("TouchingColliders"))
        {
            pfmc.canMovePlatforms = false;
        }
    }
}
