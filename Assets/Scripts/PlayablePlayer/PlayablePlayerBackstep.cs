using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayablePlayerBackstep : MonoBehaviour {

    public Text directionText;
    public Text dashDirText;

    [Header("quickstep values")]
    public float QSWhileWalking;
    public float QSWhileStanding;

    [Header("Other values")]
    public float cooldown = 0.4f;
    public float t = 0f;
    public bool startEasing = false;
    public float rollTime = 0.3f;
    public float stamCost = 20f;
    PlayablePlayer player;
    Cooldown cd;
    StaminaBar stam;
    PlayablePlayerDashScript dash;

    void Start()
    {
        dash = GetComponent<PlayablePlayerDashScript>();
        player = GetComponent<PlayablePlayer>();
        cd = new Cooldown();
        stam = GetComponent<StaminaBar>();
    }

    void Update()
    {
        stam.stamina.value = stam.currentStamina;
        DodgeRollAnyDir();
        cd.Update();
    }

    public void DodgeRollAnyDir()
    {
        var mInput = Input.GetAxis("Horizontal");
        
        if (Input.GetKeyDown(KeyCode.J))
        {
            if (!cd.IsOnCoolDown && stam.currentStamina >= stamCost && !dash.startEasing) // if we're not on cooldown
            {
                stam.currentStamina -= stamCost;
                t = 0f;
                startEasing = true;
                cd.Start(cooldown); //start cooldown
            }
            
        }

        if (startEasing)
        {
            player.velocity.x = 0f;
            stam.currentStamina = Mathf.Clamp(stam.currentStamina, 0, 100f);
            while (t < rollTime)
            {
                t += Time.deltaTime;

                if(player.input.x != 0) //while walking
                {
                    if (player.lookRight)
                    {
                        dashDirText.text = "dashing left";
                        player.moveSpeed -= mInput * QSWhileWalking;
                    }
                    else if (!player.lookRight)
                    {
                        dashDirText.text = "dashing right";
                        player.moveSpeed += mInput * QSWhileWalking;
                    }
                }
                else if(player.input.x == 0) //while standing still
                {
                    if (player.lookRight)
                    {
                        player.velocity.x -= QSWhileStanding;
                    }
                    else if (!player.lookRight)
                    {
                        player.velocity.x += QSWhileStanding;
                    }
                }
                break;
                
            }
            if (t >= rollTime)
            {
                t = 0f;
                player.moveSpeed = 5f;
                player.velocity.x = 0f;
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
