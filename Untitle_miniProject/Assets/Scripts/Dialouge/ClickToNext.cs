using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickToNext : MonoBehaviour, IPointerClickHandler
{
    public DialogugTalkBubble DialogugTalk;
    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            DialogugTalk.Next();
            var sentence = DialogugTalk.Thesentens;

        }

    }
}
