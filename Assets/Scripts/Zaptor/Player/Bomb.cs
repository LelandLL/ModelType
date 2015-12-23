using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour {
    Vector3 startMarker;
    Vector3 endMarker;
    private float speed;
    private float startTime;
    private float journeyLength;
    public float journeyTime;

    private bool playSound = false;
    public GameObject expl;

    // Use this for initialization
    void Start()
    {
        startTime = Time.time;
        startMarker = new Vector3(transform.position.x, transform.position.y, 0);
        endMarker = new Vector3(0.078f, -0.089f, 0f);
        journeyLength = Vector3.Distance(startMarker, endMarker);
        speed = journeyLength / journeyTime;

    }

    // Update is called once per frame
    void Update()
    {
        float distCovered = (Time.time - startTime) * speed;
        float fracJourney = distCovered / journeyLength;
        transform.position = Vector3.Lerp(startMarker, endMarker, fracJourney);
        //transform.Rotate(new Vector3(1f, 0f, 0f) , 320*Time.deltaTime);
        transform.Rotate(Vector2.right, 20 * Time.deltaTime);

        // explosion effect
        if (playSound == false && Time.time - startTime >= journeyTime - 0.35f)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Bombard>().play();
            playSound = true;
        }

        if (transform.position == endMarker)
        {
            // destroy the bomb
            Instantiate(expl, transform.position, transform.rotation);
            Destroy(gameObject, 0.05f);
            GameObject.Find("Main Camera").GetComponent<ShakeCamera>().ShaketheCamera();

            // destroy all enemy units
            foreach (GameObject o in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                switch (o.gameObject.name)
                {
                    case "L1Enemy(Clone)":
                        o.GetComponent<Lv1Enemy>().Kill();
                        break;
                    case "L2Enemy(Clone)":
                        o.GetComponent<Lv2Enemy>().Kill();
                        break;
                    case "L3Enemy(Clone)":
                        o.GetComponent<Lv3Enemy>().Kill();
                        break;
                }
            }
        }
    }
}
