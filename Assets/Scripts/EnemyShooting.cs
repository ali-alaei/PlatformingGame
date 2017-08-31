using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour {
	[SerializeField]
	private Transform firePoint;
	[SerializeField]
	private GameObject bullet;

	private float shootDelay=2f;

	private bool isShooting =true;

	void Update () {
		if (isShooting)
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
		}
	}

}
