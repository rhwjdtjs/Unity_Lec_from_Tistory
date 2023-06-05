using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float LeftRight; //움직임을 받을 변수입니다.
    public float FrontBack; //움직임을 받을 변수입니다.
    private Rigidbody theRigid; //플레이어를 움직이기 위해 리지드 바디를 사용합니다.
    private Camera thecamera; //Main camera 를 가져옵니다.
    private float currentcameraRot;
    [SerializeField] float moveSpeed; //이동속도를 지정해줄 변수입니다.
    [SerializeField] private float cameraSensitivity; //카메라 회전 감도 설정
    [SerializeField] private float camera_Y_Angle; //y축 카메라 각도 설정

    private void Start()
    {
        theRigid = GetComponent<Rigidbody>(); //컴포넌트를 가져옵시다.
        thecamera = FindObjectOfType<Camera>(); //메인카메라를 하이라키에서 찾아서 가져옵니다.
    }
    private void Update()
    {
        PlayerMove(); //함수를 불러와 매프레임마다 입력을 받읍시다.
        CameraRotation(); //카메라 회전
        CharacterRotation(); //캐릭터 회전
    }
   
    private void PlayerMove() //플레이어의 움직임을 담당하는 함수입니다.
    {
        LeftRight = Input.GetAxis("Horizontal"); //왼쪽 오른쪽으로 즉 키보드 ad 값을 입력받습니다.
        FrontBack = Input.GetAxis("Vertical"); //앞 뒤 즉 키보드 ws 값을 입력받습니다.
        //콘솔창에 float 값을 출력해봅시다. Update 문에 해당 디버그 문을 쓰면 매프레임마다 콘솔창에 뛰웁니다.
        //입력을 하지 않으면 값이 0만 출력될테니 if 문을 써서 0이 아닐때만 콘솔창에 디버그가 출력되도록 합시다.
        if (LeftRight != 0)
            Debug.Log(LeftRight);
        if (FrontBack != 0)
            Debug.Log(FrontBack);
        // 캐릭터가 바라보는 방향으로 이동 벡터를 계산
        Vector3 moveDirection = transform.forward * FrontBack + transform.right * LeftRight;

        // 이동 벡터에 이동 속도를 곱하여 플레이어를 이동시킴
        theRigid.velocity = moveDirection * moveSpeed;
    }
    private void CameraRotation()
    {
        float RotationX = Input.GetAxis("Mouse Y") * cameraSensitivity; // 마우스의 Y축 이동값에 카메라 감도를 곱하여 회전량을 얻습니다.
        currentcameraRot -= RotationX; // 현재 카메라의 회전 값을 회전량에서 빼서 갱신합니다.
        if (currentcameraRot < -camera_Y_Angle) // 현재 카메라 회전 값이 아래로 허용된 범위를 초과하면
            currentcameraRot = -camera_Y_Angle; // 카메라 회전 값을 아래로 허용된 범위로 제한합니다.
        else if (currentcameraRot > camera_Y_Angle) // 현재 카메라 회전 값이 위로 허용된 범위를 초과하면
            currentcameraRot = camera_Y_Angle; // 카메라 회전 값을 위로 허용된 범위로 제한합니다.
        thecamera.transform.localRotation = Quaternion.Euler(currentcameraRot, 0f, 0f); // 제한된 회전 값을 이용하여 카메라의 로컬 회전을 설정합니다.
    }

    private void CharacterRotation()
    {
        float RotationY = Input.GetAxis("Mouse X") * cameraSensitivity; // 마우스의 X축 이동값에 카메라 감도를 곱하여 회전량을 얻습니다.
        Quaternion rotation = Quaternion.AngleAxis(RotationY, Vector3.up); // Y축을 기준으로 회전하는 Quaternion을 생성합니다.
        theRigid.MoveRotation(theRigid.rotation * rotation); // 캐릭터의 회전에 회전 Quaternion을 적용하여 회전합니다.
    }
}
