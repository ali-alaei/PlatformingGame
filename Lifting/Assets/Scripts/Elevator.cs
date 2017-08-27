using UnityEngine;
using System.Collections;

public class Elevator : MonoBehaviour {
	public Transform[] point;
	public float speed = 5f;
	private Transform _myTransform;
	private bool _switching;
	private bool _upstair;
	private bool _downstair;
	private int _stage;
	void Start () {
		_myTransform = this.transform;
	}
	void FixedUpdate() {
		if(Input.GetKeyDown(KeyCode.F)){
			_stage = 0;
		}
		if(Input.GetKeyDown(KeyCode.P)){
			if (_stage < point.Length - 1)
				_stage++;
			else
				_stage = point.Length - 1;
			_upstair = true;
		}
		if(Input.GetKeyDown(KeyCode.M)){
			if (_stage > 0)
				_stage--;
			else
				_stage = 0;
			_downstair = true;
		}
		if (_upstair == true) {
			_myTransform.position = Vector3.MoveTowards (_myTransform.position, point [_stage].position, 5 * Time.deltaTime);
		}
		if (_downstair == true) {
			_myTransform.position = Vector3.MoveTowards (_myTransform.position, point [_stage].position, 5 * Time.deltaTime);
		}

		/*
		if (_myTransform.position == origin.position) {

			_switching = false;
		}


		if (_switching == false) {

			_myTransform.position = Vector3.MoveTowards (_myTransform.position, destination.position, 5 * Time.deltaTime);

		}


		if (_myTransform.position == destination.position) {

			_switching = false;

		}

		if (_switching == false) {

			_myTransform.position = Vector3.MoveTowards (_myTransform.position, origin.position, 5 * Time.deltaTime);

		}*/
	
	}


}

