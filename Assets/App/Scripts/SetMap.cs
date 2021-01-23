//=====================================================
// - FileName:      SetMap.cs
// - CreateTime:    #CreateTime#
// - Description:   脚本描述 
//======================================================
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMap : SerializedMonoBehaviour
{
    //public bool[,] BooleanMatrix = new bool[15, 6];
    //[TableMatrix(SquareCells = true)]
    //public Texture2D[,] TextureMatrix = new Texture2D[8, 6];
    //public InfoMessageType[,] EnumMatrix = new InfoMessageType[4, 4];
    //public string[,] StringMatrix = new string[4, 4];
    public string[,] map_ = new string[40, 10];
    //public MapCellType[,] map = new MapCellType[40,10];
}
