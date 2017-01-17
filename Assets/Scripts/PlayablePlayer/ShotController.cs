using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotController : MonoBehaviour {

    public float secondsBetweenShots = 0.15f;

    float nextPosShotTime;
    bool startShaking = false;
    PlayerProjTypes pProjs;

    

    private void Start()
    {
        pProjs = GetComponent<PlayerProjTypes>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (CanShoot())
            {
                pProjs.ShootStuffLR();
                nextPosShotTime = Time.time + secondsBetweenShots;
            }
        }
    }

    private bool CanShoot()
    {
        bool ifcanshoot = true;
        if (Time.time < nextPosShotTime)
        {
            ifcanshoot = false;
        }
        return ifcanshoot;
    }
}
