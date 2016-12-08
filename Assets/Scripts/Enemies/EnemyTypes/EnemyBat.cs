using UnityEngine;
using System.Collections;

[RequireComponent(typeof(EnemyMeleeScript))]
public class EnemyBat : EnemyFlying {

    public float timer = 1f;
    public float newTimer = 1f;
    public bool hasCded;
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
            if(melee.Attack())
            {
                flySpeed = 0f;
                hasCded = true;
            }
            else
            {
                ChaseOrRetreat(true);
            }
        }
        else
        {
            ChaseOrRetreat(false);
        }
        if(hasCded)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                flySpeed = 1.5f;
                timer = newTimer;
                hasCded = false;
            }
        }
    }
}
