using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour {

    bool crouch;
    bool jump;
    bool up;
    bool down;
    bool right;
    bool left;
    bool changeWeapon;
    bool shoot;
    
    public void ActiveJumpBtn()
    {
        jump = true;
    }

    public void ActiveCrouchBtn()
    {
        crouch = true;
    }

    public void ActiveUpBtn(bool up)
    {
        up = true;
    }
    public void ActiveDownBtn()
    {
        down = true;
    }

    public void ActiveLeftBtn()
    {
        left = true;
    }

    public void ActiveRightBtn()
    {
        right = true;
    }

    public void ActiveChangeWeaponBtn()
    {
        changeWeapon = true;
    }

    public void ActiveShootBtn()
    {
        shoot = true;
    }
    
}
