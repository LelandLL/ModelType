using UnityEngine;
using System.Collections;

public class PlayerMoves : MonoBehaviour {

    public float speed = 1.0f;
    private Vector3 pos;
    private float shipBoundary = 0.1f;
    Animator anim;
    public MasterGame gameMaster;
    public WeaponControl weaponInventory;
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        pos += new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f) * speed * Time.deltaTime;
        anim.SetFloat("Horizontal", Input.GetAxis("Horizontal"));

        if (pos.y + shipBoundary > Camera.main.orthographicSize)
        {
            pos.y = Camera.main.orthographicSize - shipBoundary;
        }
        if (pos.y - shipBoundary < -Camera.main.orthographicSize)
        {
            pos.y = -Camera.main.orthographicSize + shipBoundary;
        }

        float screenRatio = (float)Screen.width / (float)Screen.height;
        float widthOrtho = Camera.main.orthographicSize * screenRatio;

        if (pos.x + shipBoundary > widthOrtho)
        {
            pos.x = widthOrtho - shipBoundary;
        }
        if (pos.x - shipBoundary < -widthOrtho)
        {
            pos.x = -widthOrtho + shipBoundary;
        }

        transform.position = pos;
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "EnemyBullet")
        {
            Destroy(gameObject);
        }
        else if (col.tag == "Credit")
        {
            ScoreManager.credits += 50;
            Destroy(col.gameObject);
        }
        else if (col.tag == "Powerup")
        {
            switch (WeaponControl.selectedWeapon)
            {
                case 0:
                    {
                        weaponInventory.SwitchWeapon(WeaponControl.WeaponSelected.SpreadShotBasic);
                        break;
                    }
                case 1:
                    {
                        weaponInventory.SwitchWeapon(WeaponControl.WeaponSelected.SpreadShotAdvanced);
                        break;
                    }
            }
            ScoreManager.score += 1000;
            Destroy(col.gameObject);
        }
    }
    void OnDestroy()
    {
        weaponInventory.SwitchWeapon(WeaponControl.WeaponSelected.Basic);
        Application.LoadLevel("Main Menu");
    }
}

