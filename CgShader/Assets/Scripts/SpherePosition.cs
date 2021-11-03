using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpherePosition : MonoBehaviour
{

    public GameObject sphere;
    private Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();

        
    }

    // Update is called once per frame
    void Update()
    {
        if(sphere != null)
        {
            rend.sharedMaterial.SetVector(name: "_Point", sphere.transform.position);
        }
        
    }
}
