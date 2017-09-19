
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShooting : MonoBehaviour {
    [SerializeField]
    private Transform firePoint;

    [SerializeField]
    private GameObject machineGunBullet;

    [SerializeField]
    private GameObject coltBullet;

    int shootInput;

    WeaponSwithcing weaponType;
    public Text coltBulletCountText;
    public Text machineGunBulletCountText;
    public int isColt;
    private int coltCounter;
    private int machineGunCounter;

    


    private void Start()
    {
        weaponType = GetComponentInChildren<WeaponSwithcing>();
    }
    // Update is called once per frame

    void Update ()
    {
        coltCounter = Convert.ToInt32(coltBulletCountText.text);
        machineGunCounter = Convert.ToInt32(machineGunBulletCountText.text);
        isColt = weaponType.IsColt;
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
        if (coltCounter > 0 )
        {
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                if (isColt == 1 && coltCounter > 0) {
                    coltCounter--;
                    SetCountText(coltBulletCountText , coltCounter);
                    if (transform.localScale.x > 0)
                    {
                        Instantiate(coltBullet, firePoint.position, Quaternion.identity);
                    }
                    if (transform.localScale.x < 0)
                    {
                        Instantiate(coltBullet, firePoint.position, Quaternion.Euler(0, 0, 180));
                    }
                }
                if (isColt == 0 && machineGunCounter > 0) { 
                    machineGunCounter--;
                    SetCountText(machineGunBulletCountText , machineGunCounter);
                    if (transform.localScale.x > 0)
                    {
                        Instantiate(machineGunBullet, firePoint.position, Quaternion.identity);
                    }
                    if (transform.localScale.x < 0)
                    {
                        Instantiate(machineGunBullet, firePoint.position, Quaternion.Euler(0, 0, 180));
                    }
                
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
6



        +

        }
#endif
    }
    void SetCountText(Text txt , int x)
    {
        txt.text = x.ToString();
    }
}


