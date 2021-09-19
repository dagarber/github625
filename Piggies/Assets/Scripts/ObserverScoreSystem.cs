using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ObserverScoreSystem : MonoBehaviour, Observer
{
    private int score;
    public Text scoreText;
    public Text winText;
    public Text loseText;
    private int win = 0;
    private int win_score = 3;
    public GameObject SCORE_REMAIN;
    public GameObject victoryPig;
    private GameObject newPiggie;
    private bool WINBOOL = false;
    private float timer = 0;
    private int counter = 0;

    public void OnNotify(object obj, NotificationType notificationType, bool bol)
    {

        if (bol) { return; }
        //Debug.Log("Current Score " + score);

        if (notificationType == NotificationType.Lose)
        {
            loseText.gameObject.SetActive(true);
            SCORE_REMAIN.GetComponent<DontDestroyScore>().ChangeScore(0);
            StartCoroutine(Reload());
        }

        if (notificationType == NotificationType.Level1Hit)
        {
            //score += 1;
            //Debug.Log("Plus One " + score);
        }
        if (notificationType == NotificationType.Level2Hit)
        {
            //score += 2;
            //Debug.Log("Plus Two " + score);
        }
        if (notificationType == NotificationType.Level3Hit)
        {
            //score += 3;
            //Debug.Log("Plus Three " + score);
        }

        if (notificationType == NotificationType.YellowBird)
        {
            score += 50;
            win++;
            Destroy((Object)obj);
            //Debug.Log("Plus One " + score);
        }
        if (notificationType == NotificationType.RedBird)
        {
            score += 20;
            win++;
            Destroy((Object)obj);
            //Debug.Log("Plus Two " + score);
        }
        if (notificationType == NotificationType.BlackBird)
        {
            score += 30;
            win++;
            //Destroy((Object)obj);
            //Debug.Log("Plus Three " + score);
        }

        //Debug.Log("New score: " + score);
        scoreText.text = score.ToString();

        if (win == win_score)
        {
            winText.gameObject.SetActive(true);
            SCORE_REMAIN.GetComponent<DontDestroyScore>().ChangeScore(score);
            //Debug.Log("End score: " + score);
            StartCoroutine(LoadNew());
        }



    }

    void Start()
    {
        //Debug.Log("Begin score: " + score);
        score = SCORE_REMAIN.GetComponent<DontDestroyScore>().GetScore();
        //Debug.Log("Begin score: " + score);
        scoreText.text = score.ToString();
        foreach (SubjectBeingObserved subject in FindObjectsOfType<SubjectBeingObserved>())
        {
            subject.AddObserver(this);
        }

    }

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(3.0f);
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
    }

    IEnumerator LoadNew()
    {
        yield return new WaitForSeconds(3.0f);
        Scene scene = SceneManager.GetActiveScene(); //SceneManager.LoadScene(scene.name);
        if(scene.name == "SampleScene")
        {
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Scene2");
            // Wait until the asynchronous scene fully loads
            while (!asyncLoad.isDone)
            {
                yield return null;
            }
        }
        if (scene.name == "Scene2")
        {
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Scene3");
            // Wait until the asynchronous scene fully loads
            while (!asyncLoad.isDone)
            {
                yield return null;
            }
        }
        else
        {
            victoryPig.SetActive(true);
            WINBOOL = true;

            //for(int i=0; i<10; i++)
            //{
            //    StartCoroutine(SpawnPiggie());
            //}

        }

    }

    IEnumerator SpawnPiggie()
    {
        yield return new WaitForSeconds(1);
        int x = Random.Range(-13, 13);
        int y = Random.Range(-5, 5);
        Vector3 rand = new Vector3(x, y, victoryPig.transform.position.z);
        newPiggie = Instantiate(victoryPig, rand, victoryPig.transform.rotation);
    }

    IEnumerator Reset()
    {
        yield return new WaitForSeconds(1.0f);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("SampleScene");
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }


void Update()
    {
        if(WINBOOL)
        {
            if(timer == 0)
            {
                StartCoroutine(SpawnPiggie());
            }

            timer += Time.deltaTime;

            if(timer > 1)
            {
                StartCoroutine(SpawnPiggie());
                timer = 0.1f;
                counter++;
            }
        }

        if(counter>7)
        {
            WINBOOL = false;
            timer = 0;
            counter = 0;
            StartCoroutine(Reset());

        }

    }
}
