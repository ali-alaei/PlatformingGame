using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxHealth : MonoBehaviour {

    [SerializeField]
    private int health;

    private void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("collision name = " + col.gameObject.name);
        if (col.gameObject.tag == "bullet" && health>0)
        {
            health--;
        }
        if (col.gameObject.tag == "bullet" && health == 0)
        {
            Destroy(gameObject);
        }
                
    }
    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
