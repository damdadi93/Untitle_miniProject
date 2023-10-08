using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ComponentScroll : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Scrollbar scrollbar;
    float targetPos;
    bool isdrag = false;
    public void OnBeginDrag(PointerEventData eventData)
    {
        isdrag = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (scrollbar.value < -0.5f)//너무 위나 아래로 드래그했으면 드래그 끝내기
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
        if (scrollbar.value < 0.5f)//드래그 끝났을때 절반이상 넘어갔으면 해당위치로 타겟
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
            //scrollbar.value = targetPos;
            scrollbar.value = Mathf.Lerp(scrollbar.value, targetPos, 0.1f);//타겟위치로 부드럽게 이동
    }
}
