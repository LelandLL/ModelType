using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

    //Projectile Prefab for shooting
    public Transform Greenlazer;

    // Cooldown in seconds between two shots
    public float shootingRate = 0.25f;

    //-----------------------------
    // 2 - Cooldown
    //-----------------------------

    private float shootCooldown;
	
	void Start ()
    {
        shootCooldown = 0f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (shootCooldown > 0)
        {
            shootCooldown -= Time.deltaTime;
        }
	}

    //------------------------
    // 3 - Shooting from another script
    //------------------------

    public void Attack(bool isEnemy) {
        if (CanAttack)
        {
            shootCooldown = shootingRate;

            //Create a new shot
            var shotTransform = Instantiate(Greenlazer) as Transform;

            //Assign position
            shotTransform.position = transform.position;

            //The is enemy property
            ProjectileShot shot = shotTransform.gameObject.GetComponent<ProjectileShot>();
            if (shot != null)
            {
                shot.isEnemyShot = isEnemy;
            }

            //Make the weapon shot always toward it
            MoveObjectScript move = shotTransform.gameObject.GetComponent<MoveObjectScript>();
            if (move != null)
            {
                move.direction = this.transform.up;
            }
        }
    }

    public bool CanAttack
    {
        get
        {
            return shootCooldown <= 0f;
        }
    }
}
