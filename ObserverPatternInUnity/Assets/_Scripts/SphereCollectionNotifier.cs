using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SphereCollectionNotifier : MonoBehaviour
{
    public static event Action<string> OnSphereCollected;
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        if (OnSphereCollected != null)
        {
            OnSphereCollected("sphere " + gameObject.name + "was collected");
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
