using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    private ComponentScript componentScript;
    private InputScript inputScript; // 입력
    private Rigidbody2D rigid; // 리지드바디
    private Animator animator; // 애니메이터

    public int jumpPower;
    public bool isGrounded;
    public int jumpCount;
    public ParticleSystem jumpDust;
    public Transform jumpPivot;//땅인지 탐지하는 기준

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
        if (!isGrounded && jumpCount < componentScript.JumpCompoent && rigid.velocity.y > 0) animator.SetBool("isJumping", true);//땅에 없고 점프카운트가 깎여있으면 점프중인상태로 설정
        else animator.SetBool("isJumping", false);
        animator.SetBool("isGrounded", isGrounded);

        Debug.DrawRay(jumpPivot.position, Vector2.down* jumpScope, new Color(0, 1, 0));    //아래로빔쏨
        RaycastHit2D rayHit = Physics2D.Raycast(jumpPivot.position, Vector2.down, jumpScope, LayerMask.GetMask("Ground"));//땅에 붙어있는지 감지

        if (rayHit.collider != null && !isGrounded)//착지
        {
            isGrounded = true;
            jumpCount = componentScript.JumpCompoent;
            jumpDust.Play();
        }
        if (rayHit.collider == null)//공중
        {
            isGrounded = false;
            jumpCount = Mathf.Min(jumpCount, componentScript.JumpCompoent - 1);
        }

        if (inputScript.jump && jumpCount > 0)//점프
        {
            jumpDust.Play();
            rigid.velocity = new Vector2(rigid.velocity.x, 0);
            rigid.AddForce(Vector2.up * jumpPower);
            jumpCount -= 1;
            animator.SetTrigger("isJump");
        }
    }
}
