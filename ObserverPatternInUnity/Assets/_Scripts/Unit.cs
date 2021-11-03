using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{

    protected int damagePower;

    protected int health;

    public abstract void test();

    public int getDamagePower()
    {

        return damagePower;

    }

    public int getHealth()
    {

        return health;

    }

    public virtual void attack() { }
    // virtual causes the lowest level implementation of this class override to execute


    public virtual void defend() { }


    public abstract void repair();


    public abstract void die();

    public void newFunction() { }


}