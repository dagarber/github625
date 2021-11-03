using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : Unit
{

    public override void attack()
    {
        Debug.Log("Do Something");
        damagePower = 10;
    }

    public override void defend()
    {
        Debug.Log("Do Something");
        health = 1;
    }

    public override void repair()
    {
        Debug.Log("Do Something");
    }

    public override void die()
    {
        Debug.Log("Do Something");
    }

    public void newFunction() // override
    {
        //test
    }

    public void newFunction(int i) // overload
    {
        i = 0;
    }

    public override void test()
    {
        throw new System.NotImplementedException();
    }
}
