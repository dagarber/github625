using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubjectLevel3Hit : SubjectBeingObserved
{
    private bool HIT = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        Notify(this, NotificationType.Level3Hit, HIT);
        //Debug.Log("Level3 " + HIT);
        HIT = true;
    }

}
