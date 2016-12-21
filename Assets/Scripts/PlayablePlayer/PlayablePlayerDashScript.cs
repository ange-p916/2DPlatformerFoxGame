using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//using Rewired;

public class PlayablePlayerDashScript : MonoBehaviour
{
    [Header("dash values")]
    public float maxDash;
    public float curDash;


    [Header("Other values")]
    public float cooldown = 0.4f;
    public float t = 0f;
    public bool startEasing = false;
    public float rollTime = 0.3f;
    public float stamCost = 20f;
    PlayablePlayer player;
    Cooldown cd;
    //Player controllerInput;
    Controller2D controller2d;
    PlayerHealthController phc;
    StaminaBar stam;
    PlayablePlayerBackstep step;
    void Start()
    {
        phc = GetComponent<PlayerHealthController>();
        stam = FindObjectOfType<StaminaBar>();
        player = GetComponent<PlayablePlayer>();
        cd = new Cooldown();
        // = ReInput.players.GetPlayer(0);
        controller2d = GetComponent<Controller2D>();
        step = GetComponent<PlayablePlayerBackstep>();
    }

    void Update()
    {
        DodgeRollAnyDir();
        cd.Update();
    }

    public void DodgeRollAnyDir()
    {
        /*
        units = input stam * max units / dash cost

        if stam >= 20
        stam -= 20
        else
        x = stam
        and x = 20 first case
        */

        //var mInput = controllerInput.GetAxis("Move Horizontal");

        //curDash = stamCost * maxDash / stamCost;
        curDash = stam.currentStamina * maxDash / 100f;

        if (Input.GetKeyDown(KeyCode.L))
        {
            if (!cd.IsOnCoolDown && !step.startEasing) // if we're not on cooldown
            {
                print(curDash);

                if(stam.currentStamina >= stamCost)
                {
                    stam.currentStamina -= stamCost;
                }
                else if(stam.currentStamina < stamCost)
                {
                    stamCost = stam.currentStamina;
                }
                if(stam.currentStamina >= 20f)
                {
                    stamCost = 20f;
                }
                
                t = 0f;
                startEasing = true;
                phc.isInvincible = true;
                cd.Start(cooldown); //start cooldown
            }

        }

        if (startEasing)
        {
            while (t < rollTime)
            {
                t += Time.deltaTime;

                if (player.input.x != 0) //while walking
                {
                    if (player.lookRight)
                    {
                       controller2d.Move(new Vector3(curDash, 0f), player.input);
                    }
                    else if (!player.lookRight)
                    {
                        controller2d.Move(new Vector3(-curDash, 0f), player.input);
                    }
                }
                else if (player.input.x == 0) //while standing still
                {
                    if (player.lookRight)
                    {
                        controller2d.Move(new Vector3(curDash, 0f), player.input);
                    }
                    else if (!player.lookRight)
                    {
                        controller2d.Move(new Vector3(-curDash, 0f), player.input);
                    }
                }
                break;

            }
            if (t >= rollTime)
            {
                t = 0f;
                //player.moveSpeed = 5f;
                //player.velocity.x = 0f;
                phc.isInvincible = false;
                startEasing = false;
            }
        }
    }

    float QuadEaseOut(float curTime, float startVal, float changeInVal, float duration)
    {
        /*
            curTime = t;
            startVal = b;
            changeInVal = c;
            duration = d;
        */

        curTime /= duration;
        return changeInVal * (curTime * curTime) + startVal;
    }

}
