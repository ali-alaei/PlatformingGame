using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 
////Milad Ebrahimi
public class EnemyBulletController : MonoBehaviour 
{ 
	public float speed; 

	private Rigidbody2D myRigidBody;
	Time start ;
	void Start()
	{
		myRigidBody = GetComponent<Rigidbody2D> ();
		if (transform.localScale.x > 0) {
			speed = -1 * Mathf.Abs (speed);
		} else {
			speed = Mathf.Abs (speed);
		}
		fade ();
	}
	void Update()
	{
		transform.Translate (new Vector3 (speed, 0, 0) * Time.deltaTime);
	}
	void fade()
	{
		Destroy (gameObject,3f);
	}


} 