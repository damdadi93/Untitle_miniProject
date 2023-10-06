using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    private ComponentScript componentScript;
    private InputScript inputScript; // �Է�
    private Rigidbody2D rigid; // ������ٵ�
    private Animator animator; // �ִϸ�����

    public int jumpPower;
    public bool isGrounded;
    public int jumpCount;
    public ParticleSystem jumpDust;
    public Transform jumpPivot;//������ Ž���ϴ� ����

    public float jumpScope = 1.1f;

    void Awake()
    {
        componentScript = GetComponent<ComponentScript>();
        inputScript = GetComponent<InputScript>();
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!isGrounded && jumpCount < componentScript.JumpCompoent && rigid.velocity.y > 0) animator.SetBool("isJumping", true);//���� ���� ����ī��Ʈ�� �������� �������λ��·� ����
        else animator.SetBool("isJumping", false);
        animator.SetBool("isGrounded", isGrounded);

        Debug.DrawRay(jumpPivot.position, Vector2.down* jumpScope, new Color(0, 1, 0));    //�Ʒ��κ���
        RaycastHit2D rayHit = Physics2D.Raycast(jumpPivot.position, Vector2.down, jumpScope, LayerMask.GetMask("Ground"));//���� �پ��ִ��� ����

        if (rayHit.collider != null && !isGrounded)//����
        {
            isGrounded = true;
            jumpCount = componentScript.JumpCompoent;
            jumpDust.Play();
        }
        if (rayHit.collider == null)//����
        {
            isGrounded = false;
            jumpCount = Mathf.Min(jumpCount, componentScript.JumpCompoent - 1);
        }

        if (inputScript.jump && jumpCount > 0)//����
        {
            jumpDust.Play();
            rigid.velocity = new Vector2(rigid.velocity.x, 0);
            rigid.AddForce(Vector2.up * jumpPower);
            jumpCount -= 1;
            animator.SetTrigger("isJump");
        }
    }
}
