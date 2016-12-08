using UnityEngine;
using System.Collections;

public class EnemyBase : MonoBehaviour {

    public LayerMask WhatIsPlayer;
    public LayerMask WhatIsWall;
    protected Rigidbody2D rb2d;
    protected Vector2 whatSideIsPlayerAt;
    public float distanceToPlayer;
    public float engageDistance;
    protected PlayablePlayer player;
    protected Vector2 dirToTarget;
    protected float dstToTarget;

    protected virtual void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayablePlayer>();
    }

    protected virtual void Update()
    {
        whatSideIsPlayerAt = (player.transform.position - this.transform.position).x > 0 ? Vector2.right : Vector2.left;
        distanceToPlayer = (player.transform.position - this.transform.position).sqrMagnitude;
        if(LineOfSight())
        {
            Debug.DrawLine(transform.position, player.transform.position);
        }
    }

    protected bool LineOfSight()
    {
        
        var targetInView = Physics2D.CircleCast(transform.position, engageDistance, Vector2.zero, engageDistance, WhatIsPlayer);
        dirToTarget = (player.transform.position - this.transform.position).normalized;
        dstToTarget = Vector2.Distance(transform.position, player.transform.position);

        return !Physics2D.Raycast(transform.position, dirToTarget, dstToTarget, WhatIsWall) && targetInView;
    }
}
