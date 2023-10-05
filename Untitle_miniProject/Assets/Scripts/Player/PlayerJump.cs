using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    private ComponentScript componentScript;
    private PlayerInput playerInput; // 플레이어 입력을 알려주는 컴포넌트
    private Rigidbody2D playerRigidbody; // 플레이어 캐릭터의 리지드바디
    private Animator playerAnimator; // 플레이어 캐릭터의 애니메이터

    public int jumpPower;
    public bool isGrounded;
    public int jumpCount;
    public ParticleSystem JumpDust;

    private float jumpScope = 1.1f;

    void Awake()
    {
        componentScript = GetComponent<ComponentScript>();
        playerInput = GetComponent<PlayerInput>();
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!isGrounded && jumpCount < componentScript.JumpCompoent && playerRigidbody.velocity.y > 0)
            playerAnimator.SetBool("isJumping", true);
        else
            playerAnimator.SetBool("isJumping", false);
        playerAnimator.SetBool("isGrounded", isGrounded);

        Debug.DrawRay(playerRigidbody.position + Vector2.up, Vector2.down* jumpScope, new Color(0, 1, 0));    //아래로빔쏨
        RaycastHit2D rayHit = Physics2D.Raycast(playerRigidbody.position+Vector2.up, Vector2.down, jumpScope, LayerMask.GetMask("Ground"));

        if (rayHit.collider != null && !isGrounded)
        {
            isGrounded = true;
            jumpCount = componentScript.JumpCompoent;
            JumpDust.Play();
        }
        if (rayHit.collider == null)
        {
            isGrounded = false;
        }

        if (Input.GetButtonDown("Jump") && jumpCount > 0)
        {
            JumpDust.Play();
            playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, 0);
            playerRigidbody.AddForce(Vector2.up * jumpPower);
            jumpCount -= 1;
            playerAnimator.SetTrigger("isJump");
        }
    }
}
