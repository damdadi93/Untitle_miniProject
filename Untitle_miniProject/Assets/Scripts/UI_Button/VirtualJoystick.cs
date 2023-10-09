using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class VirtualJoystick : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField]
    private RectTransform lever;
    private RectTransform rectTransform;

    [SerializeField,  Range(10,150)] 
    float leverRange;

    private Vector2 inputDirection;
    private bool isInput;

    //private TPSCharacterController controller;

    public void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        ControlJoystickLever(eventData);
        isInput = true;
        Debug.Log("Begin");
    }

    public void OnDrag(PointerEventData eventData)
    {
        ControlJoystickLever(eventData);
        
        Debug.Log("Drag");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        lever.anchoredPosition = Vector2.zero;
        isInput = false;
        Debug.Log("End");
    }

    public void ControlJoystickLever(PointerEventData eventData)
    {
        var inputPos = eventData.position - rectTransform.anchoredPosition;
        var inputVector = inputPos.magnitude < leverRange ? inputPos : inputPos.normalized * leverRange;
        lever.anchoredPosition = inputVector;
        inputDirection = inputVector / leverRange;
    }

    private void InputControlVector()
    {
        
        Debug.Log(inputDirection.x + " / " + inputDirection.y);
    }

   
    void Start()
    {
        
    }

    
    void Update()
    {
        if(isInput)
        {
            InputControlVector();
        }
    }
}
