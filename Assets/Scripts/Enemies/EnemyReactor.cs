using UnityEngine;
using System.Collections;

public class EnemyReactor : MonoBehaviour {

    public delegate void ActionHandler(EnemyReactor e);
    public ActionHandler OnHappen;

    public void Happened(EnemyReactor e)
    {
        if(OnHappen != null)
        {
            OnHappen(e);
        }
    }

    public void ReactToAttack()
    {
        print("jumped");
    }

    public void ReactToDash()
    {
        print("dashed towards player");
    }

    public void ReactToJump()
    {
        print("jumped");
    }

    void Start()
    {

    }
}
