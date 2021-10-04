using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenCubeObserved : SubjectBeingObserved
{
    private void OnTriggerEnter(Collider other)
    {
        //string s = "hello";
        Notify(this.gameObject, NotificationType.GreenCubeCollected);
        //Notify(s, NotificationType.ItemAdded);
    }

}
