using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{

    public Rigidbody theCubeRigid; // ť���� rigidbody�� �����ϱ� ���� ���� ����
    // Start is called before the first frame update
    void Start()
    {
        theCubeRigid = GetComponent<Rigidbody>(); //ť�꿡 �ִ� Rigidbody ������Ʈ�� theCubeRigid ������ ������ �����Ѵ�.
        theCubeRigid.useGravity = false; //ť���� Rigidbody�� �߷��� �����Ѵ�.
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
