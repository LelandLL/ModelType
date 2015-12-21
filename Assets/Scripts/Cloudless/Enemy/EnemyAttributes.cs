using UnityEngine;
using System.Collections;

public class EnemyAttributes : MonoBehaviour {
    public int health = 10;
    public int pattern;
    public float speed;
    Animator anim;
    Material mat;
    Material originalMat;
    public GameObject powerUp;
    public GameObject coin;
    public int powerUpChance;
    public int creditsChance;
    public int scoreValue = 500;

    Color[] colors = { Color.yellow, Color.red };
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        mat = GetComponent<SpriteRenderer>().material;
        powerUpChance = Random.Range(0, powerUpChance);
        creditsChance = Random.Range(0, creditsChance);
        //myManager = GetComponent<GameManager>();

        //source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            if (powerUpChance == 0)
            {
                Instantiate(powerUp, transform.position, transform.rotation);
            }
            if (creditsChance == 0)
            {
                Instantiate(coin, transform.position, transform.rotation);
            }
            //audio.PlayOneShot(source.clip);
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Bullet" || col.tag == "Player")
        {
            if (health <= 1)
            {
                ScoreManager.score += 500;
                StartCoroutine("SetTrigger");
            }
            DestroyImmediate(col.gameObject, true);
           // Destroy(col.gameObject);
            if (health > 1)
            {
                health--;
                StartCoroutine(Flash(0.2f, 0.05f));
                // myManager.score += 1000 * myManager.modifier;
            }
        }
    }

    IEnumerator SetTrigger()
    {
        anim.SetTrigger("bullet");
        GetComponent<AudioSource>().Play();
        GetComponent<Collider2D>().enabled = false;

        yield return new WaitForSeconds(0.5f);
        health--;
    }
    IEnumerator Flash(float time, float intervalTime)
    {
        float elapsedTime = 0f;
        int index = 0;
        while (elapsedTime < time)
        {
            mat.color = colors[index % 2];

            elapsedTime += Time.deltaTime;
            index++;
            yield return new WaitForSeconds(intervalTime);
        }
        mat.color = Color.white;
    }
}

