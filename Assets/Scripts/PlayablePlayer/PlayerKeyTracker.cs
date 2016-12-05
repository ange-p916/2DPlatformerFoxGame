using UnityEngine;
using System.Collections;

public class PlayerKeyTracker : MonoBehaviour {

    public LayerMask WhatIsEnemy;

    public KeyCode AttackKey = KeyCode.K;
    public KeyCode JumpKey = KeyCode.J;
    public KeyCode BackDashKey = KeyCode.Space;

    void Awake()
    {
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
            RaycastHit2D ray = Physics2D.Raycast(transform.position, Vector2.right, 10f, WhatIsEnemy);
            if(ray)
            {

            }
            
        }

        if (Input.GetKeyDown(JumpKey))
        {

        }

        if (Input.GetKeyDown(BackDashKey))
        {

        }

    }

    public void SendAttackData()
    {
        print("Attacked");
    }

}
