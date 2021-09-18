using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubjectLevel2Hit : SubjectBeingObserved
{
    private bool HIT = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        Notify(this, NotificationType.Level2Hit, HIT);
        //Debug.Log("Level2 " + HIT);
        HIT = true;
    }

}
