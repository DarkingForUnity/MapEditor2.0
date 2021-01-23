//=====================================================
// - FileName:      CellAttribute.cs
// - CreateTime:    #CreateTime#
// - Description:   脚本描述 
//======================================================
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellAttribute : MonoBehaviour {

    public int x;
    public int y;

    //public MapCellType MapCellType;
    public List<MapCellType> MapCellTypes;

    public void close_children()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<BoxCollider2D>().enabled = false;
        }
    }
    public void open_children()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<BoxCollider2D>().enabled = true;
        }
    }
    [Button]
    public void setCellPosition()
    {
        int index = transform.GetSiblingIndex();
        x = index % 40;
        y = int.Parse((index/40).ToString());
    }
}
