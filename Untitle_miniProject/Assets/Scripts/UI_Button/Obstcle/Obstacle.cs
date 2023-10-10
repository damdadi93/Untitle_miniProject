using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float startAngle = 0f;
    public float endAngle = 0f;
    public float rotationSpeed = 0f;
    public float rotationMaxSpeed = 100f;

    public float moveSpeeed = 50;

    public GameObject obstacle;
    private float currentAngle;

    bool rotate = false;
    bool move = false;


    // Start is called before the first frame update
    void Start()
    {
        obstacle = GetComponent<GameObject>();
        rotationSpeed = rotationMaxSpeed;
    }

    private void FixedUpdate()
    {
       
       
        if(rotationSpeed <= 0 )
        {
            this.transform.Rotate(0, 0, rotationSpeed);
        }
        else if(rotationSpeed >= 1 )
        {
            rotationSpeed = rotationSpeed * 0.97f;
            this.transform.Rotate(0, 0, rotationSpeed);
        }
    }
    // Update is called once per frame
    void Update()
    {       

        //transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        //float currentAngle = transform.rotation.eulerAngles.z;
        //currentAngle = (currentAngle > 180) ? currentAngle - 360 : currentAngle;

        //if (currentAngle < startAngle || currentAngle > endAngle)
       // {
            // 현재 각도가 허용된 범위를 벗어나면 회전 방향을 바꿉니다.
           // rotationSpeed *= -1;
       // }
    }
}
