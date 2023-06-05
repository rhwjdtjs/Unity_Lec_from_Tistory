using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float LeftRight; //�������� ���� �����Դϴ�.
    public float FrontBack; //�������� ���� �����Դϴ�.
    private Rigidbody theRigid; //�÷��̾ �����̱� ���� ������ �ٵ� ����մϴ�.
    private Camera thecamera; //Main camera �� �����ɴϴ�.
    private float currentcameraRot;
    [SerializeField] float moveSpeed; //�̵��ӵ��� �������� �����Դϴ�.
    [SerializeField] private float cameraSensitivity; //ī�޶� ȸ�� ���� ����
    [SerializeField] private float camera_Y_Angle; //y�� ī�޶� ���� ����

    private void Start()
    {
        theRigid = GetComponent<Rigidbody>(); //������Ʈ�� �����ɽô�.
        thecamera = FindObjectOfType<Camera>(); //����ī�޶� ���̶�Ű���� ã�Ƽ� �����ɴϴ�.
    }
    private void Update()
    {
        PlayerMove(); //�Լ��� �ҷ��� �������Ӹ��� �Է��� �����ô�.
        CameraRotation(); //ī�޶� ȸ��
        CharacterRotation(); //ĳ���� ȸ��
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
        // ĳ���Ͱ� �ٶ󺸴� �������� �̵� ���͸� ���
        Vector3 moveDirection = transform.forward * FrontBack + transform.right * LeftRight;

        // �̵� ���Ϳ� �̵� �ӵ��� ���Ͽ� �÷��̾ �̵���Ŵ
        theRigid.velocity = moveDirection * moveSpeed;
    }
    private void CameraRotation()
    {
        float RotationX = Input.GetAxis("Mouse Y") * cameraSensitivity; // ���콺�� Y�� �̵����� ī�޶� ������ ���Ͽ� ȸ������ ����ϴ�.
        currentcameraRot -= RotationX; // ���� ī�޶��� ȸ�� ���� ȸ�������� ���� �����մϴ�.
        if (currentcameraRot < -camera_Y_Angle) // ���� ī�޶� ȸ�� ���� �Ʒ��� ���� ������ �ʰ��ϸ�
            currentcameraRot = -camera_Y_Angle; // ī�޶� ȸ�� ���� �Ʒ��� ���� ������ �����մϴ�.
        else if (currentcameraRot > camera_Y_Angle) // ���� ī�޶� ȸ�� ���� ���� ���� ������ �ʰ��ϸ�
            currentcameraRot = camera_Y_Angle; // ī�޶� ȸ�� ���� ���� ���� ������ �����մϴ�.
        thecamera.transform.localRotation = Quaternion.Euler(currentcameraRot, 0f, 0f); // ���ѵ� ȸ�� ���� �̿��Ͽ� ī�޶��� ���� ȸ���� �����մϴ�.
    }

    private void CharacterRotation()
    {
        float RotationY = Input.GetAxis("Mouse X") * cameraSensitivity; // ���콺�� X�� �̵����� ī�޶� ������ ���Ͽ� ȸ������ ����ϴ�.
        Quaternion rotation = Quaternion.AngleAxis(RotationY, Vector3.up); // Y���� �������� ȸ���ϴ� Quaternion�� �����մϴ�.
        theRigid.MoveRotation(theRigid.rotation * rotation); // ĳ������ ȸ���� ȸ�� Quaternion�� �����Ͽ� ȸ���մϴ�.
    }
}
