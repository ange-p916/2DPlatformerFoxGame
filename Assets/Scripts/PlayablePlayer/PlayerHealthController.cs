using UnityEngine;
using System.Collections;

public class PlayerHealthController : MonoBehaviour
{
    SpriteRenderer sprender;
    private PlayablePlayer player;
    public bool isInvincible = false;
    public float curHealth = 7;
    public float maxHealth = 7;

    void Start()
    {
        sprender = GetComponent<SpriteRenderer>();
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
            StartCoroutine(BlinkColor());
        }
    }

    private IEnumerator BlinkColor()
    {
        yield return new WaitForSeconds(0.01f);
        sprender.color = Color.black;
        player.moveSpeed /= 2f;
        yield return new WaitForSeconds(1f);
        sprender.color = Color.white;
        player.moveSpeed = 6f;
    }

    private IEnumerator TakeDamageAgain()
    {
        yield return new WaitForSeconds(0.75f);
        isInvincible = false;
    }
}
