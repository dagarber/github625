using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Timer : MonoBehaviour
{
    private float timer = 0f;
    public Text countdownText;

    private
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        int intTime = (int)Mathf.Ceil(timer);
        //Debug.Log("Time to launch " + timeToLaunch + " " + intTimeToLaunch);
        countdownText.text = intTime.ToString();

    }
}
