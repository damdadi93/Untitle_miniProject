using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    public ComponentManager componentScript;
    private InputScript inputScript; // 입력
    private Rigidbody2D rigid; // 리지드바디
    private Animator animator; // 애니메이터
    public float Attackcul; //공격쿨타임
    public float AttackEndtime = 0.3f; //공격하고 다시 움직일때까지 시간
    float cul=0;

    public string weapon;

    void Awake()
    {
        inputScript = GetComponent<InputScript>();
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (inputScript.attack)
        {
            if (cul < 0)
            {
                cul = Attackcul;
                Attack();
            }
            inputScript.attack = false;
        }
        cul -= Time.deltaTime;
    }

    private void Attack()
    {
        if (componentScript.AttackComponent != "")
        {
            animator.SetTrigger("isAttack");
        }
        animator.SetBool("isAttacking", true);
        if (GetComponent<JumpScript>().isGrounded)
        {
            inputScript.canMove = false;
            inputScript.move = 0;
            Invoke("EndAttack", AttackEndtime);
        }
        else
        {
            animator.SetBool("isAttacking", false);
        }
    }
    public void EndAttack()
    {
        animator.SetBool("isAttacking", false);
        if (transform.localScale.x > 0) inputScript.move = 1; else inputScript.move = -1;
        inputScript.canMove = true;
    }
}
