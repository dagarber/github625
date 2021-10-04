using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repository : MonoBehaviour // RepoBeingObserved
{

    private static List<Shapes> pickUps = new List<Shapes>();

    //private static void toNotify()
    //{
    //    string s = "hi";
    //    Notify(s, NotificationType.ItemAdded);
    //}

    public static void Add(Shapes s)
    {
        //Repository repo = new Repository();
        pickUps.Add(s);
        string color = s.whoAmII();
        //Debug.Log(color);
        //repo.Notify(color, NotificationType.ItemAdded);
        //Repository.toNotify();
    }

    public static void Remove(Shapes s)
    {
        //Repository repo = new Repository();
        pickUps.Remove(s);
        string color = s.whoAmII();
        s.toDrop();
        //Debug.Log(color);
        //repo.Notify(color, NotificationType.ItemDropped);
    }

    public static Shapes Return()
    {
        int i = pickUps.Count - 1;
        Shapes go = pickUps[i];
        //pickUps.RemoveAt(i);
        Remove(go);
        return go;
    }

    public static string List()
    {
        string s = null;
        for(int i=0; i < pickUps.Count; i++)
        {
            int write = i + 1;
            Debug.Log("Inventory " + write + " " + pickUps[i].whoAmII());
            if(s==null)
            {
                s = pickUps[i].whoAmII();
            }
            else
            {
                s = s + " \n" + pickUps[i].whoAmII();
            }
        }
        return s;

    }


}
