using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArmouryBox : MonoBehaviour
{

    public Text coltBulletCountText;
    public Text machineGunBulletCountText;
    private bool isColt;
    private int coltCounter;
    private int machineGunCounter;

    // Use this for initialization
    void Start()
    {
        coltCounter = 5;
        machineGunCounter = 5;
        SetCountText(coltBulletCountText , coltCounter);
        SetCountText(machineGunBulletCountText, machineGunCounter);
    }

    void Awake()
    {
        SetCountText(coltBulletCountText, coltCounter);
        SetCountText(machineGunBulletCountText, machineGunCounter);
    }
    // Update is called once per frame
    void Update()
    {
        coltCounter = Convert.ToInt32(coltBulletCountText.text);
        machineGunCounter = Convert.ToInt32(machineGunBulletCountText.text);
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && gameObject.CompareTag("ColtArmouryBox"))
        {
            Destroy(gameObject);
            coltCounter += 5;
            SetCountText(coltBulletCountText, coltCounter);

        }
        if (other.gameObject.CompareTag("Player") && gameObject.CompareTag("MachineGunArmouryBox"))
        {
            Destroy(gameObject);
            machineGunCounter += 5;
            SetCountText(machineGunBulletCountText, machineGunCounter);

        }
    }

    /*void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("bullet"))
        {
            
            Destroy(gameObject);
        }

    }*/

    void SetCountText(Text txt, int x)
    {
        txt.text = x.ToString();
    }

}
