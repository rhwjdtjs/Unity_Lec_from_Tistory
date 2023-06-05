using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    private Animator playeranim; //�÷��̾� �ִϸ��̼� ������Ʈ
    public float minDistance = 0.01f; //�ּ� �̵��Ÿ�
    public bool isWalk=false; //�ɾ����� ����
    public bool isRun=false; //�پ����� ����
    private PlayerManager theplayer; //float LeftRight, FrontBack ���� �������� ����
    // Start is called before the first frame update
    void Start()
    {
        theplayer = GetComponent<PlayerManager>(); //playermanager ��ũ��Ʈ�� �����ϱ�����
        playeranim = GetComponent<Animator>(); //�ִϸ����� ������Ʈ�� ��������
    }

    // Update is called once per frame
    void Update()
    {
        PlayerWalk(); 
        Run();
        Slide();
        //�������� ���� �Է��� �ް� �ִϸ��̼� ����
    }
    private void PlayerWalk() //�÷��̾ �ȴ� ��ũ��Ʈ
    {
        //LeftRight�� FronkBack �� Lec 3���� �þ��µ� -1~ 1 �� float ���� �����ϴ�.
        //�ش� ���� �������� ���ǹ��� ¥�� �ɾ����� ���Ҵ��� ���� �����մϴ�.
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

        playeranim.SetBool("Walk", isWalk); //Walk�� �ִϸ��̼��� bool���� �����ؼ� �ִϸ��̼� ��� ���θ� ����
    }
    private void Run() //�ٱ�
    {
        if (Input.GetKey(KeyCode.LeftShift)) //���� ����Ʈ Ű�� ������ ������
        {
            isRun = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift)) //���� ����Ʈ Ű�� ����
        {
            isRun = false;
        }

        playeranim.SetBool("Run", isRun && isWalk); //�ִϸ��̼� ���
    }
    private void Slide() //�����̵�
    {
        if(Input.GetKeyDown(KeyCode.Space)) //�����̽��� Ű�� ������
        {
            playeranim.SetTrigger("Slide"); //�����̵� �ִϸ��̼� ���
        }
    }
}
