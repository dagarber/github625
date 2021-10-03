using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSystem : MonoBehaviour, Observer
{
    private int score = 0;

    public void OnNotify(GameObject obj, NotificationType notificationType)
    {
        if (notificationType == NotificationType.GreenCubeCollected)
        {
            score += 1;
            GreenCubeShape g = obj.GetComponent<GreenCubeShape>();
            Repository.Add(g);
            obj.SetActive(false);
            //obj.GetComponent<MeshRenderer>().enabled = false;
            //obj.GetComponent<BoxCollider>().enabled = false;
            //Repository.List();
        }
        if (notificationType == NotificationType.RedCubeCollected)
        {
            score += 2;
            RedCubeShape r = obj.GetComponent<RedCubeShape>();
            Repository.Add(r);
            obj.SetActive(false);
            //obj.GetComponent<MeshRenderer>().enabled = false;
            //obj.GetComponent<BoxCollider>().enabled = false;
            //Repository.List();
        }
        if (notificationType == NotificationType.OrangeCubeCollected)
        {
            score += 3;
            OrangeCubeShape o = obj.GetComponent<OrangeCubeShape>();
            Repository.Add(o);
            obj.SetActive(false);
            //obj.GetComponent<MeshRenderer>().enabled = false;
            //obj.GetComponent<BoxCollider>().enabled = false;
            //Repository.List();
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
