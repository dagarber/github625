using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUISystem : MonoBehaviour, Observer
{
 
    public void OnNotify(GameObject obj, NotificationType notificationType)
    {
//do stuff
    }

    public void OnNotify(string s, NotificationType notificationType)
    {
        string st = Repository.List();
        Text UIText = this.GetComponent<Text>();
        UIText.text = st;
    }

    void Start()
    {
        foreach (SubjectBeingObserved subject in FindObjectsOfType<SubjectBeingObserved>())
        {
            subject.AddObserver(this);
        }
    }

}

