using UnityEngine;
using System.Collections;

public class EnemyFlying : EnemyBase {

    Vector3 startPos;

    public float flySpeed = 1.5f;
    public float chaseTimer = 5f;
    public float newChaseTimer = 5f;

    protected override void Start()
    {
        base.Start();
        startPos = transform.position;
    }

    protected override void Update()
    {
        base.Update();
    }

    protected bool ChaseOrRetreat(bool chase)
    {
        var dst = (player.transform.position - this.transform.position);
        transform.localScale = new Vector3(whatSideIsPlayerAt.x, 1f, 1f);
        if (chase)
        {
            rb2d.velocity = new Vector2(dst.x, dst.y).normalized * flySpeed;
        }
        else
        {
            rb2d.velocity = new Vector2((startPos - transform.position).x, (startPos - transform.position).y).normalized * flySpeed;
        }

        return chase;
    }
}
