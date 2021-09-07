using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiggieDestroyer : MonoBehaviour
{
    private Transform piggieStart;
    private Vector2 piggieStartPos;
    public float DESTROY_DIST_SQ = 50;

    // Start is called before the first frame update
    void Start()
    {
        Transform piggieStart = transform;
        piggieStartPos = new Vector2(transform.position.x, transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 currentPos = new Vector2(transform.position.x, transform.position.y);
        Vector2 direction = currentPos - piggieStartPos;
        float distanceSquared = direction.sqrMagnitude;
        //Debug.Log("PiggieStart Current Dist DistSq " + piggieStartPos + currentPos + direction + distanceSquared);
        if (distanceSquared > DESTROY_DIST_SQ)
        {
           // Destroy();
        }

    }

    void Destroy()
    {
        Destroy(this); //  this.Destroy();
    }
}
