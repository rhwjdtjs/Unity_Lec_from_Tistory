using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private float LeftRight; //�������� ���� �����Դϴ�.
    private float FrontBack; //�������� ���� �����Դϴ�.
    private Vector3 moveVector; //�����̱� ���� ���Ͱ�
    private Rigidbody theRigid; //�÷��̾ �����̱� ���� ������ �ٵ� ����մϴ�.
    [SerializeField] float moveSpeed; //�̵��ӵ��� �������� �����Դϴ�.
    private void Start()
    {
        theRigid = GetComponent<Rigidbody>(); //������Ʈ�� �����ɽô�.
    }
    private void Update()
    {
        PlayerMove(); //�Լ��� �ҷ��� �������Ӹ��� �Է��� �����ô�.
    }
   
    private void PlayerMove() //�÷��̾��� �������� ����ϴ� �Լ��Դϴ�.
    {
        LeftRight = Input.GetAxis("Horizontal"); //���� ���������� �� Ű���� ad ���� �Է¹޽��ϴ�.
        FrontBack = Input.GetAxis("Vertical"); //�� �� �� Ű���� ws ���� �Է¹޽��ϴ�.
        //�ܼ�â�� float ���� ����غ��ô�. Update ���� �ش� ����� ���� ���� �������Ӹ��� �ܼ�â�� �ٿ�ϴ�.
        //�Է��� ���� ������ ���� 0�� ��µ��״� if ���� �Ἥ 0�� �ƴҶ��� �ܼ�â�� ����װ� ��µǵ��� �սô�.
        if (LeftRight != 0)
            Debug.Log(LeftRight);
        if (FrontBack != 0)
            Debug.Log(FrontBack);
        moveVector = new Vector3(LeftRight, 0, FrontBack); //���� �������� X ������ �̵�, �� �ڴ� Z ������ �̵��մϴ�. Y���� ������ ���� �ʴ� �̻� ���� �ٲ�� �ȵǾ� 0���� ������ŵ�ϴ�.
        theRigid.velocity = moveVector * moveSpeed;//�÷��̾ ���Ͱ���ŭ movespeed �ӵ��� �̵���ŵ�ϴ�.

    }
}
