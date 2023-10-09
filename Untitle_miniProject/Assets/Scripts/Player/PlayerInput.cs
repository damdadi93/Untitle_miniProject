using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : InputScript
{

    public bool touchRight;
    public bool touchLeft;
    public bool touchJump;

    private string moveAxisName = "Horizontal";

    public void Update()
    {
        move = Input.GetAxis(moveAxisName);

        jump = Input.GetButtonDown("Jump");

        Movement();
    }



    public void pointerDownLeft()
    {
        touchLeft = true;
    }

    public void pointerUpLeft()
    {
        touchLeft = false;
    }

    public void pointerDownRight()
    {
        touchRight = true;
    }

    public void pointerUpRight()
    {
        touchRight = false;
    }

    public void pointerDownJump()
    {
        touchJump = true;
    }

    public void pointerUpJump()
    {
        touchJump = false;
    }

    public void Movement()
    {
        if (touchLeft && !touchRight)
        {
            move = -1f;
        }
        else if (touchRight && !touchLeft)
        {
            move = 1f;
        }
        else
        {
            move = 0f;
        }

        if (touchJump)
        {
            jump = true;
        }
        else
        {
            jump = false;
        }


    }
}
