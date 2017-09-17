
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShooting : MonoBehaviour {
    [SerializeField]
    private Transform firePoint;
    [SerializeField]
    public GameObject bullet;
    
    int shootInput;

    WeaponSwithcing weaponSwitching;
    public Text coltBulletCountText;
    public Text machineGunBulletCountText;
    public bool isColte;
    private int coltCounter;
    private int machineGunCounter;


    private void Start()
    {
        weaponSwitching = GameObject.FindGameObjectWithTag("gun").GetComponent<WeaponSwithcing>();
    }
    // Update is called once per frame

    void Update ()
    {
        coltCounter = Convert.ToInt32(coltBulletCountText.text);
        machineGunCounter = Convert.ToInt32(machineGunBulletCountText.text);
        isColte = weaponSwitching.isColt;
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
        if (coltCounter > 0)
        {
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                if (isColte == true) {
                    coltCounter--;
                    SetCountText(coltBulletCountText , coltCounter);
                }
                if (isColte == false) { 
                    machineGunCounter--;
                    SetCountText(machineGunBulletCountText , machineGunCounter);
                }
                
                
                if (transform.localScale.x > 0)
                {
                    Instantiate(bullet, firePoint.position, Quaternion.identity);
                }
                if (transform.localScale.x < 0)
                {
                    Instantiate(bullet, firePoint.position, Quaternion.Euler(0, 0, 180));
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
                Instantiate(bullet, firePoint.position, Quaternion.identity);
            }
            if (transform.localScale.x < 0)
            {
                Instantiate(bullet, firePoint.position, Quaternion.Euler(0, 0, 180));
            }
            //GameObject bullet_temp = Instantiate(bullet, firePoint.position, Quaternion.identity) as GameObject;
        }
#endif
    }
    void SetCountText(Text txt , int x)
    {
        txt.text = x.ToString();
    }
}


