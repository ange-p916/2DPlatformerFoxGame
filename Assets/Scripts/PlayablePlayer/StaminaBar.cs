using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour {

    //public float totalTime = 3.5f;
    public bool hasBeenAltered = false;
    
    public Slider stamina;
    EnemyCountDownScript eCD;
    public float currentStamina = 100f;
    public float regenRate = 2f;
    public float curLerpTime;
    public float lerpTime;

    void Start()
    {
        eCD = new EnemyCountDownScript(1.3f, 1.3f, 1f, 1f);
    }

    /*
        when pressing a button
        wait a bit, like 2 seconds
        then begin to increase again
    */

    void Update()
    {
        
        if((Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.L) || Input.GetKeyDown(KeyCode.K)) && hasBeenAltered)
        {
            curLerpTime = 0f;
            eCD.ResetTimer();
        }
        else
        {
            if (hasBeenAltered)
            {
                eCD.DoAction(DoStuff);
            }
        }



        //currentStamina = Mathf.Clamp(currentStamina, 0, 100f);
        //if(currentStamina >= 0 && currentStamina <= 100f)
        //{
        //    curLerpTime += Time.deltaTime;
        //    if(curLerpTime > lerpTime)
        //    {
        //        curLerpTime = lerpTime;
        //    }

            //    float perc = curLerpTime / lerpTime;
            //    currentStamina += Mathf.SmoothStep(currentStamina, 100f, perc);
            //}
    }

    void DoStuff()
    {
        currentStamina = Mathf.Clamp(currentStamina, 0, 100f);
        
        curLerpTime += Time.deltaTime;
        if (curLerpTime > lerpTime)
        {
            curLerpTime = lerpTime;
        }

        float perc = curLerpTime / lerpTime;
        
        currentStamina = Mathf.SmoothStep(currentStamina, 100f, perc);
            
        
    }

}
