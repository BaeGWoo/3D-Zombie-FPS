using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    //카메라 x축의 회전속도
    [SerializeField] float Xspeed=5.0f;
    //카메라 y축의 회전속도
    [SerializeField] float Yspeed = 3.0f;

    //내부에 사용할 x축 회전량을 따로 정의
    [SerializeField] float eulerAngleX;
    [SerializeField] float eulerAngleY;


    [SerializeField] float moveSpeed;//이동 속도
    private Vector3 moveForce;//이동하는 힘

    float gravity = -9.81f;


    private CharacterController characterControl;

    public Transform cameraTransform;
    private ParticleSystem particle;
    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        characterControl = GetComponent<CharacterController>();

        particle = GetComponentInChildren<ParticleSystem>();
    }


    void Update()
    {

        UpdateRotate(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        if(Input.GetButtonDown("Fire1"))
        {
            particle.Play();
        }

        if (!characterControl.isGrounded)
        {
            moveForce.y += gravity * Time.deltaTime;
        }
        else
        {
            moveForce.y = 0.1f;
        }
        MoveTo(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")));
        characterControl.Move(moveForce * Time.deltaTime);

    }


    public void MoveTo(Vector3 direction)
    {
        //이동 방향=캐릭터의 회전 값* 방향 값
        direction = transform.rotation * new Vector3(direction.x, 0, direction.z);

        //이동하는 힘=이동 방향*속도
        moveForce = new Vector3(direction.x * moveSpeed, moveForce.y, direction.z * moveSpeed);
    }

    public void UpdateRotate(float mouseX, float mouseY)
    {
        eulerAngleY += mouseX * Yspeed;//마우스 좌우 이동으로 카메라 y축 회전
                                       //마우스를 아래로 내리면 -로 음수가 되는데 오브젝트의 x축이 +방향으로 회전해야 아래를 보기 때문에 -로 설정
        eulerAngleX -= mouseY * Xspeed;//마우스 위아래 이동으로 카메라 x축 회전

        eulerAngleX = ClampAngle(eulerAngleX, -80, 50);

        transform.rotation = Quaternion.Euler(transform.rotation.x,eulerAngleY,0);

        cameraTransform.rotation = Quaternion.Euler(eulerAngleX, transform.eulerAngles.y, 0);
    }

    public float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360)
            angle += 360;

        if (angle > 360)
            angle -= 360;

        return Mathf.Clamp(angle, min, max);
    }

}
