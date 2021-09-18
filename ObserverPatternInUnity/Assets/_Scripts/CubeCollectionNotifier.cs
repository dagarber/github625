using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CubeCollectionNotifier : MonoBehaviour
{
    public static event Action<CubeCollectionNotifier> OnCubeColleted;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (OnCubeColleted != null)
        {
            OnCubeColleted(this);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
