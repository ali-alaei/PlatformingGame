using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwithcing : MonoBehaviour {

    public int selectedWeapon = 0;
    PlayerShooting playershoot;
    public GameObject machineGunBullet;
    public GameObject coltBullet;
    public bool isColt;

    // Use this for initialization
    void Start () {
        SelectWeapon();
        playershoot = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerShooting>();
		
	}
	
	// Update is called once per frame
	void Update () {

        int previousSelectedWeapon = selectedWeapon;
#if UNITY_EDITOR
        SwitchWeapon();
        if (previousSelectedWeapon != selectedWeapon)
        {
            SelectWeapon();
        }
#elif UNITY_ANDROID
      SelectWeapon();
#endif


    }

    public void StartSwitchingWeapons()
    {
        if (selectedWeapon >= transform.childCount - 1)
        {
            selectedWeapon = 0;
        }
        else
        {
            selectedWeapon++;
        }

    }


    void SwitchWeapon()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (selectedWeapon >= transform.childCount - 1)
            {
                selectedWeapon = 0;
                playershoot.bullet = machineGunBullet;
                isColt = false;
            }
            else
            {
                selectedWeapon++;
                playershoot.bullet = coltBullet;
                isColt = true;
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (selectedWeapon <= 0)
            {
                selectedWeapon = transform.childCount - 1;
                playershoot.bullet = coltBullet;
                isColt = true;
            }
            else
            {
                selectedWeapon--;
                playershoot.bullet = machineGunBullet;
                isColt = false;

            }
        }


    }

    void SelectWeapon()
    {
        int i = 0;
        foreach(Transform weapon in transform)
        {
            if(i == selectedWeapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            i++;

        }
    }


    

}
