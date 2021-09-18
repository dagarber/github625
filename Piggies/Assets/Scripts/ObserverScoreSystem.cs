using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObserverScoreSystem : MonoBehaviour, Observer
{
    private int score = 0;
    public Text scoreText;

    public void OnNotify(object obj, NotificationType notificationType, bool bol)
    {

        if (bol) { return; }
        //Debug.Log("Current Score " + score);

        if (notificationType == NotificationType.Level1Hit)
        {
            score += 1;
            //Debug.Log("Plus One " + score);
        }
        if (notificationType == NotificationType.Level2Hit)
        {
            score += 2;
            //Debug.Log("Plus Two " + score);
        }
        if (notificationType == NotificationType.Level3Hit)
        {
            score += 3;
            //Debug.Log("Plus Three " + score);
        }
        //Debug.Log("New score: " + score);
        scoreText.text = score.ToString();
        


    }

    void Start()
    {
        scoreText.text = score.ToString();
        foreach (SubjectBeingObserved subject in FindObjectsOfType<SubjectBeingObserved>())
        {
            subject.AddObserver(this);
        }

    }

}
