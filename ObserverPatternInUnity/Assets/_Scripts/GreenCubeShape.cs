using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenCubeShape : Shapes
{
    //private string color = "green";
    //Shapes.color = "green";
    //numCorners = 4;

    public GreenCubeShape()
    {
        color = "green";
    }

    public override void move()
    {
        //do something
    }

    public override string whoAmII()
    {

        //color = "green";
        //Debug.Log("green");
        string gtext = "green cube";
        return gtext;
    }

    private void OnTriggerEnter(Collider other)
    {
        string s = whoAmII();
        //string s = "hello";
        //Notify(this.gameObject, NotificationType.GreenCubeCollected);
        Notify(s, NotificationType.ItemAdded);
    }

    public override void toDrop()
    {
        string s = whoAmII();
        Notify(s, NotificationType.ItemDropped);
    }


}
