using UnityEngine;
using System.Collections;

public class WeaponControl : MonoBehaviour {


    public GameObject Barrel1;
    public GameObject Barrel2;
    public GameObject Barrel3;
    public GameObject Barrel4;
    public enum WeaponSelected
    {
        Basic = 0,
        SpreadShotBasic,
        SpreadShotAdvanced
    };
    public static int selectedWeapon;
    // Update is called once per frame
    void Update()
    {


    }
    public void SwitchWeapon(WeaponSelected selectedWeaponType)
    {

        switch (selectedWeaponType)
        {
            case WeaponSelected.Basic:
                {
                    if (Barrel1 != null && Barrel2 != null)
                    {
                        Destroy(Barrel1);
                        Destroy(Barrel2);
                    }
                    else if (Barrel1 != null && Barrel2 != null)
                    {
                        Destroy(Barrel3);
                        Destroy(Barrel4);
                    }
                    selectedWeapon = 0;
                    break;
                }
            case WeaponSelected.SpreadShotBasic:
                {
                    GameObject newBarrel = (GameObject)Instantiate(Barrel1);
                    newBarrel.transform.parent = transform;
                    newBarrel.transform.position = transform.position;
                    GameObject newBarrel2 = (GameObject)Instantiate(Barrel2);
                    newBarrel2.transform.parent = transform;
                    newBarrel2.transform.position = transform.position;
                    selectedWeapon = 1;
                    break;
                }
            case WeaponSelected.SpreadShotAdvanced:
                {
                    GameObject newBarrel3 = (GameObject)Instantiate(Barrel3);
                    newBarrel3.transform.parent = transform;
                    newBarrel3.transform.position = transform.position;
                    GameObject newBarrel4 = (GameObject)Instantiate(Barrel4);
                    newBarrel4.transform.parent = transform;
                    newBarrel4.transform.position = transform.position;
                    selectedWeapon = 2;
                    break;
                }
        }

    }
}
