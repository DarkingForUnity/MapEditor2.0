//=====================================================
// - FileName:      CameraMove.cs
// - CreateTime:    2021/01/06 17:32:55
// - Description:   关卡选择界面相机的移动
//======================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {
    public GameObject CameraObj;
    public GameObject BgObj;
    public Transform Left;
    public Transform Right;
    public Transform above;
    public Transform bottom;
    void Start()
    {
        UIEventListener.Get(gameObject).onDrag = (GO, delta) =>
        {
            BgObjMove(delta.x);
        };
    }

    public void BgObjMove(float delta)
    {
        float del = 0;
        if (Mathf.Abs(delta) >= 50)
        { del = (delta / Mathf.Abs(delta)) * 50; }
        else
        { del = delta; }

        float w = (Screen.width * (above.position.y - bottom.position.y) / Screen.height);

        if (Left.position.x < CameraObj.transform.position.x - w / 2 &&
            del > 0)
        { BgObj.transform.position = BgObj.transform.position + new Vector3(del * 0.01f, 0, 0); }

        if (Right.position.x > CameraObj.transform.position.x + w / 2 &&
            del < 0)
        { BgObj.transform.position = BgObj.transform.position + new Vector3(del * 0.01f, 0, 0); }

        // Debug.Log(del * 0.01f);

    }
}
