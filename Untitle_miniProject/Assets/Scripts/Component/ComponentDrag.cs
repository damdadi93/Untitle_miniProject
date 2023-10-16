using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ComponentDrag : MonoBehaviour, IEndDragHandler, IDragHandler, IBeginDragHandler
{
    Camera Cam;
    public string ComponentType;
    private CanvasGroup canvasGroup;
    Transform startParent;
    public bool isEnd = false;//�巡�� �Ϸ�
    public ComponentManager componentmanager;
    public string weapon;


    void Awake() { 
        Cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        canvasGroup = GetComponent<CanvasGroup>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        startParent = transform.parent;
        transform.SetParent(GameObject.FindGameObjectWithTag("Main Canvas").transform);
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;

        if (ComponentType == "Move") componentmanager.MoveComponent -= 1;
        if (ComponentType == "Jump") componentmanager.JumpCompoent -= 1;
        if (ComponentType == "Attack") { componentmanager.AttackComponent = ""; }
        componentmanager.UIUpdate();

        GameObject[] ComponentManagers = GameObject.FindGameObjectsWithTag("ComponentManager");//��� ������Ʈ �Ŵ��� Ȱ��ȭ
        for (int i = 0; i < ComponentManagers.Length; i++)
        {
            if (ComponentManagers[i].GetComponent<ComponentManager>().MaxComponentCount == 0 || (ComponentManagers[i].GetComponent<ComponentManager>().ComponentCount > 0 && ComponentManagers[i].GetComponent<ComponentManager>().MaxComponentCount > 0))
            {
                ComponentManagers[i].GetComponent<Image>().color = new Color(1, 1, 1, 0.3f);
            }
            else
            {
                ComponentManagers[i].GetComponent<Image>().color = new Color(1, 0, 0, 0.3f);
            }
            ComponentManagers[i].GetComponent<Image>().enabled = true;
        }
        componentmanager.GetComponent<Image>().enabled = false; //�� ������Ʈ�� ������Ʈ �Ŵ����� ��Ȱ��ȭ
    }

    public void OnDrag(PointerEventData eventData)
    {
        GetComponent<RectTransform>().position = (Vector2)Cam.ScreenToWorldPoint(Input.mousePosition);//���콺 ���󰡵���
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(startParent);
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;

        if (!isEnd)
        {
            if (ComponentType == "Move") componentmanager.MoveComponent += 1;
            if (ComponentType == "Jump") componentmanager.JumpCompoent += 1;
            if (ComponentType == "Attack") { componentmanager.AttackComponent = weapon; }

            componentmanager.UIUpdate();
        }
        GameObject[] ComponentManagers = GameObject.FindGameObjectsWithTag("ComponentManager");//��� ������Ʈ �Ŵ��� ��Ȱ��ȭ
        for (int i = 0; i < ComponentManagers.Length; i++)
            ComponentManagers[i].GetComponent<Image>().enabled = false;

        Destroy(gameObject, 0f);
    }

}
