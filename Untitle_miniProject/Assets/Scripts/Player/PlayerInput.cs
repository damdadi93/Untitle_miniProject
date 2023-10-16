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
    float hitcul = 0;

    private string moveAxisName = "Horizontal";

    public void Update()
    {
        hitcul -= Time.deltaTime;
        if (canMove)
        {
            move = Input.GetAxisRaw(moveAxisName);

            if (Input.GetButtonDown("Jump"))
                jump = true;
            else
                jump = false;
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
            if (health > 0 && hitcul<0)
            {
                health -= 1;
                GetComponent<AttackScript>().CancelInvoke("EndAttack");
                if (health <= 0)
                {
                    Debug.Log("Dead");
                    if(UIManager.Instance)
                        UIManager.Instance.RetryPanel.SetActive(true);
                    GetComponent<Animator>().SetTrigger("isDead");
                    GetComponent<Animator>().SetBool("isDeading", true);
                    Dead();
                }
                else
                {
                    hitcul = 0.5f;
                    GetComponent<Animator>().SetTrigger("isHit");
                }
            }
        }
    }
    void Dead()
    {
        canMove = false;
        move = 0;
        jump = false;
        attack = false;
    }

    public void JumpButton()
    {
        if (canMove)
            jump = true;
    }
    public void AttackButton()
    {
        if (canMove)
            attack = true;
    }
}
