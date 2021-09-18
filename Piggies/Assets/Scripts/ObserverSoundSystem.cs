using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObserverSoundSystem : MonoBehaviour, Observer
{


    public void OnNotify(object obj, NotificationType notificationType, bool bol)
    {
        Debug.Log("Ping!");

    }


    void Start()
    {
        foreach (SubjectBeingObserved subject in FindObjectsOfType<SubjectBeingObserved>())
        {
            subject.AddObserver(this);
        }
    }

}
