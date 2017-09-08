using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour {

    public GameObject player;
    public GameObject colt;

	// Use this for initialization
	void Start () {
        colt.transform.parent = player.transform;

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
