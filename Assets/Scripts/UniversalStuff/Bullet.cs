using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    public LayerMask WhatIsEnemyType;
    public float timer = 0f;
    public float travelDuration = 2f;
    public float radiusndistance;
    Cooldown cd = new Cooldown();
    UtilityManager util = new UtilityManager();

    int cntr = 0;

    void OnEnable()
    {
        timer = 0;
    }

    void Update()
    {
        HitStuff();
        timer += Time.deltaTime;
        if (timer >= travelDuration)
        {
            gameObject.SetActive(false);
        }
        cd.Update();
    }

    void HitStuff()
    {
        var hit = Physics2D.CircleCast(transform.position, radiusndistance, Vector2.zero, radiusndistance, WhatIsEnemyType);
        if (hit)
        {
            if(hit.collider.gameObject.layer == 9)
            {
                hit.collider.gameObject.GetComponent<PlayerHealthController>().PlayerTakeDamage(1f, this.transform);
                this.gameObject.SetActive(false);
            }
            else if(hit.collider.gameObject.layer == 10)
            {
                
                if(!cd.IsOnCoolDown)
                {
                    cd.Start(2f);
                    cntr++;
                    print(cntr);
                }
                else if(cd.IsOnCoolDown)
                {
                    cntr = 0;
                }

                if(cntr >= 2 % 1) //third shot, when cntr is 3
                {
                    StartCoroutine(util.DoTheShake(Camera.main));
                }

                print("hit enemy");
                //hit.collider.gameObject.GetComponent<EnemyBase>().TakeDamage
                this.gameObject.SetActive(false);
            }

            
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == 8)
        {

            this.gameObject.SetActive(false);
        }
    }
}
