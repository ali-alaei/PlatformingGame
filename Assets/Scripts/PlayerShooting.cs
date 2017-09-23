
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShooting : MonoBehaviour {
    [SerializeField]
    private Transform firePoint;
    [SerializeField]
    private GameObject shutgunBullet;
    [SerializeField]
    private GameObject coltBullet;
    private WeaponSwithcing weaponType;

    int shootInput;

    public Text countText;
    private int count;


    // Update is called once per frame
    private void Start()
    {
        weaponType = GetComponentInChildren<WeaponSwithcing>();
    }


    void Update ()
    {
        count = Convert.ToInt32(countText.text);
        Shoot();
    }

    public void startShooting(int isClicked)
    {
        shootInput = isClicked;
        //Shoot();
    }

    void Shoot()
    {
#if UNITY_EDITOR
        if (count > 0)
        {
            if (Input.GetKeyDown(KeyCode.LeftControl) && weaponType.ColtSelected)
            {
                count--;
                SetCountText();
                if (transform.localScale.x > 0)
                {
                    Instantiate(coltBullet, firePoint.position, Quaternion.identity);
                }
                if (transform.localScale.x < 0)
                {
                    Instantiate(coltBullet, firePoint.position, Quaternion.Euler(0, 0, 180));
                }
                //GameObject bullet_temp = Instantiate(bullet, firePoint.position, Quaternion.identity) as GameObject;
            }

            else if (Input.GetKeyDown(KeyCode.LeftControl) && weaponType.ShutgunSelected)
            {
                count--;
                SetCountText();
                if (transform.localScale.x > 0)
                {
                    Instantiate(shutgunBullet, firePoint.position, Quaternion.identity);
                }
                if (transform.localScale.x < 0)
                {
                    Instantiate(shutgunBullet, firePoint.position, Quaternion.Euler(0, 0, 180));
                }
                //GameObject bullet_temp = Instantiate(bullet, firePoint.position, Quaternion.identity) as GameObject;
            }
        }
#elif UNITY_ANDROID
        if (shootInput == 1)
        {
            count--;
            SetCountText();
            if (transform.localScale.x > 0)
            {
                Instantiate(coltBullet, firePoint.position, Quaternion.identity);
            }
            if (transform.localScale.x < 0)
            {
                Instantiate(coltBullet, firePoint.position, Quaternion.Euler(0, 0, 180));
            }
            //GameObject bullet_temp = Instantiate(bullet, firePoint.position, Quaternion.identity) as GameObject;
        }
#endif
    }
    void SetCountText()
    {
        countText.text = count.ToString();
    }
}


