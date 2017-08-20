using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 10.0f;
    public float maxVelocityChange = 10.0f;
    public float jumpForce = 500f;
    public float frictionCoefficient = 7f;

    private Rigidbody2D rigidBody;
    private float targetVelocity;
    private float velocity;
    private float velocityChange;
    private bool facingRight = true;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.freezeRotation = true;
    }
    
    void FixedUpdate()
    {
        targetVelocity = Input.GetAxis("Horizontal");
        targetVelocity *= speed;
        velocity = rigidBody.velocity.x;
        velocityChange = (targetVelocity - velocity);
        velocityChange = Mathf.Clamp(velocityChange, -maxVelocityChange, maxVelocityChange);
        rigidBody.AddForce(new Vector2(velocityChange * frictionCoefficient, 0));

        if (Input.GetButton("Jump"))
        {
            if (rigidBody.velocity.y == 0f)
            {
                rigidBody.AddForce(new Vector2(0, jumpForce));
            }
        }

        if (targetVelocity > 0 && !facingRight)        
            Flip();
        else if (targetVelocity < 0 && facingRight)
            Flip();
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    
}
