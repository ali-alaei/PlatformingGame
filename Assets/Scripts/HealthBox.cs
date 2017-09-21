using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBox : MonoBehaviour {
    public delegate float ClickAction();
    public static event ClickAction HealthUp;

    [SerializeField]
    private int health;

    public int Health
    {
        get
        {
            return health;
        }

        set
        {
            health = value;
        }
    }

    //public Image image;
    //private float maxHealth = 100f;
    //private float curHealth = 0f;


    void Start()
    {
         
        //curHealth = maxHealth;
        
    }

    //private void OnEnable()
    //{
    //    PlayerHealth.Destroying += DestroyIt;
    //}

    //private void OnDisable()
    //{
    //    PlayerHealth.Destroying -= DestroyIt;
    //}

    void Update()
    {
        //curHealth = image.fillAmount * 100;
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        //if (curHealth < 100)
        //{
        
        if (other.gameObject.CompareTag("Player"))
        {
            //increaseHealth();
            if (HealthUp() < 1)
            {
                Destroy(gameObject);
            }
            //HealthUp();

        }
    
        //}
    }
    
    //void DestroyIt()
    //{
    //    Destroy(gameObject);
    //}

    //void increaseHealth()
    //{
    //    curHealth += 20f;
    //    float calcHealth = curHealth / maxHealth;
    //    setHealth(calcHealth);
    //}

    //void setHealth(float myHealth)
    //{
    //    image.fillAmount = myHealth;
    //}

}
