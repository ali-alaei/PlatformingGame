using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour {

    public static InputHandler Instance; 
    bool crouch;
    bool jump;
    bool up;
    bool down;
    bool right;
    bool left;
    float changeWeapon;
    bool shoot;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    //Only for Canvas Buttons
    public void ActiveJumpBtn(bool jmp)
    {
        this.jump = jmp;
    }

    public void ActiveCrouchBtn(bool crh)
    {
        crouch = crh;
    }

    public void ActiveUpBtn(bool up)
    {
        this.up = up;
    }

    public void ActiveDownBtn(bool down)
    {
        this.down = down;
    }

    public void ActiveLeftBtn(bool left)
    {
        this.left = left;
    }

    public void ActiveRightBtn(bool right)
    {
        this.right = right;
    }

    public void ActiveChangeWeaponBtn(float changeWeapon)
    {
        this.changeWeapon = changeWeapon;
    }

    public void ActiveShootBtn(bool shoot)
    {
        this.shoot = shoot;
    }
    //End of Canvas Buttons

    //Editor Script
    private void Update()
    {
        changeWeapon = Input.GetAxis("Mouse ScrollWheel");
        jump = Input.GetButtonDown("Jump");
        float horizontalMove = Input.GetAxis("Horizontal");
        if (horizontalMove < 0)
        {
            left = true;
        }
        else if (horizontalMove > 0)
        {
            right = true;
        }
        else
        {
            right = false;
            left = false;
        }
        crouch = Input.GetKey(KeyCode.LeftShift);
        shoot = Input.GetKeyDown(KeyCode.LeftControl);
    }
    //End of Editor Script

    public bool GetJumpBTn()
    {
        return this.jump;
    }

    public bool GetCrouchBTn()
    {
        return this.crouch;
    }

    public bool GetUpBTn()
    {
        return this.up;
    }

    public bool GetDownBTn()
    {
        return this.down;
    }

    public bool GetLeftBTn()
    {
        return this.left;
    }

    public bool GetRightBTn()
    {
        return this.right;
    }

    public float GetChangeWeaponBTn()
    {
        return this.changeWeapon;
    }

    public bool GetShootBTn()
    {
        return this.shoot;
    }



}
