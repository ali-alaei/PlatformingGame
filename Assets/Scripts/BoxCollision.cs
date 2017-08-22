using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
    private void OnCollisionEnter2D(Collision2D col)
    { 
        Debug.Log("collision name = " + col.gameObject.name);
        if (col.gameObject.tag == "bullet")
        {
            Destroy(col.gameObject);
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
   
}
