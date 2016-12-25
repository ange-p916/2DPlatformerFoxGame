using UnityEngine;
using System.Collections;

public class AttackScript : MonoBehaviour {

    Cooldown cd;
    StaminaBar stam;
    public int attkCounter = 0;
    public bool activateCounter;

    public float stamCost;

    public float timer = 2f;
    public float newTimer = 2f;
    public float secondTimer, thirdTimer;

    public BoxCollider2D swordCol;

    void Start()
    {
        cd = new Cooldown();
        stam = GetComponent<StaminaBar>();
    }

    public void Update()
    {
        var attkButton = Input.GetKeyDown(KeyCode.K);
        cd.Update();

        if (attkButton)
        {
            activateCounter = true;
            if (attkCounter < 3 && !cd.IsOnCoolDown) //cd on cooldown is the animation time here
            {
                stam.currentStamina -= stamCost;
                stam.hasBeenAltered = true;
                timer = newTimer;
                cd.Start(1f);
                attkCounter++;
            }
            if(attkCounter == 3)
            {
                activateCounter = false;
                timer = newTimer;
                attkCounter = 0;
            }
        }

        if(activateCounter)
        {
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                attkCounter = 0;
                activateCounter = false;
            }
        }
    }
}
