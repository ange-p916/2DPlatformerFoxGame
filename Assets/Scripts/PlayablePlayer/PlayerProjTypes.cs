using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjTypes : MonoBehaviour {

    public int bulletCount;

    public GameObject regularshot;
   //public GameObject chargeShot;

    ProjectilePool regularshotpool;
    //ProjectilePool blasterpool;

    PlayablePlayer player;

    Transform down, LR, up;

    private void Start()
    {
        player = FindObjectOfType<PlayablePlayer>();

        regularshotpool = new ProjectilePool();
        regularshotpool.StartUpThePool(bulletCount, regularshot);

        //blasterpool = new ProjectilePool();
        //blasterpool.StartUpThePool(bulletCount, chargeShot);


        down = transform.GetChild(0);
        LR = transform.GetChild(1);
        up = transform.GetChild(2);

    }


    public void ShootStuffDown()
    {
        for (int i = 0; i < bulletCount; i++)
        {
            if (!regularshotpool.projectiles[i].activeInHierarchy)
            {
                regularshotpool.projectiles[i].SetActive(true);
                regularshotpool.projectiles[i].transform.position = down.position;
                regularshotpool.projectiles[i].transform.rotation = Quaternion.Euler(new Vector3(0, 0, 270f));
                regularshotpool.projectiles[i].GetComponent<Rigidbody2D>().velocity = Vector2.down * 20f;
                break;
            }
        }
    }

    public void ShootStuffUp()
    {
        for (int i = 0; i < bulletCount; i++)
        {
            if (!regularshotpool.projectiles[i].activeInHierarchy)
            {
                regularshotpool.projectiles[i].SetActive(true);
                regularshotpool.projectiles[i].transform.position = up.position;
                regularshotpool.projectiles[i].transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90f));
                regularshotpool.projectiles[i].GetComponent<Rigidbody2D>().velocity = Vector2.up * 20f;
                break;
            }
        }
    }

    public void ShootStuffLR()
    {
        for (int i = 0; i < bulletCount; i++)
        {
            if (!regularshotpool.projectiles[i].activeInHierarchy)
            {
                regularshotpool.projectiles[i].SetActive(true);
                regularshotpool.projectiles[i].transform.position = LR.position;
                regularshotpool.projectiles[i].transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                regularshotpool.projectiles[i].transform.localScale = player.lookRight ? new Vector3(1, 1, 1) : new Vector3(-1, 1, 1);
                regularshotpool.projectiles[i].GetComponent<Rigidbody2D>().velocity = player.lookRight ? new Vector2(20f, 0) : new Vector2(-20f, 0);
                break;
            }
        }
    }

    //public void ShootChargedBlasterShotLR()
    //{
    //    for (int i = 0; i < cBlasterAMount; i++)
    //    {
    //        if (!cBlasterList[i].activeInHierarchy)
    //        {
    //            cBlasterList[i].SetActive(true);
    //            cBlasterList[i].transform.position = playerBulletPosLR.position;
    //            cBlasterList[i].transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
    //            cBlasterList[i].transform.localScale = player.lookRight ? new Vector3(1, 1, 1) : new Vector3(-1, 1, 1);
    //            cBlasterList[i].GetComponent<Rigidbody2D>().velocity = shootDirX;
    //            break;
    //        }
    //    }
    //}
    ////down
    //public void ShootChargedBlasterShotDown()
    //{
    //    for (int i = 0; i < bulletCount; i++)
    //    {
    //        if (!cBlasterList[i].activeInHierarchy)
    //        {
    //            cBlasterList[i].SetActive(true);
    //            cBlasterList[i].transform.position = playerBulletPosDown.position;
    //            cBlasterList[i].transform.rotation = Quaternion.Euler(new Vector3(0, 0, 270f));
    //            cBlasterList[i].GetComponent<Rigidbody2D>().velocity = shootDirYDown * 20f;
    //            break;
    //        }
    //    }
    //}

    //public void ShootChargedBlasterShotUp()
    //{
    //    for (int i = 0; i < bulletCount; i++)
    //    {
    //        if (!cBlasterList[i].activeInHierarchy)
    //        {
    //            cBlasterList[i].SetActive(true);
    //            cBlasterList[i].transform.position = playerBulletPosUp.position;
    //            cBlasterList[i].transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90f));
    //            cBlasterList[i].GetComponent<Rigidbody2D>().velocity = shootDirY * 20f;
    //            break;
    //        }
    //    }
    //}
}
