using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {

	public Transform origin;
	public Transform destination;
	public float speed = 5f;

	private Transform _myTransform;
	private bool _switching;


	// Use this for initialization
	void Start () {
		_myTransform = this.transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (_myTransform.position == origin.position) {
			
			_switching = true;
		}



		if (_switching == true) {
		
			_myTransform.position = Vector3.MoveTowards (_myTransform.position, destination.position, 5 * Time.deltaTime);

		}
			

		if (_myTransform.position == destination.position) {

			_switching = false;

		}
		if (_switching == false) {

			_myTransform.position = Vector3.MoveTowards (_myTransform.position, origin.position, 5 * Time.deltaTime);

			}

		}
}

