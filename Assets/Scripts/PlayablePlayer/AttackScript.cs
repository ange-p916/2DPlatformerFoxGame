using UnityEngine;
using System.Collections;

public class AttackScript : MonoBehaviour {

    public BoxCollider2D swordCol;
    public bool isAttacking = false;

    public int attkCounter = 0;
    public int totalAttkCounter = 2;

    public float timer;
    public float totalTimer;

    Cooldown cd;

    void Start()
    {
        cd = new Cooldown();
    }

    public void Update()
    {
        cd.Update();
        if(Input.GetKeyDown(KeyCode.K))
        {
            if(!cd.IsOnCoolDown)
            {
                attkCounter++;
                cd.Start(1f);
            }
            if(attkCounter > totalAttkCounter)
            {
                attkCounter = 0;
            }
            
        }

        
    }
}
