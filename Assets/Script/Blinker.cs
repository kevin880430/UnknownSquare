using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blinker : MonoBehaviour
{
    //�_�ł̑��� 
    public float speed = 1.0f;
    //�e�L�X�g�I�u�W�F�N�g��錾
    private Text text;
    //���Ԏ���
    private float time;                                                             
    void Start()
    {
        //�e�L�X�g�I�u�W�F�N�g���擾
        text = this.gameObject.GetComponent<Text>();                                
    }

    
    void Update()
    {
        //�e�L�X�g�̐F��ύX���\�b�h���Ă�
        text.color = GetAlphaColor(text.color);                                     
    }

    Color GetAlphaColor(Color color)                                                
    {
        //���ԗ���̃X�s�[�h
        time += Time.deltaTime * 5.0f * speed;
        //Sin�֐��ɂ������ŐF��ύX����
        color.a = Mathf.Sin(time);
        //�F����ԋp
        return color;                                                               
    }
}