using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyMeleeScript))]
public class EnemyDancer : EnemyBase {

    public bool isblocking = false;
    public float moveSpeed = 5f;
    public GameObject shield;
    EnemyMeleeScript melee;
    EnemyCountDownScript moveLeftCD;
    EnemyCountDownScript moveRightCD;
    EnemyCountDownScript attackCD;
    EnemyCountDownScript blockCD;
    EnemyCountDownScript notBlockingCD;

    protected override void Start()
    {
        base.Start();
        melee = GetComponent<EnemyMeleeScript>();
        moveLeftCD = new EnemyCountDownScript(1f, 1f, 0.8f, 0.8f);
        moveRightCD = new EnemyCountDownScript(2f, 2f, 0.8f, 0.8f);
        attackCD = new EnemyCountDownScript(2f, 2f, 0.02f, 0.02f);
        blockCD = new EnemyCountDownScript(1.5f, 1.5f, 1f, 1f);
        notBlockingCD = new EnemyCountDownScript(0.5f, 0.5f, 0.5f, 0.5f);
    }

    protected override void Update()
    {
        base.Update();
        if(distanceToPlayer <= engageDistance * engageDistance)
        {
            attackCD.DoAction(melee.AttackVoid);
            moveLeftCD.DoAction(MoveLeft);
            moveRightCD.DoAction(MoveRight);
            blockCD.DoAction(Block);
            notBlockingCD.DoAction(DontBlock);
        }
    }

    public void MoveLeft()
    {
        rb2d.velocity = Vector2.left * moveSpeed;
    }

    public void MoveRight()
    {
        rb2d.velocity = Vector2.right * moveSpeed;
    }

    public void Block()
    {
        shield.gameObject.SetActive(true);
    }
    public void DontBlock()
    {
        shield.gameObject.SetActive(false);
    }
}
