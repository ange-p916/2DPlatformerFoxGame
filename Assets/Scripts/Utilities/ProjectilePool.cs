using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/* This is used to make a "pool" of objects to use in the class "DiffProjTypes"
*
*/

public class ProjectilePool
{

    public List<GameObject> projectiles;

    //always call this function first
    public void StartUpThePool(int amount, GameObject projectile) 
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
