using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlayerDetector : MonoBehaviour {
	BoxCollider2D col;
	EnemyMovement enemyMove;
	EnemyShooting enemyShoot;
	[SerializeField]
	private float lastSpeed;
	public bool isGone = false;
	// Use this for initialization
	void Awake()
	{
		col = gameObject.GetComponent<BoxCollider2D> ();
		col.isTrigger = true;
		enemyMove = GameObject.FindGameObjectWithTag ("Enemy").GetComponent<EnemyMovement> ();
		enemyShoot = GameObject.FindGameObjectWithTag ("Enemy").GetComponent<EnemyShooting> ();
		//lastSpeed = enemyMove.speed;
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag ("Player") && enemyMove.speed!=0) {
			lastSpeed = enemyMove.speed;

		}
	}
	void OnTriggerStay2D(Collider2D other)
	{
		if(other.gameObject.CompareTag("Player") && !enemyShoot.isShooted)
		{
			enemyMove.speed=0;
			StartCoroutine(enemyShoot.shootBullet());
			if (!isGone) {
				isGone = true;
			}
		}
	}
	void OnTriggerExit2D(Collider2D other)
	{
		if(other.gameObject.CompareTag("Player") && isGone)
		{
			enemyMove.speed = lastSpeed;
			StopCoroutine(enemyShoot.shootBullet());
			isGone = !isGone;
		}
	}
}
