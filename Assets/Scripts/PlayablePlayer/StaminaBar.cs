using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour {

    public Slider stamina;
    public float currentStamina = 100f;
    public float regenRate = 2f;

    void Update()
    {
        currentStamina = Mathf.Clamp(currentStamina, 0, 100f);
        if(currentStamina >= 0 && currentStamina <= 100f)
        {
            currentStamina += regenRate * Time.deltaTime;
        }
    }
}
