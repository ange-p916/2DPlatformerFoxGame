using UnityEngine;
using System.Collections;

public class AttackScript : MonoBehaviour {

    public int attkCcounter = 0;
    public bool activateCounter;

    public float timer;

    public BoxCollider2D swordCol;

    void Start()
    {

    }

    public void Update()
    {
        if(activateCounter)
        {
            timer -= Time.deltaTime;
        }
        if(timer <= 0)
        {
            activateCounter = false;
        }

        if(Input.GetKeyDown(KeyCode.K))
        {
            activateCounter = true;
        }
    }
}
