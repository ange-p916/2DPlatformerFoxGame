using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDropSplit : EnemyBase {

    public GameObject smallSplitEnemy;


    ProjectilePool splitEnemyPool = new ProjectilePool();


    protected override void Start()
    {
        base.Start();
        splitEnemyPool.StartUpThePool(20, smallSplitEnemy);
        
    }

    protected override void Update()
    {
        base.Update();
        if(Input.GetKeyDown(KeyCode.T))
        {
            SplitUp();
        }
    }

    void SplitUp()
    {
        int t = 0;

        for (int i = 0; i < splitEnemyPool.projectiles.Count; i++)
        {
            if (!splitEnemyPool.projectiles[i].activeInHierarchy)
            {
                splitEnemyPool.projectiles[i].SetActive(true);
                t++;
                if (t == 2)
                    break;
                else
                    continue;
            }
        }
        
    }


}
