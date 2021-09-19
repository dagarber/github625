using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubjectRedBird : SubjectBeingObserved
{
    private bool HIT = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("EXPLODE")) { return; }

        if (other.gameObject.CompareTag("LOSE"))
        {
            Notify(this.gameObject, NotificationType.Lose, HIT);
            return;
        }
        Notify(this.gameObject, NotificationType.RedBird, HIT);
        //Debug.Log("Level1 " + HIT);
        HIT = true;
    }
}
