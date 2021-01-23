//=====================================================
// - FileName:      CellsManage.cs
// - CreateTime:    #CreateTime#
// - Description:   脚本描述 
//======================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellsManage : MonoBehaviour {

    public CellAttribute[] cellAttributes;

    public void close_all_cell()
    {
        for (int i = 0; i < cellAttributes.Length; i++)
        {
            cellAttributes[i].close_children();
        }
    }
}
