using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class CannonController : MonoBehaviour
{
    //private Vector3 mouseInWorld;
    //member variable that would persist outside the function

    public Camera camera;
    public Transform mouseCube;
    public Rigidbody2D piggieRigidBody;
    public GameObject piggie;
    //public Text scoreText;
    //private static int score = 0;

    private float piggiePosX;
    private float piggiePosY;
    private float hyp;
    private float ang;
    private GameObject newPiggie;
    private bool MOUSE_DOWN = false;

    public float MAX_ANGLE = 80;
    public float MIN_ANGLE_POS = 0;
    public float MIN_ANGLE_NEG = -5;
    public float CANNON_POWER = 70;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        //camera = GameObject.Find("MainCamera").GetComponent<Camera>(); // or replace Camera with Transform
        //shortcut for GetComponent<Transform> is just .transform
        //this is very slow, maybe 3nanoseconds... but it's fine to do that in start
        piggieRigidBody.gravityScale = 0;
        piggiePosX = piggie.transform.localPosition.x;
        piggiePosY = piggie.transform.localPosition.y;
        hyp = new Vector2(piggiePosX, piggiePosY).magnitude;
        ang = Mathf.Atan(piggiePosY / piggiePosX)*Mathf.Rad2Deg;
        //Debug.Log("PiggieStart X Y " + piggiePosX + piggiePosY);
        //piggieTransform = piggieRigidBody.transform;
        //scoreText.text = score.ToString();
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
        
        Vector3 direction = mouseInWorld - transform.position;
        
        float angleOfCannon = Mathf.Acos(Vector3.Dot(Vector3.right, direction.normalized)) * Mathf.Rad2Deg;
        //Debug.Log("Angle of Cannon: " + angleOfCannon);

        if (angleOfCannon <= MAX_ANGLE && angleOfCannon >= MIN_ANGLE_POS && direction.y > 0)
        {
            transform.rotation = Quaternion.Euler(0,0,angleOfCannon);
        }
        else if (Mathf.Abs(angleOfCannon) <= Mathf.Abs(MIN_ANGLE_NEG) && Mathf.Abs(angleOfCannon) >= 0 && direction.y < 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, -angleOfCannon);
        }

        //transform.LookAt(mouseInWorld);

        if(Input.GetMouseButtonUp(0))
        {
            MOUSE_DOWN = false;
        }

        if(Input.GetMouseButton(0) && piggieRigidBody.transform.parent != null && MOUSE_DOWN == false)
        {
            piggieRigidBody.gravityScale = 1;
            piggieRigidBody.transform.parent = null;
            Vector2 directionAndMagnitudeOfForce = new Vector2(direction.x, direction.y); // .normalized;
            // don't normalize, distance away controls power level
            piggieRigidBody.AddForce(directionAndMagnitudeOfForce*CANNON_POWER);
            Destroy(piggie, 2); // wait until after the new piggie is created before destroying the old one
            MOUSE_DOWN = true;
            StartCoroutine(SpawnPiggie());
            //score++;
            //scoreText.text = score.ToString();


        }

        mouseCube.transform.position = mouseInWorld;

    }

    IEnumerator SpawnPiggie()
    {
        yield return new WaitForSeconds(1.0f); // must be shorter than the Destroy time above
        Vector3 piggiePos = new Vector3(piggiePosX * Mathf.Cos(transform.rotation.z), piggiePosY * Mathf.Sin(transform.rotation.z), 0);
        Quaternion piggieRot = Quaternion.Euler(0, 0, 0);
        newPiggie = Instantiate(piggie, transform.localPosition + piggiePos, piggieRot, transform);
        piggie = newPiggie;
        piggieRigidBody = piggie.GetComponent<Rigidbody2D>();
        piggieRigidBody.transform.parent = this.transform;
        piggieRigidBody.gravityScale = 0;
        piggie.transform.localPosition = new Vector3(piggiePosX, piggiePosY, 0);
        piggie.transform.localRotation = Quaternion.Euler(0, 0, 0);
    }

    void WaitForSecondsRealtime(int t)
    {

    }
}
