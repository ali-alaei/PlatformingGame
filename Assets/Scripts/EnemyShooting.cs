using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour {
	[SerializeField]
	private Transform firePoint;
	[SerializeField]
	private GameObject bullet;

	private float shootDelay=1.5f;

	private bool isShooting =true;

	void Update () {
		if (isShooting)
		{
			if (transform.localScale.x>0)
			{
				Instantiate(bullet, firePoint.position, Quaternion.identity);
			}
			if (transform.localScale.x<0)
			{
				Instantiate(bullet, firePoint.position, Quaternion.Euler(0, 0, 180));
			}
		}
		StartCoroutine (wait (shootDelay));
	}
	IEnumerator wait(float seconds)
	{
		yield return new WaitForSeconds(seconds);
	}
}
