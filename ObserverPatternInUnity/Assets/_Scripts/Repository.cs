using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repository : MonoBehaviour
{

    private static List<Shapes> pickUps = new List<Shapes>();

    public static void Add(Shapes s)
    {
        pickUps.Add(s);
        string color = s.whoAmII();
        Debug.Log(color);
    }

    public static void Remove(Shapes s)
    {
        pickUps.Remove(s);
    }

    public static GameObject Return()
    {
        int i = pickUps.Count - 1;
        GameObject go = pickUps[i].gameObject;
        pickUps.RemoveAt(i);
        return go;
    }

    public static void List()
    {
        for(int i=0; i < pickUps.Count; i++)
        {
            int write = i + 1;
            Debug.Log("Inventory " + write + " " + pickUps[i].whoAmII());
        }

    }


}
