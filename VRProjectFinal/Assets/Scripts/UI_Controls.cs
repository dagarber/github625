﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_Controls : MonoBehaviour
{
    public Canvas canvas;
    private float timer = 0f;
    public Text countdownText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        int intTime = (int)Mathf.Floor(timer);
        //Debug.Log("Time to launch " + timeToLaunch + " " + intTimeToLaunch);
        countdownText.text = intTime.ToString();

    }

    public void ResetScene(bool bol)
    {
        StartCoroutine(Reload());
    }

    IEnumerator Reload()
    {
        canvas.gameObject.SetActive(true);
        yield return new WaitForSeconds(4.0f);
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
    }
}
