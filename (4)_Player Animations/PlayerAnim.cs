using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    private Animator playeranim; //플레이어 애니메이션 컴포넌트
    public float minDistance = 0.01f; //최소 이동거리
    public bool isWalk=false; //걸었는지 여부
    public bool isRun=false; //뛰었는지 여부
    private PlayerManager theplayer; //float LeftRight, FrontBack 값을 가져오기 위해
    // Start is called before the first frame update
    void Start()
    {
        theplayer = GetComponent<PlayerManager>(); //playermanager 스크립트를 참조하기위해
        playeranim = GetComponent<Animator>(); //애니메이터 컴포넌트를 가져오자
    }

    // Update is called once per frame
    void Update()
    {
        PlayerWalk(); 
        Run();
        Slide();
        //매프레임 마다 입력을 받고 애니메이션 실행
    }
    private void PlayerWalk() //플레이어가 걷는 스크립트
    {
        //LeftRight와 FronkBack 는 Lec 3에서 봤었는데 -1~ 1 의 float 값을 가집니다.
        //해당 값을 기준으로 조건문을 짜서 걸었는지 말았는지 값을 측정합니다.
        if (theplayer.LeftRight >= 0.1f) 
        {
            isWalk = true;
        }
        else if (theplayer.LeftRight <= -0.1f)
        {
            isWalk = true;
        }
        else if (theplayer.FrontBack >= 0.1f)
        {
            isWalk = true;
        }
        else if (theplayer.FrontBack <= -0.1f)
        {
            isWalk = true;
        }
        else
            isWalk = false;

        playeranim.SetBool("Walk", isWalk); //Walk의 애니메이션의 bool값을 조정해서 애니메이션 재생 여부를 결정
    }
    private void Run() //뛰기
    {
        if (Input.GetKey(KeyCode.LeftShift)) //좌측 시프트 키를 누르고 있으면
        {
            isRun = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift)) //죄측 시프트 키를 때면
        {
            isRun = false;
        }

        playeranim.SetBool("Run", isRun && isWalk); //애니메이션 재생
    }
    private void Slide() //슬라이드
    {
        if(Input.GetKeyDown(KeyCode.Space)) //스페이스바 키를 누르면
        {
            playeranim.SetTrigger("Slide"); //슬라이드 애니메이션 재생
        }
    }
}
