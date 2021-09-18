using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementSystem : MonoBehaviour, Observer
{

    public void OnNotify(object obj, NotificationType notificationType)
    {
        if (notificationType == NotificationType.GreenCubeCollected)
        {
            Debug.Log(message: "You achieved something!");
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        foreach (SubjectBeingObserved subject in FindObjectsOfType<SubjectBeingObserved>())
        {
            subject.AddObserver(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

 

}
