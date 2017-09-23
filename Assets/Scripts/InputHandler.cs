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
    bool changeWeapon;
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
#if UNITY_ANDROID

    public void ActiveJumpBtn(bool jmp)
    {
        jump = jmp;
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

    public void ActiveChangeWeaponBtn(bool changeWeapon)
    {
        this.changeWeapon = changeWeapon;
    }

    public void ActiveShootBtn(bool shoot)
    {
        this.shoot = shoot;
    }

#elif UNITY_EDITOR
    private void Update()
    {
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
        crouch = Input.GetKey(KeyCode.LeftShift);
        shoot = Input.GetKeyDown(KeyCode.LeftControl);

    }
#endif
    ///////////////////////////////////////////////////////////////////////// 

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

    public bool GetChangeWeaponBTn()
    {
        return this.changeWeapon;
    }

    public bool GetShootBTn()
    {
        return this.shoot;
    }



}
