using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTrigger : SubjectBeingObserved
{
    private bool counted = false;
    public ConstantForce gravity;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Rigidbody>().useGravity = false;
        gravity = gameObject.AddComponent<ConstantForce>();
        gravity.force = new Vector3(0.0f, -1.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!counted)
        {
            if (gameObject.name.Contains("PigCube"))
                Notify(this.gameObject, NotificationType.PigHit);
            else if (gameObject.name.Contains("RedBirdCube"))
            {
                Notify(this.gameObject, NotificationType.BirdHit);
            }
            counted = true;

        }

            if (other.gameObject.name == "Saber")
            Debug.Log("Saber!");
        else if (other.gameObject.name == "Bullet")
            Debug.Log("Flare gun!");
        else if (other.gameObject.name == "Left Hand" || other.gameObject.name == "Right Hand")
            Debug.Log("Hand!");
        //Debug.Log("Name is " + other.gameObject.name);
        Debug.Log("The subject name is " + gameObject.name);
        GameObject.Destroy(this.gameObject);
    }
}
