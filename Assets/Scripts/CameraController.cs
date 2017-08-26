using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject player;
    public float horizontalEdgePosition;

    private Rigidbody2D rigidbody2D;
    private float playerAndCameraHorizontalDistance;
	void Start ()
	{
	    rigidbody2D = GetComponent<Rigidbody2D>();
	}
	
	void Update ()
	{
	    playerAndCameraHorizontalDistance = player.transform.position.x - transform.position.x;
	    if (Mathf.Abs(playerAndCameraHorizontalDistance) > Mathf.Abs(horizontalEdgePosition))
	    {
            float distance = playerAndCameraHorizontalDistance - (playerAndCameraHorizontalDistance > 0 ? horizontalEdgePosition : -horizontalEdgePosition);
            transform.position = new Vector3(transform.position.x + distance, transform.position.y, transform.position.z);
	    }
	}
}
