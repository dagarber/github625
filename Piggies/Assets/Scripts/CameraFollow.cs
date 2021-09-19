using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        GameObject[] GOs = GameObject.FindGameObjectsWithTag("Player");
        int length = GOs.Length;
        //for (int i = 0; i < 1; i++) // GOs.Length
        //{
            float x = GOs[length - 1].transform.position.x;
            //float y = GOs[i].transform.position.y;
            //float myX = transform.position.x;
            //float myY = transform.position.y;
            Vector3 target = new Vector3(x + 14.649f, transform.position.y, transform.position.z);
            //Vector3 me = new Vector2(myX, myY);
            //Debug.Log(transform.position);
            //transform.position = Vector2.Lerp(me, target, Time.deltaTime);
            transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime/50.0f);
        //}

    }
}
