using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedCubeObserved : SubjectBeingObserved
{
    private void OnTriggerEnter(Collider other)
    {
        Notify(this, NotificationType.RedCubeCollected);
    }
}
