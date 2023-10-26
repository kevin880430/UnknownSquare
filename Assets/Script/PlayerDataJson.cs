using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//���񉻐錾
[System.Serializable] 
public class PlayerDataJson
{
    //�v���C���[�ʒu
    public float PlayerPosX;
    public float PlayerPosY;
    public float PlayerPosZ;
    //HP
    public int Health;
    //�傫��
    public Vector3 Size;
    //�`
    public int Shape;
    //�X�e�[�W
    public string Stage;
    public string SaveTime;
    public float PlayTime;
}
