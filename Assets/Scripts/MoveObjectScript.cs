using UnityEngine;
using System.Collections;

public class MoveObjectScript : MonoBehaviour {

    //Object Speed
     public Vector2 speed = new Vector2(10, 10);

    //Moving direction
    public Vector2 direction = new Vector2(-1, 0);

    private Vector2 movement;
	
	void Update()
    {    
        // 2- Movement
        movement = new Vector2(speed.x * direction.x, speed.y * direction.y);

	}

    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = movement;
    }
}
