using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
   

    //마우스 회전 속도
    [SerializeField] float angleSpeed = 3.5f;

    //내부에 사용할 x축 회전량을 따로 정의
    [SerializeField] float xRotation;

    

   
    void Update()
    {
        MouseRotation();



    }


    //마우스 움직임에 따라 카메라를 회전 시키는 함수
    private void MouseRotation()
    {
        //좌우로 움직인 마우스의 이동량 * 속도에 따라 카메라가 좌우로 회전하는 값
        float ySize = Input.GetAxis("Mouse X") * angleSpeed;

        //현재 y축 회전값에 더한 새로운 회전 각도 계산
        float y = transform.eulerAngles.y + ySize;

        // 위아래로 움직이는 마우스의 이동량 * 속도에 따라 카메라가 위아래로 회전하는 값
        float xSize = -Input.GetAxis("Mouse Y") * angleSpeed;

        //-45는 하늘 방향, 80은 바닥 방향
        xRotation = Mathf.Clamp(xRotation + xSize, -45 , 80);

        transform.eulerAngles = new Vector3(xRotation, y, 0);
    }


}
