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
        if (scrollbar.value < -0.5f)//�ʹ� ���� �Ʒ��� �巡�������� �巡�� ������
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
        if (scrollbar.value < 0.5f)//�巡�� �������� �����̻� �Ѿ���� �ش���ġ�� Ÿ��
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
            scrollbar.value = Mathf.Lerp(scrollbar.value, targetPos, 0.1f);//Ÿ����ġ�� �ε巴�� �̵�
    }
}
