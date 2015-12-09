using UnityEngine;
using System.Collections;

public class DestroyOnTimer : MonoBehaviour {

    public float LifeTimer = 1.0f;
    public GameObject destroyObject;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, LifeTimer);
    }
}
