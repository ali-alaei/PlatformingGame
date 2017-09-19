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
	void Awake()
	{
		col = gameObject.GetComponent<BoxCollider2D> ();
		col.isTrigger = true;
		enemyMove = GameObject.FindGameObjectWithTag ("Enemy").GetComponent<EnemyMovement> ();
		enemyShoot = GameObject.FindGameObjectWithTag ("Enemy").GetComponent<EnemyShooting> ();
	}

    void Update()
    {
        shoot(isGone);
    }
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag ("PlayerEnemyDetector") && enemyMove.speed!=0) {
			lastSpeed = enemyMove.speed;
		    isGone = true;
		    enemyMove.speed = 0;
		}
	}

    void shoot(bool isGone)
    {
        if (!enemyShoot.isShooted && isGone)
        {
            StartCoroutine(enemyShoot.shootBullet());
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerEnemyDetector"))
        {
            enemyMove.speed = lastSpeed;
            StopCoroutine(enemyShoot.shootBullet());
            isGone = false;
        }
    }
}
