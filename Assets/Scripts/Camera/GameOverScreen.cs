using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScreen : MonoBehaviour {

    public float totalIntensityTime = 2f;

    EnemyCountDownScript eCD;
    BWEffect bwEffect;
    UtilityManager util;

    private void Start()
    {
        bwEffect = FindObjectOfType<BWEffect>();
        util = new UtilityManager();
        eCD = new EnemyCountDownScript(1f, 1f, 2f, 2f);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            CheckpointManager.Instance.isDead = true;
        }
        if (CheckpointManager.Instance.isDead)
        {
            eCD.DoAction(DoBWeffect);
            if (bwEffect.intensity >= 1)
            {
                //TODO: ADD GAME OVER SCREEN

                CheckpointManager.Instance.isDead = false;
                eCD.ResetTimer();
            }
        }
        else if (!CheckpointManager.Instance.isDead)
        {
            bwEffect.intensity = 0f;
            util.curLerpTime = 0f;
        }
    }

    void DoBWeffect()
    {
        bwEffect.intensity = util.LerpTime(0f, 1f, totalIntensityTime);
    }

}
