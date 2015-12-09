using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {

    public GameObject bullet;
    public float timeBetweenShots = 0.3f;
    public bool isEnemy = false;
    private float timeStamp;

    // Update is called once per frame
    void Update()
    {
        if (isEnemy && Time.time >= timeStamp)
        {
            Instantiate(bullet, transform.position, transform.rotation);
            timeStamp = Time.time + timeBetweenShots;
        }
        else
        {
            if (Time.time >= timeStamp && Input.GetButton("Fire1"))
            {
                Instantiate(bullet, transform.position, transform.rotation);
                timeStamp = Time.time + timeBetweenShots;
            }
        }
    }
}
