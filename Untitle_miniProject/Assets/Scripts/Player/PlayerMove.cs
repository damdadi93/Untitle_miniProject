using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private ComponentScript componentScript;
    private PlayerInput playerInput; // 플레이어 입력을 알려주는 컴포넌트
    private Rigidbody2D playerRigidbody; // 플레이어 캐릭터의 리지드바디
    private Animator playerAnimator; // 플레이어 캐릭터의 애니메이터

    public float moveSpeed = 5f;
    public ParticleSystem MoveDust;

    void Awake()
    {
        componentScript = GetComponent<ComponentScript>();
        playerInput = GetComponent<PlayerInput>();
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        playerRigidbody.velocity = new Vector2(moveSpeed * playerInput.move, playerRigidbody.velocity.y * componentScript.MoveComponent);

        if (playerInput.move != 0)
        {
            playerAnimator.SetFloat("isWalk", componentScript.MoveComponent);
            if (playerInput.move > 0) transform.localScale = new Vector3(1, 1, 1); else transform.localScale = new Vector3(-1, 1, 1); //방향전환
            if(playerAnimator.GetBool("isGrounded"))
                MoveDust.Play();
            else
                MoveDust.Stop();
        }
        else
        {
            playerAnimator.SetFloat("isWalk", 0);
            MoveDust.Stop();
        }
    }
}
