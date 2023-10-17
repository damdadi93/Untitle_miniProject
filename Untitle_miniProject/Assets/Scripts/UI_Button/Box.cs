using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public float pushForce = 2f;
    public GameObject item;
    private Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // 플레이어를 찾아서 트랜스폼 저장
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (other.gameObject.CompareTag("Player"))
        {
            if (rb != null)
            {
                // 밀어내는 힘을 플레이어의 방향으로 적용
                Vector2 direction = (player.position - transform.position).normalized;
                rb.AddForce(direction * pushForce, ForceMode2D.Impulse);
            }
        }
    }
    
}
