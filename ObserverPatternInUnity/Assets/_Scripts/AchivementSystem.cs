using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchivementSystem : MonoBehaviour, Observer
{
 
    public void OnNotify(GameObject obj, NotificationType notificationType)
    {
        if (notificationType == NotificationType.GreenCubeCollected)
        {
            //Debug.Log("Congrats! You unlocked an achievement!");
        }
    }

    public void OnNotify(string s, NotificationType notificationType)
    {
        if (notificationType == NotificationType.ItemAdded)
        {
            Debug.Log("You picked up the " + s);
        }
        if (notificationType == NotificationType.ItemDropped)
        {
            Debug.Log("You dropped the " + s);
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

