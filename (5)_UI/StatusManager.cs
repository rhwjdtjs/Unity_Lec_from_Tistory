using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //ui ���� �Լ��� �������� ����
[System.Serializable] //�ν����� â���� �÷��̾� ������ Ȯ���ϱ� ���� �ڵ� �߰�
public class PlayerInfo //�÷��̾� ���� Ŭ����
{
    public int LV; //�÷��̾� ����
    public int exp; //�÷��̾� ����ġ
    public int atk; //�÷��̾� ���ݷ�
    public int def; //�÷��̾� ����
    public int hp; //�÷��̾� ü��
}
public class StatusManager : MonoBehaviour
{
    [SerializeField]
    private PlayerInfo playerInfo; // �÷��̾� ���� ��ü
    [SerializeField] private GameObject PlayerinfoPanel; //�÷��̾� ���� �г� 
    [SerializeField] private Text Level_Text; //���� �ؽ�Ʈ
    [SerializeField] private Text EXP_Text; //exp �ؽ�Ʈ
    [SerializeField] private Text HP_Text; //hp �ؽ�Ʈ
    [SerializeField] private Text ATK_Text; //atk �ؽ�Ʈ
    [SerializeField] private Text DEF_Text; //def �ؽ�Ʈ
    [SerializeField] private Slider HPSLIDER; //HP �����̴�
    [SerializeField] private Slider EXPSlider; //exp �����̴�
    public bool isOpenInfoPanel = false; //�÷��̾� ���� �г��� �����°�?
  
    private void Start()
    {
        PlayerinfoPanel.SetActive(false); //�����Ҷ� �÷��̾� ����â ����
        // �÷��̾� ���� �ʱ�ȭ
        playerInfo = new PlayerInfo();
        playerInfo.LV = 1;
        playerInfo.exp = 0;
        playerInfo.atk = 10;
        playerInfo.def = 5;
        playerInfo.hp = 100;

        // �����̴� �ʱ�ȭ
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
        // �ʿ� ����ġ ���
        int StartEXP = 100; // �⺻ ����ġ
        int EXPMUL = 50; // ����ġ ���� ���
        int AfterEXP = StartEXP + (level - 1) * EXPMUL;
        return AfterEXP;
    }
    private void LevelUp() //������ �Ҷ� �ҷ����� �Լ�
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

    public void GetEXP(int amount) //����ġ�� ������ �ҷ����� �Լ�
    {
        playerInfo.exp += amount;
        if (playerInfo.exp >= EXPSlider.maxValue)
            LevelUp();

        updateText();
    }

    // Update is called once per frame
    void Update()
    {
        // �ؽ�Ʈ ������Ʈ
        updateText();
        if (Input.GetKeyDown(KeyCode.R))
        {
            isOpenInfoPanel = !isOpenInfoPanel; // false �� true �� true �� false �� bool �� ��ȯ
            if (isOpenInfoPanel) //���� true �϶�
            {
                PlayerinfoPanel.SetActive(true); //â ����
            }
            else //false �϶�
            {
                PlayerinfoPanel.SetActive(false); //â �ݱ�
            }
        }
    }
}
