using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonManager : MonoBehaviour
{
    GameObject player;
   

    public void Init()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //playerScript = player.GetComponent<PlayerMovement>();
    }
    
    public void LeftDown()
    {
        //playerScript.inputLeft = true;
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
