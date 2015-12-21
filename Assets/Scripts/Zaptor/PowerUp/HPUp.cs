using UnityEngine;
using System.Collections;

public class HPUp : MonoBehaviour {

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
            if (other.gameObject.GetComponent<Controller>().hp <= 90)
            {
                other.gameObject.GetComponent<Controller>().hp += 10;
            }
            else
            {
                other.gameObject.GetComponent<Controller>().hp = 100;
            }

            Destroy(gameObject);
        }
    }
}
