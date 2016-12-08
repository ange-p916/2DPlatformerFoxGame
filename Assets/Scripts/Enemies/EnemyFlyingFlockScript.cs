using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class EnemyFlyingFlockScript : MonoBehaviour {

    public LayerMask WhatIsEnemy;
    public float flySpeed = 1.5f;
    public float bounce, keepX, keepY, flyAwayVal, keepAwayDist;
    public float radius = 5f;
    public List<EnemyFlying> flyingEnemies = new List<EnemyFlying>();
    Rigidbody2D rb2d;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        flyingEnemies = FindObjectsOfType<EnemyFlying>().OrderBy(x => x.gameObject.name).ToList();

    }

    void FixedUpdate()
    {
        var circleToOthers = Physics2D.CircleCastAll(transform.position, radius, Vector2.zero, radius, WhatIsEnemy);

        foreach (var ctoHit in circleToOthers)
        {
            if (ctoHit.collider.name == this.gameObject.name)
                return;

            bounce = ctoHit.distance + keepAwayDist;
            var bounceVec = new Vector2(bounce * keepX, bounce * keepY);

            if (ctoHit)
            {
                transform.position = new Vector2((ctoHit.transform.position - this.transform.position).x,
                                             (ctoHit.transform.position - this.transform.position).y) * flySpeed + bounceVec;

                keepX += flyAwayVal * Time.deltaTime;
                keepY -= flyAwayVal * Time.deltaTime;

            }
        }
        
    }

}
