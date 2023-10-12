using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class BossAxe : MonoBehaviour
{
    private Boss inputScript; // �Է�
    private Rigidbody2D rigid; // ������ٵ�
    private Animator animator; // �ִϸ�����

    public GameObject canvas;
    public GameObject AxeTrans;
    public GameObject AxeComponent;
    public GameObject AxeComponentPrefab;

    public GameObject SpikePrefab;

    public float Attackcul = 10f; //������Ÿ��
    public float AttackEndtime = 5f; //�����ϰ� �ٽ� �����϶����� �ð�

    public CinemachineVirtualCamera CMCamera;

    void Awake()
    {
        inputScript = GetComponent<Boss>();
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (inputScript.skill == 2)
        {
            inputScript.skill = 0;

            inputScript.BossComponent.SetBool("isDown", true);
            inputScript.Skillcul = Attackcul;
            Invoke("Attack", 1f);
        }

        if (AxeComponent)
        {
            AxeComponent.transform.position = Vector2.MoveTowards(AxeComponent.transform.position, transform.position, 10f * Time.deltaTime);
            if (Vector2.Distance(AxeComponent.transform.position, transform.position) < 1f)
            {
                Destroy(AxeComponent, 0);
                animator.SetTrigger("isAxe");
                Invoke("instantiateSpike", 2f);
                Invoke("EndAttack", AttackEndtime);
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
        inputScript.BossComponent.SetBool("isDown", false);
    }


    public void instantiateSpike()
    {
        if (inputScript.health > 0)
        {
            CMCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 1;
            for (int i = 0; i < 10; i++)
            {
                Instantiate(SpikePrefab, new Vector3(Random.Range(-20.0f, 20.0f), Random.Range(10.0f, 20.0f), 0), SpikePrefab.transform.rotation);
            }
        }
    }
    public void EndAttack()
    {
        CMCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 0;
        animator.SetBool("isAttacking", false);
        if (transform.localScale.x > 0) inputScript.move = 1; else inputScript.move = -1;
        inputScript.canMove = true;
    }
}
