using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ComponentManager : MonoBehaviour, IDropHandler
{
    public int MoveComponent;//�̵�������Ʈ
    public int JumpCompoent;//����������Ʈ

    public GameObject ComponentParent; //������Ʈ�� ���� ���
    public GameObject MoveComponentPrefab;
    public GameObject JumpComponentPrefab;

    public void OnDrop(PointerEventData eventData)
    {
        if(eventData.pointerDrag != null)
        {
            if (eventData.pointerDrag.GetComponent<ComponentDrag>().ComponentType == "Move") MoveComponent += 1;
            if (eventData.pointerDrag.GetComponent<ComponentDrag>().ComponentType == "Jump") JumpCompoent += 1;
            eventData.pointerDrag.GetComponent<ComponentDrag>().isEnd = true;
            UIUpdate();
        }
    }

    void Awake()
    {
        UIUpdate();
    }

    // Update is called once per frame
    public void UIUpdate()
    {
        Transform[] ComponentList = ComponentParent.GetComponentsInChildren<Transform>();//�ϴ� UI���� ��� �����ϱ�
        if (ComponentList != null)
            for (int i = 1; i < ComponentList.Length; i++)
                if (ComponentList[i] != transform)
                    Destroy(ComponentList[i].gameObject);

        for (int i = 0; i < MoveComponent; i++)//Move UI ����
        {
            GameObject tmpObject = GameObject.Instantiate(MoveComponentPrefab, new Vector3(0,0,0), Quaternion.identity);
            tmpObject.GetComponent<ComponentDrag>().componentmanager = this;
            tmpObject.transform.SetParent(ComponentParent.transform);
            tmpObject.transform.localScale = new Vector3(1, 1, 1);
        }

        for (int i = 0; i < JumpCompoent; i++)//Jump UI ����
        {
            GameObject tmpObject = GameObject.Instantiate(JumpComponentPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            tmpObject.GetComponent<ComponentDrag>().componentmanager = this;
            tmpObject.transform.SetParent(ComponentParent.transform);
            tmpObject.transform.localScale = new Vector3(1, 1, 1);
        }


    }
}
