using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_Controls : MonoBehaviour
{
    public Canvas canvas;
    public Canvas levelUpCanvas;
    public float levelUp = 30.0f; // set in inspector
    public Text countdownText;
    public Slider piggieRate;
    public Slider birdRate;
    //public bool levelUpBol = false;

    private float timer = 0f;
    private float counter = 0f;
    private bool sceneReset = false;

    // Start is called before the first frame update
    void Start()
    {
        //levelUpBol = false;
    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;
        timer += Time.deltaTime;

        //Debug.Log("Timer is " + timer + ", Counter is " + counter);

        if(counter > levelUp)
        {
            piggieRate.value += 0.1f;
            birdRate.value += 0.1f;

            if (!sceneReset)
            {
                //Debug.Log("Hello!");
                StartCoroutine(LevelUp());
            }
            counter = 0;

        }

        int intTime = (int)Mathf.Floor(timer);
        //Debug.Log("Time to launch " + timeToLaunch + " " + intTimeToLaunch);
        countdownText.text = intTime.ToString();

    }

    public void ResetScene(bool bol)
    {
        sceneReset = true;
        StartCoroutine(Reload());
    }


    IEnumerator LevelUp()
    {
        float temp = 0.1f;
        int n = 0;
        while(++n < 5)
        {
            levelUpCanvas.gameObject.SetActive(true);
            yield return new WaitForSeconds(temp);
            levelUpCanvas.gameObject.SetActive(false);
            yield return new WaitForSeconds(temp);
        }


    }

    IEnumerator Reload()
    {
        levelUpCanvas.gameObject.SetActive(false);
        canvas.gameObject.SetActive(true);
        yield return new WaitForSeconds(4.0f);
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
    }
}
