using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwithcing : MonoBehaviour {

    public int selectedWeapon = 0;

    private bool shutgunSelected;

    public bool ShutgunSelected
    {
        get
        {
            return shutgunSelected;
        }

        set
        {
            shutgunSelected = value;
        }
    }

    private bool coltSelected;

    public bool ColtSelected
    {
        get
        {
            return coltSelected;
        }

        set
        {
            coltSelected = value;
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
                
            }
            else
            {
                selectedWeapon++;
            }
        }
        if (InputHandler.Instance.GetChangeWeaponBTn() < 0f)
        {
            if (selectedWeapon <= 0)
            {
                selectedWeapon = transform.childCount - 1;
            }
            else
            {
                selectedWeapon--;
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
                if (i==0)
                {
                    shutgunSelected = true;
                }
                else if (i==1)
                {
                    coltSelected = true;
                }
            }
            else
            {
                weapon.gameObject.SetActive(false);               
            }
            i++;

        }
    }


    

}
