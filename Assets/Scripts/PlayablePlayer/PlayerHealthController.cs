using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.SceneManagement;

public class PlayerHealthController : MonoBehaviour
{
    private PlayablePlayer player;
    public bool isInvincible = false;
    public float curHealth = 7;
    public float maxHealth = 7;

    void Start()
    {
        player = GetComponent<PlayablePlayer>();
    }
    
    public void HealAgain()
    {
        if (curHealth <= maxHealth)
        {
            curHealth++;
        }
    }


    public void PlayerTakeDamage(float damage, Transform enemyPos,float knockbackvel = 10f)
    {
        if (!isInvincible)
        {
            player.velocity.x = (enemyPos.position - this.transform.position).x > 0 ? Vector2.left.x * knockbackvel : Vector2.right.x * knockbackvel;

            curHealth -= damage;
            isInvincible = true;
            StartCoroutine(TakeDamageAgain());
        }
    }

    private IEnumerator TakeDamageAgain()
    {
        yield return new WaitForSeconds(0.75f);
        isInvincible = false;
    }
}
