using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPlayerController : MonoBehaviour
{


    private PlayerMovement character;
    private bool jump = false;

    float hInput = 0;
    float jInput = 0;

    private void Awake()
    {
        character = GetComponent<PlayerMovement>();
    }
    // Update is called once per frame

    void Update () {
        print(jump);
        if (!jump)
        {
            // Read the jump input in Update so button presses aren't missed.
            jump = Input.GetButtonDown("Jump");
        }
    }

    private void FixedUpdate()
    {
#if UNITY_EDITOR
        bool crouch = Input.GetKey(KeyCode.LeftControl);
        float h = Input.GetAxis("Horizontal");
        // Pass all parameters to the character control script.
        character.Move(h, crouch, jump);
        jump = false;
#elif UNITY_ANDROID
        character.Move(hInput, crouch, jump);
        jump = false;
#endif
    }

    public void StartMoving(float horizonalInput)
    {
        hInput = horizonalInput;
    }

    public void StartJumping()
    {
        jump = true;
    }
}
