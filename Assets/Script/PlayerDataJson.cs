using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//直列化宣言
[System.Serializable] 
public class PlayerDataJson
{
    //プレイヤー位置
    public float PlayerPosX;
    public float PlayerPosY;
    public float PlayerPosZ;
    //HP
    public int Health;
    //大きさ
    public Vector3 Size;
    //形
    public int Shape;
    //ステージ
    public string Stage;
    public string SaveTime;
    public float PlayTime;
}
