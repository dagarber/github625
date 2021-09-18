using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSystem : MonoBehaviour, Observer
{
    private int score = 0;

    public void OnNotify(object obj, NotificationType notificationType)
    {
        if (notificationType == NotificationType.GreenCubeCollected)
        {
            score += 1;
        }
        if (notificationType == NotificationType.RedCubeCollected)
        {
            score += 2;
        }
        if (notificationType == NotificationType.OrangeCubeCollected)
        {
            score += 3;
        }
        Debug.Log("New score: " + score);
    }

    void Start()
    {
        foreach (SubjectBeingObserved subject in FindObjectsOfType<SubjectBeingObserved>())
        {
            subject.AddObserver(this);
        }
    }

}
