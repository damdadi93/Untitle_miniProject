using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSwordAxe : MonoBehaviour
{
    private Boss inputScript; // 입력
    private Rigidbody2D rigid; // 리지드바디
    private Animator animator; // 애니메이터

    public GameObject canvas;

    public GameObject AxeTrans;
    public GameObject SwordTrans;

    public GameObject AxeComponent;
    public GameObject SwordComponent;
    public GameObject SwordComponentPrefab;
    public GameObject AxeComponentPrefab;

    public Transform playerTrans;

    public float Attackcul = 10f; //공격쿨타임
    public float AttackEndtime = 6f; //공격하고 다시 움직일때까지 시간

    void Awake()
    {
        inputScript = GetComponent<Boss>();
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (inputScript.skill==3)
        {
            inputScript.skill = 0;

            inputScript.BossComponent.SetBool("isDown", true);
            inputScript.Skillcul = Attackcul;
            Invoke("Attack", 1f);
            Invoke("Attack2", 1.5f);
        }

        if (AxeComponent)
        {
            AxeComponent.transform.position = Vector2.MoveTowards(AxeComponent.transform.position, transform.position, 10f * Time.deltaTime);
            if (Vector2.Distance(AxeComponent.transform.position, transform.position) < 1f)
            {
                Destroy(AxeComponent, 0);
                animator.SetTrigger("isSwordAxe");
                Invoke("Teleport", 2f);
                Invoke("EndAttack", AttackEndtime);
            }
        }
        if (SwordComponent)
        {
            SwordComponent.transform.position = Vector2.MoveTowards(SwordComponent.transform.position, transform.position, 10f * Time.deltaTime);
            if (Vector2.Distance(SwordComponent.transform.position, transform.position) < 1f)
            {
                Destroy(SwordComponent, 0);
            }
        }
    }

    private void Attack()
    {
        AxeComponent = GameObject.Instantiate(AxeComponentPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        AxeComponent.transform.SetParent(canvas.transform);
        AxeComponent.transform.position = AxeTrans.transform.position;
        AxeComponent.transform.localScale = new Vector3(-1, -1, 1);

        animator.SetBool("isAttacking", true);
        inputScript.canMove = false;
        inputScript.move = 0;
    }
    private void Attack2()
    {
        inputScript.BossComponent.SetBool("isDown", false);
        SwordComponent = GameObject.Instantiate(SwordComponentPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        SwordComponent.transform.SetParent(canvas.transform);
        SwordComponent.transform.position = SwordTrans.transform.position;
        SwordComponent.transform.localScale = new Vector3(-1, -1, 1);
    }

    public void Teleport()
    {
        if (inputScript.health > 0)
            transform.position = new Vector2(playerTrans.transform.position.x, transform.position.y);
    }
    public void EndAttack()
    {
        animator.SetBool("isAttacking", false);
        if (transform.localScale.x > 0) inputScript.move = 1; else inputScript.move = -1;
        inputScript.canMove = true;
    }
}
