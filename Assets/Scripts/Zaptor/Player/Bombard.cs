using UnityEngine;
using System.Collections;

public class Bombard : MonoBehaviour {

    public GameObject bomb;

    private bool justFired;
    private float timeElapsed, cooldown;

    // Use this for initialization
    void Start()
    {
        justFired = false;
        timeElapsed = 0f;
        cooldown = 3.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (justFired == true)
        {
            timeElapsed += Time.deltaTime;
            if (timeElapsed >= cooldown)
                justFired = false;
        }

        if (Input.GetButtonDown("Fire2") && !justFired && !Pause.gamePaused &&
           GameObject.FindGameObjectWithTag("Player").GetComponent<Controller>().bombCount > 0
           )
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Controller>().bombCount--;
            Instantiate(bomb, transform.position, new Quaternion());
            justFired = true;
            timeElapsed = 0f;
        }

    }

    public void play()
    {
        GetComponent<AudioSource>().Play();
    }
}
