using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeCubeShape : Shapes
{
    public override void move()
    {
        //do something
    }

    public override string whoAmII()
    {
        return "orange cube";
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
