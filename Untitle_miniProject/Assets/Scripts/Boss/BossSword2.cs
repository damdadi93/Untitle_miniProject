using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSword2 : MonoBehaviour
{
    private Boss inputScript; // 입력
    private Rigidbody2D rigid; // 리지드바디
    private Animator animator; // 애니메이터

    public GameObject canvas;
    public GameObject SwordTrans;
    public GameObject SwordComponent;
    public GameObject SwordComponent2;
    public GameObject SwordComponentPrefab;

    public GameObject SwordPrefab;

    public float Attackcul = 10f; //공격쿨타임
    public float AttackEndtime = 3f; //공격하고 다시 움직일때까지 시간

    void Awake()
    {
        inputScript = GetComponent<Boss>();
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (inputScript.skill==1)
        {
            inputScript.skill = 0;

            inputScript.BossComponent.SetBool("isDown", true);
            inputScript.Skillcul = Attackcul;
            Invoke("Attack", 1f);
            Invoke("Attack2", 1.5f);
        }

        if (SwordComponent)
        {
            SwordComponent.transform.position = Vector2.MoveTowards(SwordComponent.transform.position, transform.position, 10f * Time.deltaTime);
            if (Vector2.Distance(SwordComponent.transform.position, transform.position) < 1f)
            {
                Destroy(SwordComponent, 0);
                animator.SetTrigger("isSword2");
                Invoke("instantiateSword", 1.5f);
                Invoke("instantiateSword", 2);
                Invoke("EndAttack", AttackEndtime);
            }
        }
        if (SwordComponent2)
        {
            SwordComponent2.transform.position = Vector2.MoveTowards(SwordComponent2.transform.position, transform.position, 10f * Time.deltaTime);
            if (Vector2.Distance(SwordComponent2.transform.position, transform.position) < 1f)
            {
                Destroy(SwordComponent2, 0);
            }
        }
    }

    private void Attack()
    {
        SwordComponent = GameObject.Instantiate(SwordComponentPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        SwordComponent.transform.SetParent(canvas.transform);
        SwordComponent.transform.position = SwordTrans.transform.position;
        SwordComponent.transform.localScale = new Vector3(-1, -1, 1);

        animator.SetBool("isAttacking", true);
        inputScript.canMove = false;
        inputScript.move = 0;
    }
    private void Attack2()
    {
        inputScript.BossComponent.SetBool("isDown", false);
        SwordComponent2 = GameObject.Instantiate(SwordComponentPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        SwordComponent2.transform.SetParent(canvas.transform);
        SwordComponent2.transform.position = SwordTrans.transform.position;
        SwordComponent2.transform.localScale = new Vector3(-1, -1, 1);
    }

    public void instantiateSword()
    {
        if (inputScript.health > 0)
            Instantiate(SwordPrefab, transform.position+new Vector3(0,1,0), transform.rotation);
    }
    public void EndAttack()
    {
        animator.SetBool("isAttacking", false);
        if (transform.localScale.x > 0) inputScript.move = 1; else inputScript.move = -1;
        inputScript.canMove = true;
    }
}
