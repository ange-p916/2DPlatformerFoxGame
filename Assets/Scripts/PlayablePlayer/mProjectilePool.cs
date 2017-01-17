using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class mProjectilePool : MonoBehaviour
{

    public static mProjectilePool Instance;

    GameObject newObj;
    public GameObject bullet;

    [Header("LR Up Down")]
    public Transform playerBulletPosLR;
    public Transform playerBulletPosUp;
    public Transform playerBulletPosDown;
    //public Transform muzzleFlashPos;
    public List<GameObject> stuff = new List<GameObject>();
    public int bulletCount;
    public Vector2 shootDirX;
    public Vector2 shootDirY = new Vector2(0, 1);
    public Vector2 shootDirYDown = new Vector2(0, -1);
    public bool canShoot = true;

    PlayablePlayer player;

    GameObject cBlaster;

    [Header("Charged Blaster shots")]
    public GameObject chargedBlasterShot;
    public List<GameObject> cBlasterList = new List<GameObject>();
    public int cBlasterAMount;

    void Awake()
    {
        Instance = this;
        for (int i = 0; i < bulletCount; i++)
        {
            newObj = Instantiate(bullet);
            newObj.SetActive(false);
            stuff.Add(newObj);
        }
        player = FindObjectOfType<PlayablePlayer>();
        for (int i = 0; i < cBlasterAMount; i++)
        {
            cBlaster = Instantiate(chargedBlasterShot);
            cBlaster.SetActive(false);
            cBlasterList.Add(cBlaster);
        }
    }

    

    //void MuzzleFlashFuncLR()
    //{
    //    for (int i = 0; i < muzzleFlashCount; i++)
    //    {
    //        if (!muzzleflashlist[i].activeInHierarchy)
    //        {
    //            muzzleflashlist[i].SetActive(true);
    //            muzzleflashlist[i].transform.position = muzzleFlashPos.position;
    //            return;
    //        }
    //    }
    //}
}
