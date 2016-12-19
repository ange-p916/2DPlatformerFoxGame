using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(EnemyChargingScript))]
[RequireComponent(typeof(EnemyMeleeScript))]
public class EnemyChargerDude : EnemyBase {

    EnemyChargingScript charge;
    EnemyMeleeScript melee;
    EnemyCountDownScript cd;
    protected override void Start()
    {
        base.Start();
        charge = GetComponent<EnemyChargingScript>();
        melee = GetComponent<EnemyMeleeScript>();
        cd = new EnemyCountDownScript(1f, 1f, 0.02f, 0.02f);
    }

    protected override void Update()
    {
        base.Update();
        if(distanceToPlayer <= engageDistance * engageDistance)
        {
            charge.Charge(whatSideIsPlayerAt, rb2d);
            cd.DoAction(melee.AttackVoid);
        }
    }
}
