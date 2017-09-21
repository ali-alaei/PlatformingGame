using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyPlayerDetector : MonoBehaviour {
	BoxCollider2D col;
	EnemyMovement enemyMove;
	EnemyShooting enemyShoot;
	private float lastSpeed;
	private bool isGone = false;
    [SerializeField]
    private Transform eyes;
    private Vector2 direction;
	void Awake()
	{
		col = gameObject.GetComponent<BoxCollider2D> ();
		col.isTrigger = true;
		enemyMove = GameObject.FindGameObjectWithTag ("Enemy").GetComponent<EnemyMovement> ();
		enemyShoot = GameObject.FindGameObjectWithTag ("Enemy").GetComponent<EnemyShooting> ();
	}

    void Update()
    {
        if (enemyMove.speed > 0)
        {
            direction=Vector2.right;
        }
        else
        {
            direction = Vector2.left;
        }
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
        RaycastHit2D hit = Physics2D.Raycast(eyes.position, direction, 4.5f);
        if (hit.collider.gameObject.CompareTag("PlayerEnemyDetector"))
        {
            if (!enemyShoot.isShooted && isGone)
            {
                StartCoroutine(enemyShoot.shootBullet());
            }
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
