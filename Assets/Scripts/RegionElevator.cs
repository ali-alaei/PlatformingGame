using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegionElevator : MonoBehaviour {

    private bool _isGetOn = false;
    //public delegate void OnClickedAction();
    //public static event OnClickedAction isGetOn;

    //public delegate void OutClickedAction();
    //public static event OutClickedAction isGetOff;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        //IsGetOn();
        print(_isGetOn);
	}

    //private void OnEnable()
    //{
    //    Elevator.isGetOn += IsGetOn;
    //}

    //private void OnDisable()
    //{
    //    Elevator.isGetOn -= IsGetOn;
    //}
    
    //private void OnTriggerEnter2D(Collider2D coll)
    //{

    //    if (coll.gameObject.CompareTag("Player"))
    //    {
    //        _isGetOn = !_isGetOn;
    //    }
    //}

    //private void OnTriggerStay2D(Collider2D coll)
    //{

    //    if (coll.gameObject.CompareTag("Player"))
    //    {
    //        _isGetOn = true;
    //    }
    //}
    //private void OnTriggerExit2D(Collider2D coll)
    //{
    //    _isGetOn = false;
    //}
    //bool IsGetOn()
    //{
    //    return _isGetOn;
    //}
}
