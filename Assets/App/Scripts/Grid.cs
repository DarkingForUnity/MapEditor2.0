//=====================================================
// - FileName:      Grid.cs
// - CreateTime:    #CreateTime#
// - Description:   脚本描述 
//======================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public float width = 32.0f;
    public float height = 32.0f;


    public Color color = Color.white;
    //我们需要一系列水平线和垂直线，并且还要知道编辑器摄像机
    void OnDrawGizmos()//为了在编辑器中绘图，我们需要使用OnDrawGizmo回调函数
    {
        Vector3 pos = Camera.current.transform.position;
        Gizmos.color = color;
        for (float y = pos.y - 800.0f; y < pos.y + 800.0f; y += height)
        {
            Gizmos.DrawLine(new Vector3(-10000.0f, Mathf.Floor(y / height) * height, 0.0f),
            new Vector3(10000.0f, Mathf.Floor(y / height) * height, 0.0f));
        }

        for (float x = pos.x - 1200.0f; x < pos.x + 1200.0f; x += width)
        {
            Gizmos.DrawLine(new Vector3(Mathf.Floor(x / width) * width, -10000.0f, 0.0f),
            new Vector3(Mathf.Floor(x / width) * width, 10000.0f, 0.0f));
        }
    }
}

