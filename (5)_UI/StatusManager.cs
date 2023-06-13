using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //ui 관련 함수를 쓰기위해 선언
[System.Serializable] //인스펙터 창에서 플레이어 인포를 확인하기 위해 코드 추가
public class PlayerInfo //플레이어 정보 클래스
{
    public int LV; //플레이어 레벨
    public int exp; //플레이어 경험치
    public int atk; //플레이어 공격력
    public int def; //플레이어 방어력
    public int hp; //플레이어 체력
}
public class StatusManager : MonoBehaviour
{
    [SerializeField]
    private PlayerInfo playerInfo; // 플레이어 정보 객체
    [SerializeField] private GameObject PlayerinfoPanel; //플레이어 정보 패널 
    [SerializeField] private Text Level_Text; //레벨 텍스트
    [SerializeField] private Text EXP_Text; //exp 텍스트
    [SerializeField] private Text HP_Text; //hp 텍스트
    [SerializeField] private Text ATK_Text; //atk 텍스트
    [SerializeField] private Text DEF_Text; //def 텍스트
    [SerializeField] private Slider HPSLIDER; //HP 슬라이더
    [SerializeField] private Slider EXPSlider; //exp 슬라이더
    public bool isOpenInfoPanel = false; //플레이어 인포 패널을 열었는가?
  
    private void Start()
    {
        PlayerinfoPanel.SetActive(false); //시작할때 플레이어 인포창 해제
        // 플레이어 정보 초기화
        playerInfo = new PlayerInfo();
        playerInfo.LV = 1;
        playerInfo.exp = 0;
        playerInfo.atk = 10;
        playerInfo.def = 5;
        playerInfo.hp = 100;

        // 슬라이더 초기화
        HPSLIDER.maxValue = playerInfo.hp;
        EXPSlider.maxValue = NeedEXP(playerInfo.LV);
    }

    private void updateText()
    {
        Level_Text.text = "Level: " + playerInfo.LV;
        EXP_Text.text = "Exp: " + playerInfo.exp + " / " + NeedEXP(playerInfo.LV);
        HP_Text.text = "HP: " + playerInfo.hp;
        ATK_Text.text = "ATK: " + playerInfo.atk;
        DEF_Text.text = "DEF: " + playerInfo.def;

        HPSLIDER.value = playerInfo.hp;
        EXPSlider.value = playerInfo.exp;
    }
    private int NeedEXP(int level)
    {
        // 필요 경험치 계산
        int StartEXP = 100; // 기본 경험치
        int EXPMUL = 50; // 경험치 증가 배수
        int AfterEXP = StartEXP + (level - 1) * EXPMUL;
        return AfterEXP;
    }
    private void LevelUp() //레벨업 할때 불러오는 함수
    {
        playerInfo.LV++;
        playerInfo.exp = 0;
        playerInfo.hp += 10;
        playerInfo.atk += 5;
        playerInfo.def += 3;

        HPSLIDER.maxValue = playerInfo.hp;
        EXPSlider.maxValue = NeedEXP(playerInfo.LV);

        updateText();
    }

    public void GetEXP(int amount) //경험치를 얻을때 불러오는 함수
    {
        playerInfo.exp += amount;
        if (playerInfo.exp >= EXPSlider.maxValue)
            LevelUp();

        updateText();
    }

    // Update is called once per frame
    void Update()
    {
        // 텍스트 업데이트
        updateText();
        if (Input.GetKeyDown(KeyCode.R))
        {
            isOpenInfoPanel = !isOpenInfoPanel; // false 면 true 로 true 면 false 로 bool 값 변환
            if (isOpenInfoPanel) //값이 true 일때
            {
                PlayerinfoPanel.SetActive(true); //창 열기
            }
            else //false 일때
            {
                PlayerinfoPanel.SetActive(false); //창 닫기
            }
        }
    }
}
