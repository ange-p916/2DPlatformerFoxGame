using UnityEngine;
using System.Collections;
using System;

public class EnemyShootingScript : MonoBehaviour {

    [Header("Cooldowns")]
    public float CDToShoot;
    public float newCDToShoot;
    [Tooltip("The time that it fires in total.")]
    public float timeIsShooting;
    public float newTimeIsShooting;
    [Tooltip("Time between shots, eg if timeIsShooting is 1 sec and TBS is 0.2 it fires 5 times within a second.")]
    public float timeBetweenShots;
    public float newTimeBetweenShots;

    [Header("Shot variables")]
    public float shotSpeed = 5f;

    bool initiateShot;
    public bool isShooting;

    public void Shoot(Action method)
    {
        initiateShot = true;
        if (initiateShot)
        {
            CDToShoot -= Time.deltaTime;
        }

        if (CDToShoot <= 0)
        {
            isShooting = true;
            timeIsShooting -= Time.deltaTime;
            if (isShooting)
            {
                timeBetweenShots -= Time.deltaTime;
                if (timeBetweenShots <= 0f)
                {
                    method();
                    timeBetweenShots = newTimeBetweenShots;
                }

            }

            if (timeIsShooting <= 0)
            {
                isShooting = false;
                CDToShoot = newCDToShoot;
            }

            if (!isShooting && CDToShoot >= 0)
            {
                timeIsShooting = newTimeIsShooting;
            }

        }
        if (CDToShoot <= 0.5f)
        {
            initiateShot = false;
        }
    }
}
