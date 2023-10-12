using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : InputScript
{
    // Start is called before the first frame update
    public Transform Sight; //raycast 쏠 위치
    public float AttackScope; //공격범위

    public int health;
    public float hitcul = -1;
    public float Angry;
    public Transform playerTrans;
    public SpriteRenderer Body;
    public SpriteRenderer HitBody;

    public Animator BossComponent;

    public float Attackcul = 0;
    public float Skillcul = 3f;

    public int skill = 0;
    private Animator animator;

    public void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Attackcul -= Time.deltaTime;
        Skillcul -= Time.deltaTime;

        if (hitcul > 0)
        {
            hitcul -= Time.deltaTime;
        }
        else if(hitcul<0)
        {
            Body.enabled = true;
            HitBody.enabled = false;
            hitcul = 0;
        }

        if (animator.GetBool("isDeading"))
        {
            move = 0;
            canMove = false;
        }
        if (canMove)
        {
            if (Skillcul < 0 && Attackcul < 0 && !BossComponent.GetBool("isDown"))
            {
                skill = Random.Range(1, 4);
            }
            else
            {
                skill = 0;
            }

            Debug.DrawRay(transform.position + new Vector3(0, 0.5f, 0), new Vector3(move * AttackScope, 0, 0), new Color(1, 0, 0)); //공격탐지
            RaycastHit2D AttackrayHit = Physics2D.Raycast(transform.position + new Vector3(0, 0.5f, 0), new Vector3(move * AttackScope, 0, 0), 1, LayerMask.GetMask("Player"));
            if (AttackrayHit && skill == 0 && !BossComponent.GetBool("isDown"))
            {
                attack = true;
            }
            else
            {
                attack = false;
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
            if (health > 0 && hitcul <= 0)
            {
                health -= 1;
                if (health <= 0)
                {
                    GetComponent<Animator>().SetTrigger("isDead");
                    GetComponent<Animator>().SetBool("isDeading", true);
                    Dead();
                }
                else
                {
                    Body.enabled = false;
                    HitBody.enabled = true;
                    hitcul = 0.1f;
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
