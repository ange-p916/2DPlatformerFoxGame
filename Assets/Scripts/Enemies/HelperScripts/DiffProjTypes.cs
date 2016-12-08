using UnityEngine;
using System.Collections;

public class DiffProjTypes : MonoBehaviour {

    PlayablePlayer player;
    [Tooltip("The velocity and angle of the arc, higher value for tighter arc.")]
    public float v;

    public Vector2 shootDir;

    public Transform enemyProjPos;
    public GameObject bullet;
    [Tooltip("Toggle for a high arc, disable for low arc.")]
    public bool highArc;

    float theta;
    EnemyProjectilePool pool = new EnemyProjectilePool();

    void Start()
    {
        pool.StartUpThePool(20, bullet);
        player = FindObjectOfType<PlayablePlayer>();
    }

    public void Shoot()
    {
        for (int i = 0; i < pool.projectiles.Count; i++)
        {
            if (!pool.projectiles[i].activeInHierarchy)
            {
                var projs = pool.projectiles[i];
                projs.SetActive(true);
                projs.transform.position = enemyProjPos.position;
                projs.GetComponent<Rigidbody2D>().velocity = shootDir * v;
                break;
            }
        }
    }

    public void ShootInArc()
    {
        float x = player.transform.position.x - transform.position.x;
        float y = player.transform.position.y - transform.position.y;
        for (int i = 0; i < pool.projectiles.Count; i++)
        {
            if (!pool.projectiles[i].activeInHierarchy)
            {
                var projs = pool.projectiles[i];
                projs.SetActive(true);
                projs.transform.position = enemyProjPos.position;
                float g = projs.GetComponent<Rigidbody2D>().gravityScale * 10f;
                float det = Mathf.Pow(v, 4) - 2 * v * v * g * y - g * g * x * x;
                if (det > 0)
                {
                    float plusMinus = Mathf.Sqrt(det);
                    if(highArc)
                    {
                        float dividendPlus = v * v + plusMinus;
                        theta = Mathf.Atan(dividendPlus / (g * x));
                    }
                    else
                    {
                        float dividendMinus = v * v - plusMinus;
                        theta = Mathf.Atan(dividendMinus / (g * x));
                    }
                    
                    projs.GetComponent<Rigidbody2D>().velocity = new Vector2((x > 0 ? 1 : -1) * v * Mathf.Cos(theta),
                                                                         (x > 0 ? 1 : -1) * v * Mathf.Sin(theta));

                }
                break;
            }
        }
    }
}
