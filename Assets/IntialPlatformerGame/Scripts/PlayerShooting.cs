using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {
    [SerializeField]
    private Transform firePoint;
    [SerializeField]
    private GameObject bullet;

    int shootInput;

    // Update is called once per frame
    void Update ()
    {
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
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
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
#elif UNITY_ANDROID
        if (shootInput == 1)
        {
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




}


