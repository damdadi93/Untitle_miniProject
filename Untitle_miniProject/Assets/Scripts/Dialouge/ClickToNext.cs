using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickToNext : MonoBehaviour, IPointerClickHandler
{
    public GameObject gameObject;
    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            gameObject.GetComponent<DialogugTalkBubble>().Next();
        }

    }
}
