using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : InputScript
{
    // Start is called before the first frame update
    public Transform Sight; //raycast �� ��ġ
    public float AttackScope; //���ݹ���

    public int health;
    float hitcul = 0;
    public float Angry;
    public Transform playerTrans;

    public void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hitcul -= Time.deltaTime;
        if (canMove)
        {

            Debug.DrawRay(Sight.position, new Vector3(move * 5, 0, 0), new Color(0, 0, 1)); //�÷��̾�Ž��
            RaycastHit2D PlayerrayHit = Physics2D.Raycast(Sight.position, new Vector3(move * 5, 0, 0), 1, LayerMask.GetMask("Player"));

            Debug.DrawRay(transform.position + new Vector3(0, 0.5f, 0), new Vector3(move * AttackScope, 0, 0), new Color(1, 0, 0)); //����Ž��
            RaycastHit2D AttackrayHit = Physics2D.Raycast(transform.position + new Vector3(0, 0.5f, 0), new Vector3(move * AttackScope, 0, 0), 1, LayerMask.GetMask("Player"));
            if (AttackrayHit)
            {
                attack = true;
            }

            if (move != 0)
            {
                if (playerTrans.position.x < transform.position.x)
                {
                    move = -1;
                }
                else
                    move = 1;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerAttack")
        {
            if (health > 0 && hitcul < 0)
            {
                health -= 1;
                GetComponent<AttackScript>().CancelInvoke("EndAttack");
                if (health <= 0)
                {
                    GetComponent<Animator>().SetTrigger("isDead");
                    GetComponent<Animator>().SetBool("isDeading", true);
                    Dead();
                }
                else
                {
                    GetComponent<Animator>().SetTrigger("isHit");
                    hitcul = 0.5f;
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
