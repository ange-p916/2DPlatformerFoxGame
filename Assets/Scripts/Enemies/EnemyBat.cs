using UnityEngine;
using System.Collections;

public class EnemyBat : EnemyFlying {

    EnemyMeleeScript melee;

    protected override void Start()
    {
        base.Start();
        melee = GetComponent<EnemyMeleeScript>();
    }

    protected override void Update()
    {
        base.Update();

        if (distanceToPlayer <= engageDistance * engageDistance)
        {
            ChaseOrRetreat(true);
            StartCoroutine(melee.HoldUp(1f, 2f, flySpeed, flySpeed)); //atk timer, fly timer, speed, new speed
        }
        else
        {
            ChaseOrRetreat(false);
        }
    }
}
