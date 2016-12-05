using UnityEngine;
using System.Collections;

public class PlayerAnimController : MonoBehaviour
{

    tk2dSpriteAnimator anim;
    PlayablePlayer thePlayer;
    Controller2D controller;

    bool walking = false;

    void Start()
    {
        anim = GetComponent<tk2dSpriteAnimator>();
        thePlayer = GetComponent<PlayablePlayer>();
        controller = GetComponent<Controller2D>();
    }

    void Update()
    {
        if (controller.collisions.below)
        {
            //walk
            if (thePlayer.input.x != 0)
            {
                if (!anim.IsPlaying("PlayerWalkCycle"))
                {
                    anim.Play("PlayerWalkCycle");
                    anim.AnimationCompleted = null;
                    walking = true;
                }
            } //run
            else
            {
                //anim.Play("idle");
                anim.AnimationCompleted = null;
                walking = false;
                
            }
            //run and shoot straight


            ////jump
            //if (!controller.collisions.below)
            //{
            //    //jump
            //    if (!anim.IsPlaying("jump"))
            //    {
            //        anim.Play("jump");
            //        anim.AnimationCompleted = null;
            //    }

            //    //jump shoot up
            //    if (!anim.IsPlaying("jumpShootUp") && controller.canShootUp && input.GetButtonDown("Shoot"))
            //    {
            //        anim.Play("jumpShootUp");
            //        anim.AnimationCompleted = null;
            //    }//jump shoot
            //    if (!anim.IsPlaying("jumpShoot") && controller.canShootStraight && input.GetButtonDown("Shoot"))
            //    {
            //        anim.Play("jumpShoot");
            //        anim.AnimationCompleted = null;
            //    }
            //    //jump shoot down
            //    if (!anim.IsPlaying("jumpShootDown") && controller.canShootDown && input.GetButtonDown("Shoot"))
            //    {
            //        anim.Play("jumpShootDown");
            //        anim.AnimationCompleted = null;
            //    }

            //}

        }

    }
}
