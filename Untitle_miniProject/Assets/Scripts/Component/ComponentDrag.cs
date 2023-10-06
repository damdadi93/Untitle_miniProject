using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ComponentDrag : MonoBehaviour, IEndDragHandler, IDragHandler, IBeginDragHandler
{
    Camera Cam;
    public string ComponentType;
    private CanvasGroup canvasGroup;
    Transform startParent;
    public bool isEnd = false;//드래그 완료
    public ComponentManager componentmanager;


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
    }

    public void OnDrag(PointerEventData eventData)
    {
        GetComponent<RectTransform>().position = (Vector2)Cam.ScreenToWorldPoint(Input.mousePosition);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(startParent);
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;

        if (isEnd)
        {
            if (ComponentType == "Move") componentmanager.MoveComponent -= 1;
            if (ComponentType == "Jump") componentmanager.JumpCompoent -= 1;
            componentmanager.UIUpdate();
        }
    }

}
