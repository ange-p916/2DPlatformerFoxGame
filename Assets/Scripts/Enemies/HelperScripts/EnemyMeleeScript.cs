using UnityEngine;
using System.Collections;

public class EnemyMeleeScript : MonoBehaviour {

    public float radius;
    public LayerMask WhatIsPlayer;

    public bool Attack()
    {
        var atkHit = Physics2D.CircleCast(transform.position, radius, Vector2.zero, radius, WhatIsPlayer);
        if(atkHit)
        {            
            atkHit.collider.GetComponent<PlayerHealthController>().PlayerTakeDamage(1f, this.transform);
        }
        return atkHit;
    }
}
