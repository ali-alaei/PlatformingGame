using UnityEngine;
using System.Collections;

public class Elevator : MonoBehaviour {

    //[SerializeField]
    //private Collider2D Player;
    //[SerializeField]
    //private BoxCollider2D region;
    [SerializeField]
	private Transform[] point;
    
    public float speed = 5f;
	private Transform _myTransform;
	private bool _isGetOn = false;
	private bool _upstair;
	private bool _downstair;
	private int _stage;
	void Start () {
		_myTransform = this.transform;
	}
    void Update() {

        Elevating();
    }
        
    void Elevating()
    {
        //print(_isGetOn);
        if (_isGetOn == true)
        {
            
            if (Input.GetKeyDown(KeyCode.F))
            {
                _stage = 0;
            }
            if (Input.GetKeyDown(KeyCode.P))
            {
                if (_stage < point.Length - 1)
                    _stage++;
                else
                    _stage = point.Length - 1;
                _upstair = true;
            }
            if (Input.GetKeyDown(KeyCode.M))
            {
                if (_stage > 0)
                    _stage--;
                else
                    _stage = 0;
                _downstair = true;
            }
            if (_upstair == true)
            {
                _myTransform.position = Vector3.MoveTowards(_myTransform.position, point[_stage].position, 5 * Time.deltaTime);
            }
            if (_downstair == true)
            {
                _myTransform.position = Vector3.MoveTowards(_myTransform.position, point[_stage].position, 5 * Time.deltaTime);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            _isGetOn = true;
        }
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            _isGetOn = false;
        }
    }

    //bool isGetOn()
    //{
    //    if ()
    //    {
    //        return true;
    //    }
    //    else
    //    {
    //        return false;
    //    }
    //}

    //void OnCollisionEnter2D(Collision2D coll)
    //{
    //    if (coll.gameObject.CompareTag("Player"))
    //    {
    //        isGetOn = true;

    //    }
    //}
    //private void OnCollisionStay(Collision coll)
    //{
    //    if (coll.gameObject.CompareTag("Player"))
    //    {
    //        isGetOn = true;
    //    }
    //}
    //void OnCollisionExit2D(Collision2D coll)
    //{
    //    if (coll.gameObject.CompareTag("Player"))
    //    {
    //        isGetOn = false;
    //    }

    //}


}

