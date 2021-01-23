//=====================================================
// - FileName:      Drag.cs
// - CreateTime:    #CreateTime#
// - Description:   脚本描述 
//======================================================



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Drag : MonoBehaviour {
    public MapCellType MapCellType;
    private GameObject DragClone;
    bool isdrag = false;
    private RaycastHit2D cameraHit;

    void Start () {
        
        UIEventListener.Get(gameObject).onPress = (GO, down) =>
        {
            if (down) //开始拖动
            {
                isdrag = true;
                if (gameObject.transform.parent.tag == "Cell")
                {
                    Debug.Log("从地图拖拽");
                    DragClone = gameObject;
                }
                else if (gameObject.transform.parent.name == "Pre")
                {
                    Debug.Log("从列表拖拽");
                    DragClone = GameObject.Instantiate(gameObject, gameObject.transform.position, Quaternion.identity) as GameObject;
                    DragClone.name = gameObject.name;
                    DragClone.transform.localScale = Vector3.one;
                }
                DragClone.transform.GetComponent<BoxCollider2D>().enabled = false;
                DragClone.transform.SetParent(GameObject.Find("Root").transform);
            }
            else//结束拖动
            {
                isdrag = false;
                GameObject obj = gethitobj();
                if (obj.name == "delete")
                {
                    Debug.Log("销毁");
                    Destroy(DragClone);
                }
                else if(obj.tag=="Cell")
                {
                    Debug.Log("没有销毁");
                    DragClone.transform.parent = obj.transform;
                    Debug.Log(DragClone.transform.parent.name);
                    DragClone.transform.localPosition = Vector3.zero;
                    DragClone.transform.GetComponent<BoxCollider2D>().enabled = true;
                    if (obj.transform.GetComponent<CellAttribute>())
                    {
                        Debug.Log("改变单元格属性");
                        if(!obj.transform.GetComponent<CellAttribute>().MapCellTypes.Contains(MapCellType))
                        obj.transform.GetComponent<CellAttribute>().MapCellTypes.Add(MapCellType) ;
                    }
                }
            }
        };

    }

	void Update () {

        if (isdrag)
        {
            DragClone.transform.position = GetMousePosition();
            
        }
    }

    /// <summary>
    /// 获取射线检测对象
    /// </summary>
    /// <returns></returns>
    GameObject gethitobj()
    {
        GameObject obj = null;

        if (Physics2D.Raycast(GetMousePosition(), Camera.main.transform.position))
        {
            cameraHit = Physics2D.Raycast(GetMousePosition(), Camera.main.transform.position);
            obj = cameraHit.collider.gameObject;
        }
        return obj;
    }

    /// <summary>
    /// 鼠标坐标转换为屏幕坐标
    /// </summary>
    /// <returns>返回屏幕坐标</returns>
    Vector3 GetMousePosition()
    {
        Vector3 mousePos;
        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);//将对象坐标换成屏幕坐标
        mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, pos.z);//让鼠标的屏幕坐标与对象坐标一致
        return Camera.main.ScreenToWorldPoint(mousePos);//将正确的鼠标屏幕坐标换成世界坐标交给物体
    }
}
