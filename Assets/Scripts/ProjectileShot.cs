using UnityEngine;
using System.Collections;

public class ProjectileShot : MonoBehaviour {

    //1- Designer variables

        //Damage Inflicted
    public int damage = 1;

    //Projectile damage player or enemies?
    public bool isEnemyShot = false;
	
	// Update is called once per frame
	void Start ()
    {

        Destroy(gameObject, 2); // 2sec
	}
}
