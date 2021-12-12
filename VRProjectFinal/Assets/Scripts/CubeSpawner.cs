using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeSpawner : MonoBehaviour
{
    public float speed = 40;
    public GameObject bullet;
    public GameObject bonus;
    public Transform barrel;
    public AudioSource audioSource;
    public AudioClip audioClip;
    public float timer = 0f;
    public float launchRate = 1.0f;
    public float constant = 1.0f;
    public float destroyTime = 6.0f;
    public bool launchBool = true;
    public Text countdownText;

    private bool launchBonusBol = true; // false;

    // Start is called before the first frame update
    void Start()
    {
        launchBonusBol = false;

    }

    public void LaunchBonus()
    {
        launchBonusBol = true;
    }


    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > constant/launchRate)
        {
            if(launchBool)
            {
                Fire();
            }
            timer = 0;
        }

        float timeToLaunch = -1.0f*(timer - constant / launchRate);
        int intTimeToLaunch = (int)Mathf.Ceil(timeToLaunch);
        //Debug.Log("Time to launch " + timeToLaunch + " " + intTimeToLaunch);
        //countdownText.text = intTimeToLaunch.ToString();
        if(timeToLaunch < 1.0f)
            countdownText.color = Color.red;
        else
            countdownText.color = Color.black;

    }

    public void Fire()
    {
        //Debug.Log("BOOM");
        if (!launchBonusBol)
        {
            GameObject spawnedBullet = Instantiate(bullet, barrel.position + new Vector3(0, 0, 0), barrel.rotation);
            spawnedBullet.GetComponent<Rigidbody>().velocity = speed * 1.0f * barrel.forward; // right;
            audioSource.PlayOneShot(audioClip);
            Destroy(spawnedBullet, destroyTime);
        }
        else
        {
            GameObject spawnedBullet = Instantiate(bonus, barrel.position + new Vector3(0, 0, 0), barrel.rotation);
            spawnedBullet.GetComponent<Rigidbody>().velocity = speed * 1.0f * barrel.forward; // right;
            audioSource.PlayOneShot(audioClip);
            Destroy(spawnedBullet, destroyTime);
            launchBonusBol = false;
        }


    }

    public void ChangeRate(float newRate)
    {
        Debug.Log("Old rate was " + launchRate + ", New rate is " + newRate);
        launchRate = newRate;
    }

    public void DisableLaunch(bool bol)
    {
        launchBool = bol;
    }
}
