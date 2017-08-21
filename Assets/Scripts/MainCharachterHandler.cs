using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharachterHandler : MonoBehaviour {
    [SerializeField]
    private Transform firePoint;
    [SerializeField]
    private GameObject bullet;

    // Update is called once per frame
    void Update () {

        if (Input.GetKeyDown(KeyCode.Space))
        {

            //GameObject bullet_temp = Instantiate(bullet, firePoint.position, Quaternion.identity) as GameObject;
            Instantiate(bullet,firePoint.position,Quaternion.identity);

        }
    }
}
