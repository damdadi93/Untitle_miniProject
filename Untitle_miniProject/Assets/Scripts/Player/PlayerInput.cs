using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : InputScript
{
    private string moveAxisName = "Horizontal"; 

    void Update()
    {
        move = Input.GetAxis(moveAxisName);
        jump = Input.GetButtonDown("Jump");
    }
}
