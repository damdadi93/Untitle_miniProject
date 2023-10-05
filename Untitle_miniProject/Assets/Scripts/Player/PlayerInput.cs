using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private string moveAxisName = "Horizontal"; 

    public float move;
    public bool jump;

    void Update()
    {
        move = Input.GetAxis(moveAxisName);

    }
}
