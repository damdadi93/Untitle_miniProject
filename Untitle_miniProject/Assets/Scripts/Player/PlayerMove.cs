using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 5f;

    private PlayerScript playerscript;
    private PlayerInput playerInput; // �÷��̾� �Է��� �˷��ִ� ������Ʈ
    private Rigidbody2D playerRigidbody; // �÷��̾� ĳ������ ������ٵ�
    private Animator playerAnimator; // �÷��̾� ĳ������ �ִϸ�����

    void Awake()
    {
        playerscript = GetComponent<PlayerScript>();
        playerInput = GetComponent<PlayerInput>();
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Move();
        playerAnimator.SetFloat("Move", playerInput.move);
    }

    private void Move()
    {
        playerRigidbody.velocity = new Vector2(moveSpeed * playerInput.move, playerRigidbody.velocity.y * playerscript.MoveComponent);

        if (playerInput.move != 0)
        {
            playerAnimator.SetFloat("isWalk", playerscript.MoveComponent);
            if (playerInput.move > 0) transform.localScale = new Vector3(1, 1, 1); else transform.localScale = new Vector3(-1, 1, 1); //������ȯ
        }
        else
        {
            playerAnimator.SetFloat("isWalk", 0);
        }
    }
}
