using UnityEngine;
using System.Collections;

public class Patterns1 : MonoBehaviour {

    //Vector3 startPosition : Vector3 = Vector3(-10,0,0);    //The starting position in world space
    //var endPosition : Vector3 = Vector3(10,0,0);    //The ending position in world space
    //var bending : Vector3 = Vector3.up;                //Bend factor (on all axes)
    // var timeToTravel : float = 10.0;                //The total time it takes to move from start- to end position

    Vector3 startPos;
    Vector3 endPos = new Vector3(0, -1, 0);
    Vector3 bending = Vector3.up;
    //int pattern = Random.Range(0, 1);
    public float timeToTravel = 10.0f;

    void Start()
    {
        startPos = transform.position;

    }
    void Update()
    {
        EnemyPattern1();
    }
    IEnumerator EnemyPattern1()
    {
        float timeStamp = Time.time;

        while (Time.time < timeStamp + timeToTravel)
        {
            Vector3 currentPos = Vector3.Lerp(startPos, endPos, (Time.time - timeStamp) / timeToTravel);

            currentPos.x += bending.x * Mathf.Sin(Mathf.Clamp01((Time.time - timeStamp) / timeToTravel) * Mathf.PI);
            currentPos.y += bending.y * Mathf.Sin(Mathf.Clamp01((Time.time - timeStamp) / timeToTravel) * Mathf.PI);
            currentPos.z += bending.z * Mathf.Sin(Mathf.Clamp01((Time.time - timeStamp) / timeToTravel) * Mathf.PI);

            transform.position = currentPos;
            yield return 0;
        }
    }
}
