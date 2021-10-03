using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
            transform.position = Vector3.Lerp(transform.position, transform.position + transform.forward * speed * Time.deltaTime, Time.deltaTime*10.0f);

        if (Input.GetKey(KeyCode.DownArrow))
            transform.position = Vector3.Lerp(transform.position, transform.position + transform.forward * -1 * speed * Time.deltaTime, Time.deltaTime*10.0f);

        if (Input.GetKey(KeyCode.LeftArrow))
            transform.position = Vector3.Lerp(transform.position, transform.position + transform.right * -1 * speed * Time.deltaTime, Time.deltaTime*10.0f);

        if (Input.GetKey(KeyCode.RightArrow))
            transform.position = Vector3.Lerp(transform.position, transform.position + transform.right * speed * Time.deltaTime, Time.deltaTime*10.0f);

        if (Input.GetKeyDown(KeyCode.D))
        {
            GameObject go = Repository.Return();
            float x=1.0f;
            float z=1.0f;
            //float min = 1;
            //float max = 2;
            float posneg = Random.Range(-1.0f, 1.0f);
            //Debug.Log("posneg " + posneg);
            if (posneg > 0)
            {
                //x = Random.Range(min, max);
            }
            else
            {
                //x = Random.Range(-1*min, -1*max);
                x = -x;
            }
            posneg = Random.Range(-1.0f, 1.0f);
            if (posneg > 0)
            {
                //z = Random.Range(min, max);
            }
            else
            {
                //z = Random.Range(-1*min, -1*max);
                z = -z;
            }

            go.transform.position = this.transform.position + new Vector3(x, 0, z);
            go.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            Repository.List();
        }

    }
}
