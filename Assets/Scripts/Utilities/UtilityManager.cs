using UnityEngine;
using System.Collections;

public class UtilityManager {

    public float curLerpTime = 0f;

	public Vector3 StartLerping(Vector3 pA, Vector3 pB, float lerpTime)
    {
        curLerpTime += Time.deltaTime;
        if (curLerpTime > lerpTime)
        {
            curLerpTime = lerpTime;
        }
        float percentage = curLerpTime / lerpTime;

       return Vector3.Lerp(pA, pB, percentage);
    }
}
