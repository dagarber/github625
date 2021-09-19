using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObserverSoundSystem : MonoBehaviour, Observer
{


    public void OnNotify(object obj, NotificationType notificationType, bool bol)
    {
        //Debug.Log("Ping!");

        if (notificationType == NotificationType.Level1Hit | notificationType == NotificationType.Level2Hit | notificationType == NotificationType.Level3Hit)
        {
            Debug.Log("Ping!");
        }

        if (notificationType == NotificationType.YellowBird | notificationType == NotificationType.RedBird)
        {
            Debug.Log("POW!");
        }
        if (notificationType == NotificationType.BlackBird)
        {
            Debug.Log("BOOM!");
        }

    }


    void Start()
    {
        foreach (SubjectBeingObserved subject in FindObjectsOfType<SubjectBeingObserved>())
        {
            subject.AddObserver(this);
        }
    }

}
