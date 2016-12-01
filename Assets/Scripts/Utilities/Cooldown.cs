using UnityEngine;
using System.Collections;

public class Cooldown {

    float remainingCDTime;

    public bool IsOnCoolDown
    {
        get
        {
            return remainingCDTime > 0;
        }
    }

    public void Update()
    {
        if(IsOnCoolDown)
        {
            remainingCDTime -= Time.deltaTime;
        }
    }

    public void Start(float time)
    {
        remainingCDTime = time;
    }
}
