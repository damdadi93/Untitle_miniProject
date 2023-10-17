using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSkill : MonoBehaviour
{
    private Rigidbody2D rigid;
    private Animator animator;
    public float rotatespeed;
    public float speed;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        Invoke("Udo", 2f);

        rigid.velocity = new Vector2(Random.Range(-2.0f,2.0f), 5);
    }


    public void Udo() //유도
    {
        animator.SetTrigger("isUdo");
        rotatespeed = 0;
        rigid.velocity = new Vector2(0, 0);
        Vector3 dirVec = GameObject.Find("Player").transform.position - transform.position;
        rigid.AddForce(dirVec.normalized * speed, ForceMode2D.Impulse);
        Vector2 len = GameObject.Find("Player").transform.position - transform.position; //방향 유도
        float z = Mathf.Atan2(len.x, len.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, -z);
        Destroy(gameObject, 3f);
    }
}
