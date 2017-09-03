using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	public float speed = 2.0f;
	public GameObject startPoint;
	public GameObject endPoint;

	private Rigidbody2D rigidBody;
	private bool isInMiddle = false;

	void Awake()
	{
		rigidBody = GetComponent<Rigidbody2D>();
		rigidBody.freezeRotation = true;
	}

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
		rigidBody.velocity = new Vector2 (speed, 0);
		//rigidBody.velocity.x = speed;
	}
	void FixedUpdate()
	{
		if (transform.position.x >= startPoint.transform.position.x && transform.position.x <= endPoint.transform.position.x) {
			isInMiddle = true;
		}
		if (isInMiddle) {
			if (transform.position.x < startPoint.transform.position.x) {
				flipRight ();
			} else if (transform.position.x > endPoint.transform.position.x) {
				flipLeft ();
			}
			rigidBody.velocity = new Vector2 (speed, 0);
		}

		//transform.Translate (new Vector3 (speed, 0, 0) * Time.deltaTime);
	}
	public void flipRight()
	{
		Vector3 scale = transform.localScale;
		scale.x = -1*Mathf.Abs(scale.x);
		transform.localScale = scale;
		speed = Mathf.Abs (speed);
	}
	public void flipLeft()
	{
		Vector3 scale = transform.localScale;
		scale.x = Mathf.Abs(scale.x);
		transform.localScale = scale;
		speed = -1 * Mathf.Abs (speed);
	}

}
