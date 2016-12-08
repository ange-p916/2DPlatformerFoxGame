using UnityEngine;
using System.Collections;

[RequireComponent(typeof(EnemyJumpingScript))]
[RequireComponent(typeof(EnemyShootingScript))]
[RequireComponent(typeof(DiffProjTypes))]
public class EnemyFrog : EnemyBase {

    EnemyJumpingScript jump;
    EnemyShootingScript shoot;
    DiffProjTypes proj;
    protected override void Start()
    {
        base.Start();
        jump = GetComponent<EnemyJumpingScript>();
        shoot = GetComponent<EnemyShootingScript>();
        proj = GetComponent<DiffProjTypes>();
    }

    protected override void Update()
    {
        base.Update();
        if(distanceToPlayer <= engageDistance * engageDistance)
        {
            jump.StartJumpingInPlace(rb2d);
            shoot.Shoot(proj.Shoot);
        }
    }
}
