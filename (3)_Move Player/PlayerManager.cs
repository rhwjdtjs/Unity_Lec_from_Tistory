using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private float LeftRight; //움직임을 받을 변수입니다.
    private float FrontBack; //움직임을 받을 변수입니다.
    private Vector3 moveVector; //움직이기 위한 벡터값
    private Rigidbody theRigid; //플레이어를 움직이기 위해 리지드 바디를 사용합니다.
    [SerializeField] float moveSpeed; //이동속도를 지정해줄 변수입니다.
    private void Start()
    {
        theRigid = GetComponent<Rigidbody>(); //컴포넌트를 가져옵시다.
    }
    private void Update()
    {
        PlayerMove(); //함수를 불러와 매프레임마다 입력을 받읍시다.
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
        moveVector = new Vector3(LeftRight, 0, FrontBack); //왼쪽 오른쪽은 X 값으로 이동, 앞 뒤는 Z 값으로 이동합니다. Y값은 점프를 하지 않는 이상 값이 바뀌면 안되어 0으로 고정시킵니다.
        theRigid.velocity = moveVector * moveSpeed;//플레이어를 벡터값만큼 movespeed 속도로 이동시킵니다.

    }
}
