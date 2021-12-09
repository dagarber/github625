using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGun : MonoBehaviour
{
    public float speed = 40;
    public GameObject bullet;
    public Transform barrel;
    public AudioSource audioSource;
    public AudioClip audioClip;

    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fire()
    {
        GameObject spawnedBullet = Instantiate(bullet, barrel.position + new Vector3(0,0,0), barrel.rotation);
        spawnedBullet.GetComponent<Rigidbody>().velocity = speed * -1.0f * barrel.up;
        audioSource.PlayOneShot(audioClip);
        Destroy(spawnedBullet, 2);
    }
}
