using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class ComponentManager : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public int MoveComponent;//이동컴포넌트
    public int JumpCompoent;//점프컴포넌트

    public GameObject ComponentParent; //컴포넌트들 만들 장소
    public GameObject ComponentCover; 
    public GameObject MoveComponentPrefab;
    public GameObject JumpComponentPrefab;

    Color ImageColor;

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
        ImageColor = GetComponent<Image>().color;
        UIUpdate();
    }

    // Update is called once per frame
    public void UIUpdate()
    {
        Transform[] ComponentList = ComponentParent.GetComponentsInChildren<Transform>();//일단 UI들을 모두 제거하기
        if (ComponentList != null)
            for (int i = 1; i < ComponentList.Length; i++)
                if (ComponentList[i] != transform)
                    Destroy(ComponentList[i].gameObject);


        if (MoveComponent > 0) {//이동 컴포넌트
            GameObject CoverObject = GameObject.Instantiate(ComponentCover, new Vector3(0, 0, 0), Quaternion.identity);
            CoverObject.transform.SetParent(ComponentParent.transform);
            CoverObject.transform.localScale = new Vector3(1, 1, 1);
            CoverObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "x" + MoveComponent;

            GameObject tmpObject = GameObject.Instantiate(MoveComponentPrefab, new Vector3(0,0,0), Quaternion.identity);
            tmpObject.GetComponent<ComponentDrag>().componentmanager = this;
            tmpObject.transform.SetParent(CoverObject.transform);
            tmpObject.transform.localScale = new Vector3(1, 1, 1);
            tmpObject.GetComponent<RectTransform>().localPosition = new Vector3(50, 25, 0);
        }

        if (JumpCompoent > 0)//점프 컴포넌트
        {
            GameObject CoverObject = GameObject.Instantiate(ComponentCover, new Vector3(0, 0, 0), Quaternion.identity);
            CoverObject.transform.SetParent(ComponentParent.transform);
            CoverObject.transform.localScale = new Vector3(1, 1, 1);
            CoverObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "x" + JumpCompoent;

            GameObject tmpObject = GameObject.Instantiate(JumpComponentPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            tmpObject.GetComponent<ComponentDrag>().componentmanager = this;
            tmpObject.transform.SetParent(CoverObject.transform);
            tmpObject.transform.localScale = new Vector3(1, 1, 1);
            tmpObject.GetComponent<RectTransform>().localPosition = new Vector3(50, 25, 0);
        }

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        ImageColor.a = 0.5f;
        GetComponent<Image>().color = ImageColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ImageColor.a = 0.1f;
        GetComponent<Image>().color = ImageColor;
    }
}
