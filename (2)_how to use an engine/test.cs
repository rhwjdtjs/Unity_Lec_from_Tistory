using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{

    public Rigidbody theCubeRigid; // 큐브의 rigidbody를 참조하기 위해 변수 선언
    // Start is called before the first frame update
    void Start()
    {
        theCubeRigid = GetComponent<Rigidbody>(); //큐브에 있는 Rigidbody 컴포넌트를 theCubeRigid 변수에 가져와 참조한다.
        theCubeRigid.useGravity = false; //큐브의 Rigidbody의 중력을 해제한다.
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
