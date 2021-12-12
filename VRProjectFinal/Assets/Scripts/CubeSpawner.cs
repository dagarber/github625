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
    public bool MOVING = false; // set in editor

    private bool launchBonusBol = true; // false;
    private Vector3 startPos;
    private Vector3 startRot;

    // Start is called before the first frame update
    void Start()
    {
        launchBonusBol = false;
        startPos = transform.position;
        startRot = transform.eulerAngles;

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
                if(MOVING)
                {
                    startPos = transform.position;
                    startRot = transform.eulerAngles;
                }
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

        //float temp = NextFloat(-1.0f, 1.0f);
        //Debug.Log("Random float is " + temp);

        //float p1 = NextFloat(-1.0f, 1.0f);
        float p2 = NextFloat(-0.3f, 0.3f);
        //float p3 = NextFloat(-1.0f, 1.0f);
        float r1 = NextFloat(-2.0f, 0.0f);
        float r2 = NextFloat(-2.0f, 2.0f);
        //float r3 = NextFloat(-1.0f, 1.0f);

        transform.position = new Vector3(transform.position.x, transform.position.y + p2, transform.position.z);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x + r1, transform.eulerAngles.y + r2, transform.eulerAngles.z);
        //Debug.Log("X (up/down) rotation is " + transform.eulerAngles.x + ", with an added rotation of " + r1);
        //Debug.Log("Y (left/right) rotation is " + transform.eulerAngles.y + ", with an added rotation of " + r2);

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

        transform.position = startPos;
        transform.eulerAngles = startRot;


    }

    public float NextFloat(float min, float max)
    {
        System.Random random = new System.Random();
        double val = (random.NextDouble() * (max - min) + min);
        return (float)val;
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
