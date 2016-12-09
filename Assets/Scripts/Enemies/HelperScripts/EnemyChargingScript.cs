using UnityEngine;
using System.Collections;

public class EnemyChargingScript : MonoBehaviour {

    public bool countDownStart = false;
    public bool isCharging = false;
    
    public float chargeSpeed;
    public float countdownTimeToCharge;

    public float newCDCharge;
    [Tooltip("the time this dude is charging")]
    public float timeIsCharging;
    public float newChargeTimer;

    public void Charge(Vector2 whatSideIsPlayerAt,Rigidbody2D rb2d)
    {
        countdownTimeToCharge -= Time.deltaTime;
        if (countdownTimeToCharge <= 0)
        {
            isCharging = true;
            timeIsCharging -= Time.deltaTime;
            if (isCharging)
            {
                transform.localScale = new Vector3(whatSideIsPlayerAt.x * 1f, 1f, 1f);
                rb2d.velocity = whatSideIsPlayerAt * chargeSpeed;
            }
            if (timeIsCharging <= 0)
            {
                isCharging = false;
                countdownTimeToCharge = newCDCharge;
            }
            if (!isCharging && countdownTimeToCharge >= 0)
            {
                timeIsCharging = newChargeTimer;
            }
        }
    }
}
