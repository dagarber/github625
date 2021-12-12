using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FellDown : SubjectBeingObserved
{

    private Vector3 startPos;
    private Vector3 startRot;
    public bool fellDown = false;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        startRot = transform.eulerAngles; // rotation.EulerAngles;

    }

    // Update is called once per frame
    void Update()
    {
        float angle = Vector3.Angle(transform.up, Vector3.up);
        if (angle > 30)
        {
            if (!fellDown)
            {
                Notify(this.gameObject, NotificationType.FellDown);
            }

            fellDown = true;

        }

    }
}
