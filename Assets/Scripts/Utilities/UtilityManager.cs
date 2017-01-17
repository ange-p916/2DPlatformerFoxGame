using UnityEngine;
using System.Collections;

public class UtilityManager {

    public float curLerpTime = 0f;

    float elapsed = 0f;
    float duration = 0.4f;
    float magnitude = 0.4f;

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

    public IEnumerator DoTheShake(Camera tcam)
    {
        //mcam.enabled = false;
        Vector3 originalCamPos = tcam.transform.position;

        while(elapsed < duration)
        {
            elapsed += Time.deltaTime;

            float perc = elapsed / duration;

            float damper = 1f - Mathf.Clamp(4f * perc - 3f, 0f, 1f);

            float x = Random.value * 1.5f - 1f;
            float y = Random.value * 1.5f - 1f;

            x *= magnitude * damper;
            y *= magnitude * damper;

            tcam.transform.position = new Vector3(tcam.transform.position.x + x, tcam.transform.position.y + y, -10f);
            yield return null;
        }
        elapsed = 0f;
        tcam.transform.position = originalCamPos;
        //mcam.enabled = true;
    }

}
