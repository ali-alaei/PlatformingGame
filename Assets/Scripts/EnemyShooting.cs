using System.Collections;
using System.Collections.Generic;
using UnityEngine;
////Milad Ebrahimi
public class EnemyShooting : MonoBehaviour {
	[SerializeField]
	private Transform firePoint;
	[SerializeField]
	private GameObject bullet;
	[SerializeField]
	private float shootDelay;
	public bool isShooted = false;
	public IEnumerator shootBullet()
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
}
