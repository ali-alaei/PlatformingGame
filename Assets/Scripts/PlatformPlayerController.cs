using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPlayerController : MonoBehaviour
{


    private PlayerMovement playerMovement;
    private PlayerBoundaries playerBoundaries;
    private bool jump = false;

    public bool crouch = false;
    public float horizontalMove = 0;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerBoundaries = GetComponent<PlayerBoundaries>();
    }
    // Update is called once per frame

    void Update () {
        /**if (!jump)
        {
            // Read the jump input in Update so button presses aren't missed.
            jump = Input.GetButtonDown("Jump");
        }**/
    }

    private void FixedUpdate()
    {
        crouch = Input.GetKey(KeyCode.LeftControl);
        horizontalMove = Input.GetAxis("Horizontal");
        // Pass all parameters to the playerMovement control script.
        playerBoundaries.CheckXY();
        playerMovement.Move(InputHandler.Instance.GetRightBTn(), InputHandler.Instance.GetLeftBTn(), InputHandler.Instance.GetCrouchBTn(), InputHandler.Instance.GetJumpBTn());
        //InputHandler.Instance.ActiveJumpBtn(false);
        jump = false;
    }

}
