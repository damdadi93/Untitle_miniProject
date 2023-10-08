using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Input_Player : InputScript
{
    public float speed;
    public float horizontalMove;
    public bool moveRight;
    public bool moveLeft;
    public Rigidbody2D rb;
    

    // Start is called before the first frame update
    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveLeft = false;
        moveRight = false;
    }

    // Update is called once per frame
   
        
   

    public void pointerDownLeft()
    {
        moveLeft = true;
    }

    public void pointerUpLeft()
    {
        moveLeft = false;
    }

    public void pointerDownRight()
    {
        moveRight = true;
    }

    public void pointerUpRight()
    {
        moveRight=false;
    }

    void Movement()
    {
        if(moveLeft)
        {
            horizontalMove = -move;
        }
        else if(moveRight)
        {
            horizontalMove = move;
        }
        else
        {
            horizontalMove = 0;
        }
    }

    private void FixedUpdate()
    {
       
        rb.velocity = new Vector2(horizontalMove, rb.velocity.y);
    }
}
