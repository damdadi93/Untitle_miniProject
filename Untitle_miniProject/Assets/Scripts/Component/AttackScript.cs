using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    public ComponentManager componentScript;
    private InputScript inputScript; // �Է�
    private Rigidbody2D rigid; // ������ٵ�
    private Animator animator; // �ִϸ�����
    public float Attackcul; //������Ÿ��
    public float AttackEndtime = 0.3f; //�����ϰ� �ٽ� �����϶����� �ð�
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
            inputScript.attack = false;
            if (componentScript.AttackComponent>0 && cul < 0)
            {
                cul = Attackcul;
                Attack();
            }
        }
        cul -= Time.deltaTime;
    }

    private void Attack()
    {
        animator.SetTrigger("isAttack");
        animator.SetBool("isAttacking", true);
        if (GetComponent<JumpScript>().isGrounded)
        {
            inputScript.canMove = false;
            inputScript.move = 0;
            Invoke("EndAttack", AttackEndtime);
        }
    }
    public void EndAttack()
    {
        animator.SetBool("isAttacking", false);
        if (transform.localScale.x > 0) inputScript.move = 1; else inputScript.move = -1;
        inputScript.canMove = true;
    }
}
