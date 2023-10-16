using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class ComponentManager : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject Character;

    public int MoveComponent;//이동컴포넌트
    public int JumpCompoent;//점프컴포넌트
    public string AttackComponent = "";

    public GameObject MoveUI;
    public GameObject JumpUI;
    public GameObject AttackUI;

    public GameObject ComponentParent; //컴포넌트들 만들 장소
    public GameObject ComponentCover;
    public GameObject MoveComponentPrefab;
    public GameObject JumpComponentPrefab;
    public GameObject AttackComponentPrefab;

    public int MaxComponentCount;//최대 컴포넌트개수
    public int ComponentCount; //남은 컴포넌트개수
    public GameObject BlankComponentPrefab;

    Color ImageColor;

    public void OnDrop(PointerEventData eventData)
    {
        if (MaxComponentCount ==0 || (MaxComponentCount>0 && ComponentCount>0))
        {
            if (eventData.pointerDrag != null)
            {
                if (eventData.pointerDrag.GetComponent<ComponentDrag>().ComponentType == "Move") MoveComponent += 1;
                if (eventData.pointerDrag.GetComponent<ComponentDrag>().ComponentType == "Jump") JumpCompoent += 1;
                if (eventData.pointerDrag.GetComponent<ComponentDrag>().ComponentType == "Attack") { AttackComponent = eventData.pointerDrag.GetComponent<ComponentDrag>().weapon; }
                eventData.pointerDrag.GetComponent<ComponentDrag>().isEnd = true;
                UIUpdate();
            }
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


        if (MaxComponentCount > 0)//빈 컴포넌트
        {
            ComponentCount = MaxComponentCount - MoveComponent - JumpCompoent;
            if (AttackComponent != "") ComponentCount -= 1;
        }

        for (int i = 0; i < ComponentCount; i++)
        {
            GameObject tmpObject = GameObject.Instantiate(BlankComponentPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            tmpObject.transform.SetParent(ComponentParent.transform);
            tmpObject.transform.localScale = new Vector3(1, 1, 1);
            tmpObject.GetComponent<RectTransform>().localPosition = new Vector3(50, 25, 0);

        }


        if (MoveComponent > 0)
        {//이동 컴포넌트
            if (MoveUI) MoveUI.SetActive(true);

            GameObject CoverObject = GameObject.Instantiate(ComponentCover, new Vector3(0, 0, 0), Quaternion.identity);
            CoverObject.transform.SetParent(ComponentParent.transform);
            CoverObject.transform.localPosition = new Vector3(0, 0, 0);
            CoverObject.transform.localScale = new Vector3(1, 1, 1);
            CoverObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "x" + MoveComponent;

            GameObject tmpObject = GameObject.Instantiate(MoveComponentPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            if (tmpObject.GetComponent<ComponentDrag>()) tmpObject.GetComponent<ComponentDrag>().componentmanager = this;
            tmpObject.transform.SetParent(CoverObject.transform);
            tmpObject.transform.localScale = new Vector3(1, 1, 1);
            tmpObject.GetComponent<RectTransform>().localPosition = new Vector3(50, 25, 0);
        }
        else
        {
            if (MoveUI) MoveUI.SetActive(false);
        }


        if (JumpCompoent > 0)//점프 컴포넌트
        {
            if (JumpUI) JumpUI.SetActive(true);

            GameObject CoverObject = GameObject.Instantiate(ComponentCover, new Vector3(0, 0, 0), Quaternion.identity);
            CoverObject.transform.SetParent(ComponentParent.transform);
            CoverObject.transform.localPosition = new Vector3(0, 0, 0);
            CoverObject.transform.localScale = new Vector3(1, 1, 1);
            CoverObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "x" + JumpCompoent;

            GameObject tmpObject = GameObject.Instantiate(JumpComponentPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            if (tmpObject.GetComponent<ComponentDrag>()) tmpObject.GetComponent<ComponentDrag>().componentmanager = this;
            tmpObject.transform.SetParent(CoverObject.transform);
            tmpObject.transform.localScale = new Vector3(1, 1, 1);
            tmpObject.GetComponent<RectTransform>().localPosition = new Vector3(50, 25, 0);
        }
        else
        {
            if (JumpUI) JumpUI.SetActive(false);
        }

        if (AttackComponent != "")//어택 컴포넌트
        {
            if (AttackUI) AttackUI.SetActive(true);

            GameObject CoverObject = GameObject.Instantiate(ComponentCover, new Vector3(0, 0, 0), Quaternion.identity);
            CoverObject.transform.SetParent(ComponentParent.transform);
            CoverObject.transform.localPosition = new Vector3(0, 0, 0);
            CoverObject.transform.localScale = new Vector3(1, 1, 1);
            CoverObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "";

            GameObject tmpObject = GameObject.Instantiate(AttackComponentPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            tmpObject.GetComponent<ComponentDrag>().componentmanager = this;
            tmpObject.transform.SetParent(CoverObject.transform);
            tmpObject.transform.localScale = new Vector3(1, 1, 1);
            tmpObject.GetComponent<RectTransform>().localPosition = new Vector3(50, 25, 0);
            tmpObject.GetComponent<ComponentDrag>().weapon = AttackComponent;
        }
        else
        {
            if (AttackUI) AttackUI.SetActive(false);
        }
        if (Character)
        {
            Character.GetComponent<Assets.PixelHeroes.Scripts.CharacterScripts.CharacterBuilder>().Weapon = AttackComponent;
            Character.GetComponent<Assets.PixelHeroes.Scripts.CharacterScripts.CharacterBuilder>().Rebuild();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        ImageColor = GetComponent<Image>().color;
        ImageColor.a = 0.5f;
        GetComponent<Image>().color = ImageColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ImageColor = GetComponent<Image>().color;
        ImageColor.a = 0.1f;
        GetComponent<Image>().color = ImageColor;
    }
}
