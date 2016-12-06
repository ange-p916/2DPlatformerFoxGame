using UnityEngine;
using System.Collections;

public class PlayerKeyTracker : MonoBehaviour {

    public LayerMask WhatIsEnemy;

    EnemyReactor enemyReact;

    public KeyCode AttackKey = KeyCode.K;
    public KeyCode JumpKey = KeyCode.J;
    public KeyCode BackDashKey = KeyCode.Space;

    void Awake()
    {
        enemyReact = FindObjectOfType<EnemyReactor>();
        enemyReact.OnHappen += SendAttackData;
        enemyReact.OnHappen += SendDashData;
        enemyReact.OnHappen += SendJumpData;
    }

	/*
    KEYS:
    JUMP KEY
    ATTACK KEY
    BACKWARDS DASH KEY
    */
    
    void Update()
    {

        if(Input.GetKeyDown(AttackKey))
        {
            if(enemyReact != null)
            {
                enemyReact.Happened(enemyReact);
            }
            
        }

        if (Input.GetKeyDown(JumpKey))
        {
            if (enemyReact != null)
            {
                enemyReact.OnHappen(enemyReact);
            }
        }

        if (Input.GetKeyDown(BackDashKey))
        {
            if (enemyReact != null)
            {
                enemyReact.OnHappen(enemyReact);
            }
        }

    }

    public void SendAttackData(EnemyReactor e)
    {
        print("ATTACK sent from player");
        e.ReactToAttack();
    }

    public void SendJumpData(EnemyReactor e)
    {
        print("JUMP sent from player");
        e.ReactToJump();
    }

    public void SendDashData(EnemyReactor e)
    {
        print("DASH sent from player");
        e.ReactToDash();
    }

}
