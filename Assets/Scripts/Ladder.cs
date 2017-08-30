using UnityEngine;
using System.Collections;

public class Ladder : MonoBehaviour {

	public float speed = 6f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay2D(Collider2D coll){
		if (coll.tag == "Player" && Input.GetKey (KeyCode.UpArrow)) {
			coll.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, speed);
		} else if (coll.tag == "Player" && Input.GetKey (KeyCode.DownArrow)) {
			coll.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, -speed);
		} else {
			Vector2 Velo = coll.GetComponent<Rigidbody2D> ().velocity;
			Velo.y = 0.2175999805331f;
			coll.GetComponent<Rigidbody2D> ().velocity = Velo;

			coll.GetComponent<Rigidbody2D> ().AddForce(new Vector2( 0, coll.GetComponent<Rigidbody2D> ().mass * 9.81f ));
		}
	}
}
