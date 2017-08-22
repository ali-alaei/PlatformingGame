using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {
    [SerializeField]
    private Transform firePoint;
    [SerializeField]
    private GameObject bullet;

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (transform.localScale.x>0)
            {
                Instantiate(bullet, firePoint.position, Quaternion.identity);
            }
            if (transform.localScale.x<0)
            {
                Instantiate(bullet, firePoint.position, Quaternion.Euler(0, 0, 180));
            }
            //GameObject bullet_temp = Instantiate(bullet, firePoint.position, Quaternion.identity) as GameObject;
        }
    }
}
