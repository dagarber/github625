using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubjectBlackBird : SubjectBeingObserved
{
    public GameObject explosion;
    private GameObject explodeObj;
    private bool HIT = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("EXPLODE")) { return; }

        if (other.gameObject.CompareTag("LOSE"))
        {
            Notify(this.gameObject, NotificationType.Lose, HIT);
            return;
        }
        Notify(this.gameObject, NotificationType.BlackBird, HIT);
        //Debug.Log("Level1 " + HIT);
        HIT = true;
        explodeObj = Instantiate(explosion, transform.position, Quaternion.identity);
        explodeObj.SetActive(true);
        Destroy(explodeObj, 1);
        //Debug.Log("Boom");
        gameObject.SetActive(false);
    }
}
