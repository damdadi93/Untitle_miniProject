using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ComponentScroll : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Scrollbar scrollbar;

    public GameObject OperationUI;

    public float targetPos = 0;
    public bool isdrag = false;

    public void Awake()
    {

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        isdrag = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (scrollbar.value < -0.5f)//스크롤이 너무많이되면 끝냄
        {
            eventData.pointerDrag = null;
            targetPos = 0f;
            isdrag = false;
        }
        else if (scrollbar.value > 1.2f)
        {
            eventData.pointerDrag = null;
            targetPos = 1f;
            isdrag = false;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (scrollbar.value < 0.5f)
        {
            targetPos = 0f;
        }
        else
            targetPos = 1f;
        isdrag = false;
    }

    void Update()
    {
        if (!isdrag)
        {
            if (OperationUI) OperationUI.GetComponent<CanvasGroup>().alpha = Mathf.Lerp(OperationUI.GetComponent<CanvasGroup>().alpha, targetPos, 0.05f);

            GameObject[] ComponentManagers = GameObject.FindGameObjectsWithTag("ComponentManager");
            for (int i = 0; i < ComponentManagers.Length; i++)
                ComponentManagers[i].GetComponent<CanvasGroup>().alpha = Mathf.Lerp(ComponentManagers[i].GetComponent<CanvasGroup>().alpha, 1-targetPos, 0.05f);

            scrollbar.value = Mathf.Lerp(scrollbar.value, targetPos, 0.1f);
            if (targetPos == 1)
            {
                OperationUI.GetComponent<CanvasGroup>().blocksRaycasts = true;
                for (int i = 0; i < ComponentManagers.Length; i++)
                    ComponentManagers[i].GetComponent<CanvasGroup>().blocksRaycasts = false;
            }
            else if (targetPos == 0)
            {
                OperationUI.GetComponent<CanvasGroup>().blocksRaycasts = false;
                for (int i = 0; i < ComponentManagers.Length; i++)
                    ComponentManagers[i].GetComponent<CanvasGroup>().blocksRaycasts = true;
            }
        }
    }
}
