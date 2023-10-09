using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInput : InputScript
{
    public VariableJoystick joystick;
    public Image joystickImage;
    public Sprite[] joystickSprites;

    public int health;

    private string moveAxisName = "Horizontal";

    public void Update()
    {
<<<<<<< Updated upstream
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
=======
        if (canMove)
>>>>>>> Stashed changes
        {
            move = Input.GetAxisRaw(moveAxisName);

<<<<<<< Updated upstream
        if (touchJump)
        {
            jump = true;
        }
        else
        {
            jump = false;
        }


=======
            if (Input.GetButtonDown("Jump"))
                jump = true;
            if (Input.GetButtonDown("Fire1"))
                attack = true;


            if (joystick)
            {
                if (move == 0)
                {
                    move = joystick.Horizontal;
                    if (move > 0) move = 1; if (move < 0) move = -1;
                }

                if (move == 0) joystickImage.sprite = joystickSprites[0];
                else if (move < 0) joystickImage.sprite = joystickSprites[1];
                else joystickImage.sprite = joystickSprites[2];
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "MonsterAttack")
        {
            if (health > 0)
            {
                health -= 1;
                if (health <= 0)
                {
                    GetComponent<Animator>().SetTrigger("isDead");
                    GetComponent<Animator>().SetBool("isDeading", true);
                    GetComponent<AttackScript>().CancelInvoke("EndAttack");
                    Dead();
                }
            }
        }
    }
    void Dead()
    {
        canMove = false;
    }

    public void JumpButton()
    {
        jump = true;
    }
    public void AttackButton()
    {
        attack = true;
>>>>>>> Stashed changes
    }
}
