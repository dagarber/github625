using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class Observer_Score : MonoBehaviour, Observer
{
    public XRDirectInteractor rHand;
    public XRDirectInteractor lHand;
    public Text pigText;
    public Text birdText;
    public Canvas canvas;
    public GameObject PigLauncher;
    public GameObject BirdLauncher;
    public GameObject FlareGun;
    public Transform Saber;
    public Transform Saber2;
    public int pigThresh = 1;
    public int birdThresh = 2;
    public float saberGrowth = 0.1f;

    private int pigScore = 0;
    private int pigCounter = 0;
    private int birdScore = 0;
    private int birdCounter = 0;
    private int count = 0;
    private int gunCount = 1;

    public void OnNotify(GameObject obj, NotificationType notificationType)
    {
        if (notificationType == NotificationType.PigHit)
        {
            pigScore++;
            pigText.text = pigScore.ToString();
            pigCounter++;
            if(pigCounter > pigThresh)
            {
                PigLauncher.GetComponent<CubeSpawner>().LaunchBonus();
                pigCounter = 0;
            }

        }

        if (notificationType == NotificationType.BirdHit)
        {
            birdScore++;
            birdText.text = birdScore.ToString();
            birdCounter++;
            if (birdCounter > birdThresh)
            {
                BirdLauncher.GetComponent<CubeSpawner>().LaunchBonus();
                birdCounter = 0;
            }
        }

        if (notificationType == NotificationType.FellDown)
        {
            count++;
            if(count > 3)
                StartCoroutine(Reload());
        }

        if (notificationType == NotificationType.Bonus)
        {
            //do stuff
            if(gunCount < 5)
            {
                GameObject bonusGun = Instantiate(FlareGun);
                gunCount++;
            }

            // Gets the local scale of game object
            Vector3 objectScale = Saber.transform.localScale;
            Vector3 objectPos = Saber.transform.localPosition;
            Vector3 objectScale2 = Saber2.transform.localScale;
            Vector3 objectPos2 = Saber2.transform.localPosition;
            // Sets the local scale of game object
            //Saber.transform.localScale = new Vector3(objectScale.x * 1.0f, objectScale.y * 1.2f, objectScale.z * 1.0f);
            //Saber.transform.localPosition = new Vector3(objectPos.x, objectPos.y + objectScale.y * 0.1f, objectPos.z);
            //Saber2.transform.localScale = new Vector3(objectScale2.x * 1.0f, objectScale2.y * 1.2f, objectScale2.z * 1.0f);
            //Saber2.transform.localPosition = new Vector3(objectPos2.x, objectPos2.y - objectScale2.y * 0.1f, objectPos2.z);

            Saber.transform.localScale = new Vector3(objectScale.x * 1.0f, objectScale.y + saberGrowth, objectScale.z * 1.0f);
            Saber.transform.localPosition = new Vector3(objectPos.x, objectPos.y + saberGrowth * 1.0f, objectPos.z);
            Saber2.transform.localScale = new Vector3(objectScale2.x * 1.0f, objectScale2.y + saberGrowth, objectScale2.z * 1.0f);
            Saber2.transform.localPosition = new Vector3(objectPos2.x, objectPos2.y - saberGrowth * 1.0f, objectPos2.z);
        }



    }

    IEnumerator Reload()
    {
        canvas.gameObject.SetActive(true);
        yield return new WaitForSeconds(10.0f);
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
    }

    public void DeleteGun()
    {
        gunCount--;

        if (rHand.selectTarget.tag == "Saber")
        {
            // do nothing
        }
        else if (rHand.selectTarget.tag == "Gun")
        {
            //rHand.Drop();
            //Debug.Log("Count is " + rHand.selectTarget.GetComponent<FireGun>().GetCount());
            if (rHand.selectTarget.GetComponent<FireGun>().GetCount() == 0)
            {
                //Debug.Log("True");
                rHand.enableInteractions = false;
                //Destroy(rHand.selectTarget.GetComponent<XRGrabInteractable>());
                StartCoroutine(ReEnableGrab(rHand));
                //return;
            }
            //else
                //Debug.Log("False, count is " + rHand.selectTarget.GetComponent<FireGun>().GetCount());
            //return;
        }

        if (lHand.selectTarget.tag == "Saber")
        {
            // do nothing
        }
        else if (lHand.selectTarget.tag == "Gun")
        {
            //rHand.Drop();
            if (lHand.selectTarget.GetComponent<FireGun>().GetCount() == 0)
            {
                lHand.enableInteractions = false;
                //Destroy(lHand.selectTarget.GetComponent<XRGrabInteractable>());
                StartCoroutine(ReEnableGrab(rHand));
                //return;
            }
            //return;
        }


    }

    IEnumerator ReEnableGrab(XRDirectInteractor hand)
    {
        yield return new WaitForSeconds(1.0f);
        hand.enableInteractions = true;
    }

    public bool checkFell()
    {
        bool temp = false;
        return temp;
        // do stuff
    }

    public void OnNotify(string s, NotificationType notificationType)
    {
        // do stuff
    }

    // Start is called before the first frame update
    void Start()
    {
        foreach (SubjectBeingObserved subject in FindObjectsOfType<SubjectBeingObserved>())
        {
            subject.AddObserver(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (SubjectBeingObserved subject in FindObjectsOfType<SubjectBeingObserved>())
        {
            subject.AddObserver(this);
        }
    }
}
