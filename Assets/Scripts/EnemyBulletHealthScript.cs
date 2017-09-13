using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletHealthScript : MonoBehaviour {

    public Image image;
    private float maxHealth = 100f;
    private float curHealth = 0f;

    // Use this for initialization
    void Start () {
        curHealth = maxHealth;
    }
	
	// Update is called once per frame
	void Update () {

        curHealth = image.fillAmount * 100;

    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("player"))
        {

            decreeaseHealth();
            Destroy(gameObject);
        }

    }


    void decreeaseHealth()
    {
        curHealth -= 20f;
        float calcHealth = curHealth / maxHealth;
        setHealth(calcHealth);
    }




    void setHealth(float myHealth)
    {
        image.fillAmount = myHealth;
    }
}
