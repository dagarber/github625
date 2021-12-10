using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawnMove : MonoBehaviour
{
    public GameObject center;
    public float angularVelocity = 1.0f; // set in editor
    //float radius;
    float angle;
    //float tempAngle;

    // Start is called before the first frame update
    void Start()
    {
        //radius = Vector3.Distance(transform.position, center.transform.position);
        angle = 0f;
        //tempAngle = angle;
    }

    // Update is called once per frame
    void Update()
    {
        angle += angularVelocity * Time.deltaTime; // * 180.0f/ Mathf.PI;

        transform.RotateAround(center.transform.position, Vector3.up, angle);
        
        //tempAngle += angularVelocity * Time.fixedDeltaTime * 180.0f / Mathf.PI;

        /*if (angle < 90)
        {
            Move(angle);
        }
        else if(angle < 180)
        {
            if (tempAngle > 90)
                tempAngle -= 90;
            Move(tempAngle);

        }
        else if(angle < 270)
        {
            if (tempAngle > 90)
                tempAngle -= 90;
            Move(tempAngle);

        }
        else if(angle < 360)
        {
            if (tempAngle > 90)
                tempAngle -= 90;
            Move(tempAngle);

        }
        else
        {
            angle -= 360;
            tempAngle = angle;
            Move(angle);
        }*/


    }

    /*private void Move(float theta)
    {
        float z = radius * Mathf.Cos(theta * Mathf.PI/180.0f) - center.transform.position.z;
        float x = radius * Mathf.Sin(theta * Mathf.PI/180.0f) - center.transform.position.x;
        transform.position = new Vector3(x, transform.position.y, z);
        transform.LookAt(center.transform);
    }*/
}
