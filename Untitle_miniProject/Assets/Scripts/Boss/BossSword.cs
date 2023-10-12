using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSword : MonoBehaviour
{
    private Boss inputScript; // 입력
    private Rigidbody2D rigid; // 리지드바디
    private Animator animator; // 애니메이터

    public GameObject canvas;
    public GameObject SwordTrans;
    public GameObject SwordComponent;
    public GameObject SwordComponentPrefab;

    public float Attackcul; //공격쿨타임
    public float AttackEndtime = 1f; //공격하고 다시 움직일때까지 시간

    void Awake()
    {
        inputScript = GetComponent<Boss>();
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (inputScript.attack)
        {
            inputScript.attack = false;
            if (inputScript.Attackcul < 0 && inputScript.Skillcul > 0)
            {
                inputScript.BossComponent.SetBool("isDown",true);
                inputScript.Attackcul = Attackcul;
                Invoke("Attack", 1f);
            }
        }

        if (SwordComponent)
        {
            SwordComponent.transform.position = Vector2.MoveTowards(SwordComponent.transform.position, transform.position, 10f * Time.deltaTime);
            if (Vector2.Distance(SwordComponent.transform.position, transform.position) < 1f) {
                Destroy(SwordComponent, 0);
                animator.SetTrigger("isAttack");
                Invoke("EndAttack", AttackEndtime);
            }
        }
    }

    private void Attack()
    {
        inputScript.BossComponent.SetBool("isDown",false);
        SwordComponent = GameObject.Instantiate(SwordComponentPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        SwordComponent.transform.SetParent(canvas.transform);
        SwordComponent.transform.position = SwordTrans.transform.position;
        SwordComponent.transform.localScale = new Vector3(-1, -1, 1);

        animator.SetBool("isAttacking", true);
        inputScript.canMove = false;
        inputScript.move = 0;
    }
    public void EndAttack()
    {
        animator.SetBool("isAttacking", false);
        if (transform.localScale.x > 0) inputScript.move = 1; else inputScript.move = -1;
        inputScript.canMove = true;
    }
}
