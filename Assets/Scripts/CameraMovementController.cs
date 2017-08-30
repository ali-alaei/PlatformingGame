using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementController : MonoBehaviour
{

    public GameObject player;
    public float horizontalEdgePosition;

    private Rigidbody2D rigidbody2D;
    private float playerAndCameraHorizontalDistance;
	void Start ()
	{
	    horizontalEdgePosition = Mathf.Abs(horizontalEdgePosition);
	    rigidbody2D = GetComponent<Rigidbody2D>();
	}
	
	void Update ()
	{
	    playerAndCameraHorizontalDistance = player.transform.position.x - transform.position.x;

        print(playerAndCameraHorizontalDistance);

	    while (Mathf.Abs(playerAndCameraHorizontalDistance) > 13)
	    {
	        if (playerAndCameraHorizontalDistance < 0)
	        {
	                        
	        }
	    }
	    /**while (Mathf.Abs(mainCharacter.transform.position.x) > horizontalEdgePosition)
	    {
	        if (mainCharacter.transform.position.x * Input.GetAxis("Horizontal") > 0)
	        {
                //rigidbody2D.AddForce(new Vector2(mainCharacter.GetComponent<PlayerController>().horizontalForce, 0));   
                transform.position = new Vector3(transform.position.x + 5, transform.position.y);
            }
	    }**/
	}

    
}
