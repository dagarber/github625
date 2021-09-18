using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeCubeObserved : SubjectBeingObserved
{
    private void OnTriggerEnter(Collider other)
    {
        Notify(this, NotificationType.OrangeCubeCollected);
    }
}
