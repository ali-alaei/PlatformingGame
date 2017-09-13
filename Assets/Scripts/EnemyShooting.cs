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
	[SerializeField]
	private float shootDelay;
	GameObject Player;
	EnemyMovement enemyMove;
	private bool isShooted = false;
	void Awake()
	{
		Player = GameObject.FindGameObjectWithTag("Player");
	}
	void Start()
	{
		enemyMove = GameObject.FindGameObjectWithTag ("Enemy").GetComponent<EnemyMovement> ();
	}
	void Update () {
		if (canSeePlayer () && !isShooted) {
			StartCoroutine (shootBullet ());
		} else {
			StopCoroutine (shootBullet ());
		}
	}
	IEnumerator shootBullet()
	{
		isShooted = true;
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
		isShooted = false;
	}
	private bool canSeePlayer()
	{
		float forward = transform.position.x + distance;
		float back = transform.position.x - distance;
		if (Player.transform.position.x < forward && Player.transform.position.x > back) {
			changeState ();
			return true;
		}
		return false;
	}
	private bool isPlayerInPatrollingArea()
	{
		if (Player.transform.position.x > enemyMove.startPoint.transform.position.x && Player.transform.position.x < enemyMove.endPoint.transform.position.x) {
			return true;
		}
		return false;
	}
	void changeState()
	{
		float forwardT = transform.position.x + telorance;
		float backT = transform.position.x - telorance;
		if (isPlayerInPatrollingArea ()) {
			if (Player.transform.position.x > forwardT || Player.transform.position.x < backT) {
				if (Player.transform.position.x > transform.position.x) {
					enemyMove.flipRight ();
				} else {
					enemyMove.flipLeft ();
				}
			}
		} else {
			if (Player.transform.position.x < transform.position.x) {
				enemyMove.flipLeft ();
			} else {
				enemyMove.flipRight ();
			}
		}
	}

}
