using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwithcing : MonoBehaviour {

    public int selectedWeapon = 0;
    PlayerShooting playershoot;

    [SerializeField]
    private int isColt;

    public int IsColt
    {
        get
        {
            return isColt;
        }

        set
        {
            isColt = value;
        }
    }

    // Use this for initialization
    void Start () {
        SelectWeapon();
        
		
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
        if (InputHandler.Instance.GetChangeWeaponBTn() > 0f)
        {
            if (selectedWeapon >= transform.childCount - 1)
            {
                selectedWeapon = 0;
                //playershoot.bullet = machineGunBullet;
                IsColt = 0;
            }
            else
            {
                selectedWeapon++;
                // playershoot.bullet = coltBullet;
                IsColt = 1;
            }
        }
        if (InputHandler.Instance.GetChangeWeaponBTn() < 0f)
        {
            if (selectedWeapon <= 0)
            {
                selectedWeapon = transform.childCount - 1;
                //playershoot.bullet = coltBullet;
                IsColt = 1;
            }
            else
            {
                selectedWeapon--;
                //playershoot.bullet = machineGunBullet;
                IsColt = 0;

            }
        }

        InputHandler.Instance.ActiveChangeWeaponBtn(0);
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
