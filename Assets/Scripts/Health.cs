using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    //Total hitpoints
    public int hp = 1;

    //Enemy or Player?
    public bool isEnemy = true;

    //Inflict Damage and Check if object should be destroyed
    public void Damage(int damageCount)
    {
        hp -= damageCount;

        if (hp <= 0)
        {
            //Dead!
            Destroy(gameObject);
            Sound.Instance.MakeExplosionSound();
        }

    }

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        ProjectileShot shot = otherCollider.gameObject.GetComponent<ProjectileShot>();
        if (shot != null)
        {
            //Avoid friendly fire
            if (shot.isEnemyShot != isEnemy)
            {
                Damage(shot.damage);
                //Destroy the shot

                Destroy(shot.gameObject); // Target the game object
            }
        }
    }


}
