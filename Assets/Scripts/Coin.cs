using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour {

    public Text countText;
    private int count;
    private bool x;

	// Use this for initialization
	void Start () {
        count = 5;
        setCountText();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            count -= 1;
            
        }
        setCountText();
        
    }
    

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("player"))
        {
            coll.gameObject.SetActive(false);
            count = count + 1;
            Destroy(gameObject);
        }
        setCountText();
    }
    void setCountText()
    {
        countText.text = count.ToString();
    }
}
