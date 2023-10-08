using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonManager : MonoBehaviour
{
    GameObject player;
    MoveScript moveScript;
    public bool leftmove;
    public bool rightmove;
    public float move;


    public void Init()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        moveScript = player.GetComponent<MoveScript>();
        move = moveScript.moveSpeed;
    }
    
    public void LeftDown()
    {
        //playerScript.inputLeft = true;
        if(move <0)
        {
           // moveScript.moveSpeed()
        }
       

    }
    public void LeftUp()
    {
        //playerScript.inputLeft = false;
    }

    public void RightDown()
    {
        //playerScript.inputRight = true;
    }

    public void RightUp()
    {
        //playerScript.inputRight = false;
    }

    public void JumpClick()
    {
        Debug.Log("Jump");
        
    }

    public void LeftClick()
    {

    }

    public void RightClick()
    {

    }

  

   
}
