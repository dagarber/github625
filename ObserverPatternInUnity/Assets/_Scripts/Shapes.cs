using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Shapes : SubjectBeingObserved
{
    protected string color;

    public int numCorners;
    private int numSides;
    private float weight;


    public abstract void move();

    public abstract string whoAmII();

    public abstract void toDrop();




}
