using System.Collections;
using System.Collections.Generic;
using UnityEngine;
////Milad Ebrahimi
public class EnemyShooting : MonoBehaviour {
	[SerializeField]
	private Transform firePoint;
	[SerializeField]
	private GameObject bullet;
	public float distance;
	public float telorance;
	private float shootDelay=2f;
	GameObject Player;
	EnemyMovement enemyMove;
	void Awake()
	{
		Player = GameObject.FindGameObjectWithTag("Player");

	}
	void Start()
	{
		enemyMove = GameObject.FindGameObjectWithTag ("Enemy").GetComponent<EnemyMovement> ();
	}
	void Update () {
		if (canSeePlayer ()) {
			StartCoroutine (shootBullet ());
		} else {
			StopCoroutine (shootBullet ());
		}
	}
	IEnumerator shootBullet()
	{
		if (transform.localScale.x<0)
		{
			Vector2 firstscale = bullet.transform.localScale;
			Vector2 scale = bullet.transform.localScale;
			scale.x *= -1;
			bullet.transform.localScale = scale;
			Instantiate(bullet, firePoint.position, Quaternion.identity);
			bullet.transform.localScale = firstscale;
		}
		else if (transform.localScale.x>0)
		{
			Instantiate (bullet, firePoint.position, Quaternion.identity );
		}
		yield return new WaitForSeconds (shootDelay);
	}
	private bool canSeePlayer()
	{
		float forward = transform.position.x + distance;
		float back = transform.position.x - distance;
		float forwardT = transform.position.x + telorance;
		float backT = transform.position.x - telorance;
		if(Player.transform.position.x < forwardT && Player.transform.position.x > backT && enemyMove.isInMiddle)
		{
			return false;
		}
		else if (Player.transform.position.x < forward && Player.transform.position.x > back) {
			if(enemyMove.speed > 0 && Player.transform.position.x < transform.position.x)
			{
				enemyMove.flipLeft ();
			}
			else if(enemyMove.speed < 0 && Player.transform.position.x > transform.position.x)
			{
				enemyMove.flipRight ();
			}
			return true;
		} else {
			return false;
		}
	}

}
