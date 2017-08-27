using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
	public GameObject startPoint;
	public GameObject endPoint;
	public float speed ;
	private bool isInMiddle = false;
	void Start()
	{
		if (transform.position.x >= startPoint.transform.position.x && transform.position.x <= endPoint.transform.position.x) {
			isInMiddle = true;
			flipRight ();
			speed = Mathf.Abs (speed);
		}
		else if(transform.position.x < startPoint.transform.position.x)
		{
			flipRight ();
			speed = Mathf.Abs (speed);
		}
		else if(transform.position.x > endPoint.transform.position.x)
		{
			flipLeft ();
			speed = -1 * Mathf.Abs (speed);
		}

	}
	void Update()
	{
		if (transform.position.x >= startPoint.transform.position.x && transform.position.x <= endPoint.transform.position.x) {
			isInMiddle = true;
		}
		if (isInMiddle) {
			if (transform.position.x < startPoint.transform.position.x) {
				flipRight ();
				speed = Mathf.Abs (speed);
			} else if (transform.position.x > endPoint.transform.position.x) {
				flipLeft ();
				speed = -1 * Mathf.Abs (speed);
			}
		} 
		transform.Translate (new Vector3 (speed, 0, 0) * Time.deltaTime);
	}
	void flipRight()
	{
		Vector3 scale = transform.localScale;
		scale.x = 1;
		transform.localScale = scale;
	}
	void flipLeft()
	{
		Vector3 scale = transform.localScale;
		scale.x = -1;
		transform.localScale = scale;
	}
}
