using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    //private Vector3 mouseInWorld;
    //member variable that would persist outside the function

    public Camera camera;
    public Transform mouseCube;
    public Rigidbody2D piggie;

    // Start is called before the first frame update
    void Start()
    {
        //camera = GameObject.Find("MainCamera").GetComponent<Camera>(); // or replace Camera with Transform
        //shortcut for GetComponent<Transform> is just .transform
        //this is very slow, maybe 3nanoseconds... but it's fine to do that in start
        piggie.gravityScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Input.mousePosition // Vector2 (x,y)
        //Input.mousePosition.x // horizontal from upper left
        //Input.mousePosition.y // vertical from upper left
        //where is the cannon?
        //in any 2D game, the object is on 0 in the z axis (doesn't matter where you put it)
        //camera is at position -10 z, mouse is at position (x,y)

        //Camera.screenToWorldPoint
        //screen is the position of our camera view
        //"ray casting" - there is a long line coming from the mouse into infinity
        //moving the mouse, the line moves orthogonally to the screen
        //what we want is the point in our world, not on the screen

        Vector3 pointInWorld = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -camera.transform.position.z);
        //Debug.Log("Mouse position: " + pointInWorld);

        Vector3 mouseInWorld = camera.ScreenToWorldPoint(pointInWorld);
        //Debug.Log("Position in world: " + mouseInWorld);

        transform.LookAt(mouseInWorld);

        if(Input.GetMouseButton(0))
        {
            piggie.gravityScale = 1;
            piggie.transform.parent = null;

            Vector3 temp = mouseInWorld - transform.position;

            Vector2 directionAndMagnitudeOfForce = new Vector2(temp.x, temp.y);
            piggie.AddForce(directionAndMagnitudeOfForce*30);
            //piggie.AddForce(mouseInWorld - transform.position);
            //piggie.AddForce(Vector2.up * 200);
        }



        //mouseCube.transform.position = mouseInWorld;

        //  new Vector3(Input.mousePosition.x,Input.mousePosition.y, -camera.transform.position.z));
        //think of Vector3 as a point
        //declared a local variable (inside the function) deleted after function exit

        //Vector3 mouseInWorld = Camera.main.ScreenToWorldPoint();

    }
}
