using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer_Pins : MonoBehaviour, Observer
{
    private Vector3 startPos;
    private Vector3 startRot;
    public bool fellDown = false;

    public void OnNotify(GameObject obj, NotificationType notificationType)
    {
        if (notificationType == NotificationType.BowledTwice)
        {
            transform.position = startPos;
            transform.eulerAngles = startRot;
            GetComponent<Rigidbody>().velocity = new Vector3(0f,0f,0f);
            GetComponent<Rigidbody>().angularVelocity = new Vector3(0f,0f,0f);
            fellDown = false;

        }
       
    }

    public bool checkFell()
    {
        return fellDown;
	}

    public void OnNotify(string s, NotificationType notificationType)
    {
        // do stuff
    }

    void Start()
    {
        startPos = transform.position;
        startRot = transform.eulerAngles; // rotation.EulerAngles;

        foreach (SubjectBeingObserved subject in FindObjectsOfType<SubjectBeingObserved>())
        {
            subject.AddObserver(this);
        }

    }

    void Update()
    {
        float angle = Vector3.Angle(transform.up, Vector3.up);
        if(angle > 15)
        {
            if(!fellDown)
            {
                 //Debug.Log("Angle " + angle);     
			}

            fellDown = true;  

		}
	}

}
