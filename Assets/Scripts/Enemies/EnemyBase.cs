using UnityEngine;
using System.Collections;

public class EnemyBase : MonoBehaviour {

    public LayerMask WhatIsPlayer;
    public LayerMask WhatIsWall;
    Rigidbody2D rb2d;
    Vector2 whatSideIsPlayerAt;
    public float distanceToPlayer;
    public float engageDistance;
    protected PlayablePlayer mPlayer;

    protected virtual void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        mPlayer = FindObjectOfType<PlayablePlayer>();
    }

    protected virtual void Update()
    {
        LineOfSight();
    }

    protected void LineOfSight()
    {
        whatSideIsPlayerAt = (mPlayer.transform.position - this.transform.position).x > 0 ? Vector2.right : Vector2.left;
        var circleHit = Physics2D.CircleCast(transform.position, engageDistance, mPlayer.transform.position, engageDistance, WhatIsPlayer);
        var lineBetweenWallAndPlayer = Physics2D.Linecast(transform.position, mPlayer.transform.position, WhatIsWall);
        
        if (!lineBetweenWallAndPlayer && circleHit)
            return;
        Debug.DrawLine(transform.position, mPlayer.transform.position);
    }
}
