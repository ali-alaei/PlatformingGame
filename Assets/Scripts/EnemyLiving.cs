using System.Collections;
using System.Collections.Generic;
using UnityEngine;
////Milad Ebrahimi
public class EnemyLiving : MonoBehaviour {
	private BoxCollider2D col;
	[SerializeField]
	private int lives;
	void Awake()
	{
		col = gameObject.GetComponent<BoxCollider2D>();
		col.isTrigger = true;
	}
	// Update is called once per frame
	void Update () {
		if (lives == 0) {
			DestroyIt ();
		}
	}
	void DestroyIt()
	{
		Destroy (gameObject);
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag ("PlayerBullet")) {
			lives--;
		}
	}
}
