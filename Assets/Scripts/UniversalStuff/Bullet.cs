using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    public LayerMask WhatIsPlayer;
    public float timer = 0f;
    public float travelDuration = 2f;
    public float radiusndistance;
    
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
    }

    void HitStuff()
    {
        var hit = Physics2D.CircleCast(transform.position, radiusndistance, Vector2.zero, radiusndistance, WhatIsPlayer);
        if (hit)
        {
            hit.collider.gameObject.GetComponent<PlayerHealthController>().PlayerTakeDamage(1f, this.transform);
            this.gameObject.SetActive(false);
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
