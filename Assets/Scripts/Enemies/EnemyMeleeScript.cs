using UnityEngine;
using System.Collections;

public class EnemyMeleeScript : MonoBehaviour {

    public float radius;
    public LayerMask WhatIsPlayer;

    void Attack()
    {
        var atkHit = Physics2D.CircleCast(transform.position, radius, Vector2.zero, radius, WhatIsPlayer);
        if(atkHit)
        {
            atkHit.collider.GetComponent<PlayerHealthController>().PlayerTakeDamage(1f, this.transform);
            print("attacked");
        }
    }

    public IEnumerator HoldUp(float atkTimer, float flyTimer, float speed, float newSpeed)
    {
        print("holding up");
        speed = 0f;
        yield return new WaitForSeconds(atkTimer);
        Attack();
        yield return new WaitForSeconds(flyTimer);
        speed = newSpeed;
        print("flying again");
    }
}
