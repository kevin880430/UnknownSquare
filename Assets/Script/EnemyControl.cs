using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    //潰されるアニメーションを格納する
    public GameObject CrashAnimation;
    //PlayerControlからisMegaの判定を取得する
    public bool isPlayerMega = PlayerControl.isMega;                                        
    void Update()
    {
        //isMegaの判定常に確認する
        isPlayerMega = PlayerControl.isMega;                                                
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //最大化する正方形のプレイヤーと接触すると潰される
        if (collision.gameObject.CompareTag("SquarePlayer")&&isPlayerMega)                 
        {
            //アニメーションを生成
            Instantiate(CrashAnimation, transform.position, transform.rotation);
            //自分を削除する
            Destroy(this.gameObject);                                                       
        }
    }
}
