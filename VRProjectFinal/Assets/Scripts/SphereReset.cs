using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereReset : SubjectBeingObserved
{

    private int count = 0;

    private float timeCount = 0;

    private Vector3 startPos;

    private int score = 0;

    private int totalScore = 0;

    // Start is called before the first frame update
    void Start()
    {

        startPos = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach(Observer obv in _observers)
        {
            if(obv.checkFell())
            {
               score++;
			}
		}

        if(transform.position.x > 2 || transform.position.z > 2 || timeCount > 4.0f || score > 5)
        {
            transform.position = startPos;
            GetComponent<Rigidbody>().velocity = new Vector3(0f,0f,0f);
            GetComponent<Rigidbody>().angularVelocity = new Vector3(0f,0f,0f);

            count++;
            timeCount = 0;

            if (score > 5)
            {
                totalScore++;
                Debug.Log("YOUR SCORE IS: " + totalScore);
            }

            if (count>1)
            {
                Notify(this.gameObject, NotificationType.BowledTwice);
                count = 0;
		    }

            //Debug.Log("Score " + score);


		}

        score = 0;

        if(transform.position.y < 0.173)
        {
            timeCount += Time.deltaTime;
		}

    }
}
