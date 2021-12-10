using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Observer_Score : MonoBehaviour, Observer
{
    public Text pigText;
    public Text birdText;
    private int pigScore = 0;
    private int birdScore = 0;

    public void OnNotify(GameObject obj, NotificationType notificationType)
    {
        if (notificationType == NotificationType.PigHit)
        {
            pigScore++;
            pigText.text = pigScore.ToString();

        }

        if (notificationType == NotificationType.BirdHit)
        {
            birdScore++;
            birdText.text = birdScore.ToString();
        }

    }

    public bool checkFell()
    {
        bool temp = false;
        return temp;
        // do stuff
    }

    public void OnNotify(string s, NotificationType notificationType)
    {
        // do stuff
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
        foreach (SubjectBeingObserved subject in FindObjectsOfType<SubjectBeingObserved>())
        {
            subject.AddObserver(this);
        }
    }
}
