using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpherePosition : MonoBehaviour
{

    //public GameObject sphere;
    private Renderer rend;
    private float size = 1.0f;
    private float sizeOrig;
    private float factor = 0.5f;
    private float factor2 = 0.0f;
    private float r1 = 1.0f;
    private float g1 = 0f;
    private float b1 = 0f;
    private float r2 = 0f;
    private float g2 = 1.0f;
    private float b2 = 0f;
    private int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        //rend = GetComponent<Renderer>();
        rend = this.GetComponent<Renderer>();
        sizeOrig = size;
        factor2 = 2.0f * factor;

        
    }

    private void Awake()
    {
        size = 1.0f;
        sizeOrig = size;
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 point;
        Vector3 color1;
        Vector3 color2;

        //if(sphere != null)
        //{
            if(count < 2)
            {
                point = new Vector3(1.0f, size, 1.0f);
                color1 = new Vector3(r1, g1, b1);
                color2 = new Vector3(r2, g2, b2);
                this.GetComponent<BoxCollider>().size = new Vector3(1.0f, size, 1.0f);
            }
            else if (count < 4)
            {
                point = new Vector3(size, 1.0f, 1.0f);
                color1 = new Vector3(r1, b1, g1);
                color2 = new Vector3(b2, g2, r2);
                this.GetComponent<BoxCollider>().size = new Vector3(size, 1.0f, 1.0f);
            }
            else
            {
                point = new Vector3(1.0f, 1.0f, size);
                color1 = new Vector3(r1, g1, b1);
                color2 = new Vector3(r2, g2, r2);
                this.GetComponent<BoxCollider>().size = new Vector3(1.0f, 1.0f, size);
            }

            //rend.sharedMaterial.SetVector(name: "_Point", sphere.transform.position);
            rend.material.SetVector(name: "_Point", point);
            rend.material.SetVector(name: "_ColorNear", color1);
            rend.material.SetVector(name: "_ColorFar", color2);

            size = size - (size * factor * Time.fixedDeltaTime);
            b1 = b1 + factor2 * Time.fixedDeltaTime;
            r2 = r2 + factor2 * Time.fixedDeltaTime;

            if(count >= 4)
            {
                r1 = r1 - factor2 * Time.fixedDeltaTime;
                g2 = g2 - factor2 * Time.fixedDeltaTime;
            }

            if (size < 0.5 * sizeOrig || size > sizeOrig)
            {
                factor = -1.0f * factor;
                factor2 = -1.0f * factor2;
                size = size - (size * factor * Time.fixedDeltaTime);
                b1 = b1 + factor2 * Time.fixedDeltaTime;
                r2 = r2 + factor2 * Time.fixedDeltaTime;
                count++;

                if (count >= 4)
                {
                    r1 = r1 - factor2 * Time.fixedDeltaTime;
                    g2 = g2 - factor2 * Time.fixedDeltaTime;
                }

                if (count > 5)
                {
                    count = 0;
                }
            }


        //}

    }
}
