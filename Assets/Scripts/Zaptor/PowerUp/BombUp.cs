using UnityEngine;
using System.Collections;

public class BombUp : MonoBehaviour {

    public float speed;
    public float rotationSpeed;


    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0f, rotationSpeed * Time.deltaTime, 0f));
        transform.Translate(0f, speed * Time.deltaTime, 0f);

        if (transform.position.y < -12f)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (other.gameObject.GetComponent<Controller>().bombCount < 5)
            {
                other.gameObject.GetComponent<Controller>().bombCount++;
            }
            else
            {
                Controller.score += 50;
            }

            Destroy(gameObject);
        }
    }
}
