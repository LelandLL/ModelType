using UnityEngine;
using System.Collections;

public class LazerProj : MonoBehaviour {

    public int dmg;

    private float speed = 8.5f;


    // Update is called once per frame
    void Update()
    {
        // translate
        transform.Translate(new Vector3(0f, -1f, 0f) * speed * Time.deltaTime);

        // destroy the projectile once it's out of screen
        if (transform.position.y <= -10)
            Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        //print ("Collided w/ " + other.gameObject.tag);
        if (other.gameObject.tag == "Player")
        {
            //print ("lazer on collision enter!");
            //print ("hit player");
            other.gameObject.GetComponent<Controller>().hp -= dmg;
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Enemy") return;

    }
}
