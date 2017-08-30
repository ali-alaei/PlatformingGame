using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 10.0f;
    public float maxVelocityChange = 10.0f;
    public float jumpForce = 500f;
    public float frictionCoefficient = 7; 
    private Rigidbody2D rigidBody;
    private float velocity;
    private float velocityChange;
    private bool facingRight = true;
    float hInput = 0;


    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.freezeRotation = true;
    }
    private void Update()
    {
        
        
    }
    void FixedUpdate()
    {
        #if UNITY_ANDROID && !UNITY_IPHONE && !UNITY_BLACKBERRY && !UNITY_WINRT 
        targetVelocity = Input.GetAxis("Horizontal");
        if (Input.GetButton("Jump"))
        {
            if (rigidBody.velocity.y == 0f)
            {
                rigidBody.AddForce(new Vector2(0, jumpForce));
            }
        }
        //move();
#endif
        Move(hInput);
        
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;      
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public void StartMoving(float horizonalInput)
    {
        hInput = horizonalInput;
    }

    public void Move(float targetVelocity)
    {
        targetVelocity *= speed;
        velocity = rigidBody.velocity.x;
        velocityChange = (targetVelocity - velocity);
        velocityChange = Mathf.Clamp(velocityChange, -maxVelocityChange, maxVelocityChange);
        rigidBody.AddForce(new Vector2(velocityChange * frictionCoefficient, 0));
        if (targetVelocity > 0 && !facingRight)
            Flip();
        else if (targetVelocity < 0 && facingRight)
            Flip();
    }

   
}
