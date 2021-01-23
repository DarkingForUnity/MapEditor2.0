//=====================================================
// - FileName:      Test.cs
// - CreateTime:    #CreateTime#
// - Description:   脚本描述 
//======================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

    public struct A
    {
        public int a;
    }
	void Start () {
        Test_ A = new Test_();
        A.a = 10;
        Test_ B = new Test_();
        B = A;
        B.a = 100;
        //A a = new A();
        //a.a = 10;

        //A b = a;
        //A b = new A();
        //b = a;

        //b.a = 100;
        Debug.Log(A.a+"   "+B.a);

    }

	void Update () {
		
	}
}
