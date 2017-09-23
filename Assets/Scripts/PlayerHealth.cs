using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    //public delegate void ClickAction();
    //public static event ClickAction Destroying;

    //HealthBox healthbox;
    public Image image;
    private float maxHealth = 100f;
    private float curHealth = 0f;

    void Start () {

        curHealth = maxHealth;
        
    }
     
    void Update () {
        curHealth = image.fillAmount * 100;
    }

    private void OnEnable()
    {
        HealthBox.HealthUp += increasehealth;
    }

    private void OnDisable()
    {
        HealthBox.HealthUp -= increasehealth;
    }


    float increasehealth()
    {
        if (curHealth < 100)
        {
            curHealth += 20;//healthBox.health
            float calchealth = curHealth / maxHealth;
            setHealth(calchealth);
            //Destroying();
        }
        return image.fillAmount;
    }

    void setHealth(float myHealth)
    {
        image.fillAmount = myHealth;
    }

}
