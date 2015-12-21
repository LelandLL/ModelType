using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    public GameObject enemyType;
    public int enemyCount;
    public float spawnTime = 1.0f;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time >= spawnTime)
        {
            Instantiate(enemyType, transform.position, Quaternion.identity);
            spawnTime = Time.time + Random.Range(2.0f, 5.0f);
        }

    }
}
