using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBox : MonoBehaviour {

    public Image image;
    private bool x;

    private float maxHealth = 100f;
    private float curHealth = 0f;

    // Use this for initialization
    void Start()
    {
        curHealth = maxHealth;
        
    }

    void Awake()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        curHealth = image.fillAmount * 100;
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (curHealth < 100)
        {
            if (other.gameObject.CompareTag("player"))
            {
                Destroy(gameObject);
                increaseHealth();
            }
        }
    }

    void increaseHealth()
    {
        curHealth += 20f;
        float calcHealth = curHealth / maxHealth;
        setHealth(calcHealth);
    }

    void setHealth(float myHealth)
    {
        image.fillAmount = myHealth;
    }

}
