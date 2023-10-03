using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    //�ׂ����A�j���[�V�������i�[����
    public GameObject CrashAnimation;
    //PlayerControl����isMega�̔�����擾����
    public bool isPlayerMega = PlayerControl.isMega;                                        
    void Update()
    {
        //isMega�̔����Ɋm�F����
        isPlayerMega = PlayerControl.isMega;                                                
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //�ő剻���鐳���`�̃v���C���[�ƐڐG����ƒׂ����
        if (collision.gameObject.CompareTag("SquarePlayer")&&isPlayerMega)                 
        {
            //�A�j���[�V�����𐶐�
            Instantiate(CrashAnimation, transform.position, transform.rotation);
            //�������폜����
            Destroy(this.gameObject);                                                       
        }
    }
}
