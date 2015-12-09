using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

    //1- The Speed of the ship
    public Vector2 speed = new Vector2(50, 50);

    //2-Store the movement
    private Vector2 movement;

	
	void Update ()
    {

        // 3- Retrieve axis information
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        //4- Movement per direction

        movement = new Vector2(speed.x * inputX, speed.y * inputY);

        //5- Shooting
        bool shoot = Input.GetButtonDown("Fire1");
        shoot |= Input.GetButtonDown("Fire2");
        if (shoot)
        {
            Weapon weapon = GetComponent<Weapon>();
            if (weapon != null)
            {
                //false because the player is not an enemy
                weapon.Attack(false);
//                Sound.Instance.MakePlayerShotSound();
            }

         
        }
        // 6 - Make sure we are not outside the camera bounds
        var dist = (transform.position - Camera.main.transform.position).z;

        var leftBorder = Camera.main.ViewportToWorldPoint(
          new Vector3(0, 0, dist)
        ).x;

        var rightBorder = Camera.main.ViewportToWorldPoint(
          new Vector3(1, 0, dist)
        ).x;

        var topBorder = Camera.main.ViewportToWorldPoint(
          new Vector3(0, 0, dist)
        ).y;

        var bottomBorder = Camera.main.ViewportToWorldPoint(
          new Vector3(0, 1, dist)
        ).y;

        transform.position = new Vector3(
          Mathf.Clamp(transform.position.x, leftBorder, rightBorder),
          Mathf.Clamp(transform.position.y, topBorder, bottomBorder),
          transform.position.z
        );

        // End of the update method
    }

    void FixedUpdate()
    {
        //move the game objects
        GetComponent<Rigidbody2D>().velocity = movement;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        bool damagePlayer = false;

        // Collision with enemy
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            // Kill the enemy
            Health enemyHealth = enemy.GetComponent<Health>();
            if (enemyHealth != null) enemyHealth.Damage(enemyHealth.hp);

            damagePlayer = true;
        }

        // Damage the player
        if (damagePlayer)
        {
            Health playerHealth = this.GetComponent<Health>();
            if (playerHealth != null) playerHealth.Damage(1);
        }
    }
}
