using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireGun : MonoBehaviour
{
    public float speed = 40;
    public GameObject bullet;
    public Transform barrel;
    public AudioSource audioSource;
    public AudioClip audioClip;
    public Text bulletText;

    private int bulletCount = 25;

    // Start is called before the first frame update
    void Start()
    {
        bulletText.text = bulletCount.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fire()
    {
        if (bulletCount > 0)
        {
            GameObject spawnedBullet = Instantiate(bullet, barrel.position + new Vector3(0, 0, 0), barrel.rotation);
            spawnedBullet.GetComponent<Rigidbody>().velocity = speed * -1.0f * barrel.up;
            audioSource.PlayOneShot(audioClip);
            Destroy(spawnedBullet, 2);
        }
        bulletCount--;
        if (bulletCount < 0)
        {
            bulletCount = 0;
            bulletText.color = Color.red;
            Destroy(this.gameObject, 2);
        }

        bulletText.text = bulletCount.ToString();

    }
}
