using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Observer_Score : MonoBehaviour, Observer
{
    public Text pigText;
    public Text birdText;
    private int pigScore = 0;
    private int pigCounter = 0;
    private int birdScore = 0;
    private int birdCounter = 0;
    private int count = 0;
    public Canvas canvas;
    public GameObject PigLauncher;
    public GameObject BirdLauncher;
    public GameObject FlareGun;
    public Transform Saber;
    public int pigThresh = 1;
    public int birdThresh = 2;

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
            GameObject bonusGun = Instantiate(FlareGun);
            // Gets the local scale of game object
            Vector3 objectScale = Saber.transform.localScale;
            // Sets the local scale of game object
            Saber.transform.localScale = new Vector3(objectScale.x * 1.0f, objectScale.y * 1.2f, objectScale.z * 1.0f);
        }



    }

    IEnumerator Reload()
    {
        canvas.gameObject.SetActive(true);
        yield return new WaitForSeconds(4.0f);
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
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
