using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shark : Singleton<Shark>
{
    public bool catchTrigger;
    public bool hasTriggered;

    private void Update()
    {
        if (catchTrigger && !hasTriggered)
        {
            //Catch the player
            Player.main.transform.parent = gameObject.transform;
            hasTriggered = true;
        }

        if (catchTrigger)
        {
            Player.main.transform.localPosition = Vector3.zero;
        }
    }
}
