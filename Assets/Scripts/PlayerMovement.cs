using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float maxSpeed = 10f;
    [SerializeField] private float jumpForce = 400f;
    [Range(0, 1)] [SerializeField] private float crouchSpeed = .36f;
    [SerializeField] private bool airControl = false;
    [SerializeField] private LayerMask whatIsGround;

    private Transform groundCheck;    // A position marking where to check if the player is grounded.
    const float groundedRadius = .2f; // Radius of the overlap circle to determine if grounded
    private bool grounded;            // Whether or not the player is grounded.
    private Transform ceilingCheck;   // A position marking where to check for ceilings
    const float ceilingRadius = .01f;
    [HideInInspector] public bool facingRight = true;
    private Rigidbody2D rigidBody2d;

    float hInput = 0;
    float jInput = 0;
    void Awake()
    {
        groundCheck = transform.Find("GroundCheck");
        ceilingCheck = transform.Find("CeilingCheck");
    
        rigidBody2d = GetComponent<Rigidbody2D>();
        rigidBody2d.freezeRotation = true;
    }
    void FixedUpdate()
    {
        grounded = false;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundedRadius, whatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
                grounded = true;
        }
    }
    public void Move(float move, bool crouch, bool jump)
    {
        /**if (!crouch && Physics2D.OverlapCircle(ceilingCheck.position, ceilingRadius, whatIsGround))
        {
            // If the character has a ceiling preventing them from standing up, keep them crouching                        
            crouch = true;
        }**/

        if (grounded || airControl)
        {
            // Reduce the speed if crouching by the crouchSpeed multiplier
            move = (crouch ? move*crouchSpeed : move);
        }

        rigidBody2d.velocity = new Vector2(move * maxSpeed, rigidBody2d.velocity.y);

        // If the input is moving the player right and the player is facing left...
        if (move > 0 && !facingRight)
        {
            // ... flip the player.
            Flip();
        }
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (move < 0 && facingRight)
        {
            // ... flip the player.
            Flip();
        }

        if (grounded && jump)
        {
            // Add a vertical force to the player.
            grounded = false;            
            rigidBody2d.AddForce(new Vector2(0f, jumpForce));        }
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
}
