using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subject_BowlingBall : SubjectBeingObserved
{
    private void OnTriggerEnter(Collider other)
    {
        //string s = "hello";
        Notify(this.gameObject, NotificationType.BowledTwice);
        //Notify(s, NotificationType.ItemAdded);
    }

}
