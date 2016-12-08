using UnityEngine;
using System.Collections;

public class EnemyJumpingScript : MonoBehaviour {

    public LayerMask WhatIsGround;

    public enum JumpMachine { LEFT, RIGHT };
    public JumpMachine jumps;

    public float jumpLeftTimer;
    public float jumpRightTimer;


    [Header("jump variables")]
    public float countDownTimeToJump;
    public float newCDJump;
    public float timeIsJumping;
    public bool isJumping = false;

    public float jumpSpeedX;
    public float jumpSpeedY;

    public void StartJumpingInPlace(Rigidbody2D rb2d)
    {
        if (jumpLeftTimer <= 0)
        {
            jumps = JumpMachine.RIGHT;
            jumpLeftTimer = 2f;
        }
        if (jumpRightTimer <= 0)
        {
            jumps = JumpMachine.LEFT;
            jumpRightTimer = 2f;
        }


        if (jumps == JumpMachine.LEFT)
        {
            JumpLeftOrRight(Vector2.left, rb2d);
            jumpLeftTimer -= Time.deltaTime;
        }

        if (jumps == JumpMachine.RIGHT)
        {
            JumpLeftOrRight(Vector2.right, rb2d);
            jumpRightTimer -= Time.deltaTime;
        }
        
    }

    void JumpLeftOrRight(Vector2 direction, Rigidbody2D rb2d)
    {

        transform.localScale = (direction.x > 0) ? new Vector3(1f, 1f, 1f) : new Vector3(-1f, 1f, 1f);

        var grounded = Physics2D.Raycast(transform.position, Vector2.down, 1f, WhatIsGround);
        if (grounded)
        {
            countDownTimeToJump -= Time.deltaTime;
        }
        if (countDownTimeToJump <= 0)
        {

            isJumping = true;
            timeIsJumping -= Time.deltaTime;

            if (isJumping)
            {
                rb2d.velocity = new Vector2(direction.x * jumpSpeedX, jumpSpeedY);
            }
            if (timeIsJumping <= 0)
            {
                isJumping = false;
                countDownTimeToJump = newCDJump;
            }

            if (!isJumping && countDownTimeToJump >= 0)
            {
                timeIsJumping = 0.1f;
            }
        }
    }
}