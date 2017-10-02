using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISwitchingWeaponHandler : MonoBehaviour
{

    WeaponSwithcing weaponType;
    private int selectedWeapon;

    [SerializeField]
    private GameObject colt;
    [SerializeField]
    private GameObject coltBullet;
    [SerializeField]
    private GameObject coltBulletCounter;

    [SerializeField]
    private GameObject machineGun;
    [SerializeField]
    private GameObject machineGunBullet;
    [SerializeField]
    private GameObject machineGunBulletCounter;

    public GameObject Colt1
    {
        get
        {
            return colt;
        }

        set
        {
            colt = value;
        }
    }

    public GameObject ColtBullet1
    {
        get
        {
            return coltBullet;
        }

        set
        {
            coltBullet = value;
        }
    }

    public GameObject ColtBulletCounter1
    {
        get
        {
            return coltBulletCounter;
        }

        set
        {
            coltBulletCounter = value;
        }
    }

    public GameObject MachineGun
    {
        get
        {
            return machineGun;
        }

        set
        {
            machineGun = value;
        }
    }

    public GameObject MachineGunBullet
    {
        get
        {
            return machineGunBullet;
        }

        set
        {
            machineGunBullet = value;
        }
    }

    public GameObject MachineGunBulletCounter
    {
        get
        {
            return machineGunBulletCounter;
        }

        set
        {
            machineGunBulletCounter = value;
        }
    }


    // Use this for initialization
    void Start()
    {
        
        weaponType = GameObject.FindGameObjectWithTag("gun").GetComponent<WeaponSwithcing>();
       
    }

    void Awake()
    {
        machineGun.SetActive(true);
        machineGunBullet.SetActive(true);
        machineGunBulletCounter.SetActive(true);
        colt.SetActive(false);
        coltBullet.SetActive(false);
        coltBulletCounter.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        selectedWeapon = weaponType.IsColt;
        SelectWeapon();
    }
    void SelectWeapon()
    {
        if(selectedWeapon == 0)
        {
            machineGun.SetActive(true);
            machineGunBullet.SetActive(true);
            machineGunBulletCounter.SetActive(true);
            colt.SetActive(false);
            coltBullet.SetActive(false);
            coltBulletCounter.SetActive(false);

        }
        if (selectedWeapon == 1)
        {
            machineGun.SetActive(false);
            machineGunBullet.SetActive(false);
            machineGunBulletCounter.SetActive(false);
            colt.SetActive(true);
            coltBullet.SetActive(true);
            coltBulletCounter.SetActive(true);

        }
    }
}
