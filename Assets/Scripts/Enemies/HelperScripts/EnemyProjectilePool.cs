using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/* This is used to make a "pool" of objects to use in the class "DiffProjTypes"
*
*/

public class EnemyProjectilePool
{

    public List<GameObject> projectiles;

    public void StartUpThePool(int amount, GameObject projectile) //always call this function first
    {
        GameObject newObj;

        projectiles = new List<GameObject>();

        for (int i = 0; i < amount; i++)
        {
            newObj = GameObject.Instantiate(projectile);
            newObj.SetActive(false);
            projectiles.Add(newObj);
        }
    }

}
