using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereReset : MonoBehaviour
{

    private Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {

        startPos = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x > 2 || transform.position.z > 2)
        {
            transform.position = startPos;
            GetComponent<Rigidbody>().velocity = new Vector3(0f,0f,0f);
            GetComponent<Rigidbody>().angularVelocity = new Vector3(0f,0f,0f);
		}
        
    }
}
