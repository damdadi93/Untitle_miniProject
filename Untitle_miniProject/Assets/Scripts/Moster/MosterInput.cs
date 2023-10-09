using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MosterInput : InputScript
{
    public float hp;
    public Transform Sight; //raycast �� ��ġ
    public float AttackScope; //���ݹ���

    public int health;


    public void Awake()
    {
        move = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            Debug.DrawRay(Sight.position, Vector3.down, new Color(0, 1, 0)); //���� �Ʒ��� ��
            RaycastHit2D GroundrayHit = Physics2D.Raycast(Sight.position, Vector3.down, 1, LayerMask.GetMask("Ground"));
            if (!GroundrayHit)
            {
                move *= -1;
            }

            Debug.DrawRay(transform.position + new Vector3(0, 0.5f, 0), new Vector3(move * AttackScope, 0, 0), new Color(1, 0, 0)); //�������� ��
            RaycastHit2D AttackrayHit = Physics2D.Raycast(transform.position + new Vector3(0, 0.5f, 0), new Vector3(move * AttackScope, 0, 0), 1, LayerMask.GetMask("Player"));
            if (AttackrayHit)
            {
                attack = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerAttack")
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
        move = 0;
        canMove = false;
    }


}
