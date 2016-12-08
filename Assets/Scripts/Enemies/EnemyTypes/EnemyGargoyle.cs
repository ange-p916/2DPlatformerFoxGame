using UnityEngine;
using System.Collections;

[RequireComponent(typeof(EnemyShootingScript))]
[RequireComponent(typeof(DiffProjTypes))]
public class EnemyGargoyle : EnemyBase {


    DiffProjTypes projs;
    EnemyShootingScript shoot;
	protected override void Start ()
    {
        base.Start();
        projs = GetComponent<DiffProjTypes>();
        shoot = GetComponent<EnemyShootingScript>();
	}

    protected override void Update ()
    {
        base.Update();
        if(distanceToPlayer <= engageDistance * engageDistance)
        {
            shoot.Shoot(projs.ShootInArc);
        }
        
	}
}
