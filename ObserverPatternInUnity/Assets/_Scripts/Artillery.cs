using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artillery : Unit
{

    public override void attack()
    {
        Debug.Log("Do Something Else");
        damagePower = 15;
    }

    public override void defend()
    {
        Debug.Log("Do Something Else");
        health = 2;
    }

    public override void repair()
    {
        Debug.Log("Do Something Else");
    }

    public override void die()
    {
        Debug.Log("Do Something Else");
    }

    public override void test()
    {
        throw new System.NotImplementedException();
    }
}
