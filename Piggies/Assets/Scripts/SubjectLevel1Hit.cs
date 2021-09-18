using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubjectLevel1Hit : SubjectBeingObserved
{
    private bool HIT = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        Notify(this, NotificationType.Level1Hit, HIT);
        //Debug.Log("Level1 " + HIT);
        HIT = true;
    }

}
