using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour {

    public float totalTime = 3.5f;

    public Slider stamina;
    public float currentStamina = 100f;
    public float regenRate = 2f;

    void Update()
    {
        //sqrt(currStam)*.03

        currentStamina = Mathf.Clamp(currentStamina, 0, 100f);
        if (currentStamina >= 0 && currentStamina <= 100f)
        {
            currentStamina = Mathf.SmoothStep(currentStamina, 100f, totalTime * Time.deltaTime);
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
        //    currentStamina += Mathf.SmoothStep(0f, 100f, perc);
        //}
    }
}
