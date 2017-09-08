using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    float jInput = 0;

    public Text countText;
     

    private int count = 5;
   

    void Start()
    {
        
        
    }
    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.freezeRotation = true;
    }
    private void Update()
    {
        
        count = Convert.ToInt32(countText.text); 
    }

    void FixedUpdate()
    {
#if UNITY_EDITOR
        float targetVelocity = Input.GetAxis("Horizontal");
        Move(targetVelocity);
        if (Input.GetButton("Jump"))
        {
            float jumpPower = 800;
            jump(jumpPower);
        }
#elif UNITY_ANDROID
        Move(hInput);
        jump(jInput);
#endif
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

    public void StartJumping(float jumpInput)
    {
        jInput = jumpInput;
    }

    public void Move(float targetVelocity)
    {
        targetVelocity *= speed;
        velocity = rigidBody.velocity.x;
        velocityChange = (targetVelocity - velocity);
        velocityChange = Mathf.Clamp(velocityChange, -maxVelocityChange, maxVelocityChange);
        rigidBody.AddForce(new Vector2(velocityChange * frictionCoefficient, 0));
        if (targetVelocity > 0 && !facingRight)
        {
            Flip();
        }
        else if (targetVelocity < 0 && facingRight)
        {
            Flip();
        } 
    }

    public void jump(float jumpForce)
    {
        if (rigidBody.velocity.y == 0f)
        {
            rigidBody.AddForce(new Vector2(0, jumpForce));
        }
    }


    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Elevator"))
        {
            if (transform.position.y > coll.transform.position.y + 1)
                transform.SetParent(coll.transform);
        }
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Elevator"))
        {
            transform.SetParent(null);
        }
    }


}
