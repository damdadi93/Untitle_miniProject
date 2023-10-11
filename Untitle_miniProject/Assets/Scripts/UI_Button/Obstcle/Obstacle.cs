using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    

    [Space(10f)]
    [Header("Cashing")]
    public GameObject obstacleObject;
    public Transform obstacleTransform;

    //오브젝트의 처음과 끝좌표

   


    [Space(10f)]
    [Header("CheckFunction")]

    public bool isRotation = false;
    public bool isMove_H = false;
    public bool isMove_V = false;

    //x축과 y축을 설정하면 본래의 위치에서 범위만큼 반복이동가능하게
    [Header("Length")]
    [Space(10f)]
    [Range(-10f, 10f)]
    public float lineX;
    [Range(-10f, 10f)]
    public float lineY;

    [Header("Speed")]
    [Space(1f)]
    [Range(0f, 100f)]
    public float rotationSpeed;
    [Range(0f, 10f)]
    public float moveSpeed_H;
    [Range(0f, 10f)]
    public float moveSpeed_V;


    //오브젝트의 길이
    //[Space(10f)]
    //[Range(0f, 100f)]
    //public float obstacleLength;

    //public bool toggleSwitch = false;



    //배치한장애물의 위치를 가져오자
    public Vector3 firstPosition;

    void Start()
    {
        obstacleObject = GetComponent<GameObject>();
        obstacleTransform = GetComponent<Transform>();
        firstPosition = obstacleTransform.position;


    }

    private void FixedUpdate()
    {
        
    }
    void Update()
    {
        
        Debug.Log("초기위치" + firstPosition);
        Debug.Log(obstacleTransform.position);
        Debug.Log("trans.position =" + firstPosition);
        RepeatMove();
        Rotation();
    }

    //public void ToggleMethod()
    //{
    //    toggleSwitch = !toggleSwitch;
    //    if (toggleSwitch)
    //    {
    //        // toggleSwitch가 true일 때 실행할 코드
    //        Debug.Log("메서드가 활성화되었습니다.");
    //    }
    //    else
    //    {
    //        // toggleSwitch가 false일 때 실행할 코드
    //        Debug.Log("메서드가 비활성화되었습니다.");
    //    }
    //}
    

    public void RepeatMove()
    {
        if(isMove_H)
        {
            transform.position = new Vector3(firstPosition.x + Mathf.PingPong(Time.time * moveSpeed_H, lineX), transform.position.y, 0f);
            //if(!isMove_H)
            //{
            //    Vector3 newPosition = firstPosition + new Vector3(Mathf.PingPong(Time.time * moveSpeed_H, lineX), Mathf.PingPong(Time.time * moveSpeed_V, lineY), 0);
            //    transform.position = firstPosition;
            //}
           
        }
        else if(isMove_V)
        {
            transform.position = new Vector3(transform.position.x , firstPosition.y + Mathf.PingPong(Time.time * moveSpeed_V, lineY), 0f);
            //if (!isMove_V)
            //{
            //    Vector3 newPosition = firstPosition + new Vector3(Mathf.PingPong(Time.time * moveSpeed_H, lineX), Mathf.PingPong(Time.time * moveSpeed_V, lineY), 0);
            //    transform.position = firstPosition;
            //}
        }
        else if(isMove_H && isMove_V)
        {
            transform.position = new Vector3( Mathf.PingPong(Time.time * moveSpeed_H, lineX), Mathf.PingPong(Time.time * moveSpeed_V, lineY), 0f);
            //if (!isMove_H && !isMove_V)
            //{
            //    Vector3 newPosition = firstPosition + new Vector3(Mathf.PingPong(Time.time * moveSpeed_H, lineX), Mathf.PingPong(Time.time * moveSpeed_V, lineY), 0);
            //    transform.position = firstPosition;
            //}
        }
      
    }

    public void Rotation()
    {
        if (isRotation)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, Time.time * rotationSpeed);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }


}
