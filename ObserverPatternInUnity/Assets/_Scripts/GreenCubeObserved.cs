using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenCubeObserved : SubjectBeingObserved
{
    private void OnTriggerEnter(Collider other)
    {
        Notify(this, NotificationType.GreenCubeCollected);       
    }

}
