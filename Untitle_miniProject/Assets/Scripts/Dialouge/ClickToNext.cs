using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickToNext : MonoBehaviour, IPointerClickHandler
{
    public GameObject Pro;
    public GameObject Fri;
    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            Debug.Log("Click!");
            Pro.SetActive(!Pro.activeSelf);
            Fri.SetActive(!Fri.activeSelf);
            if (Pro.activeSelf)
            {
                Pro.GetComponentInChildren<DialogugTalkBubble>().Next();
            }
            else if(Fri.activeSelf)
            {
                Fri.GetComponentInChildren<DialogugTalkBubble>().Next();
            }
        }

    }
}
