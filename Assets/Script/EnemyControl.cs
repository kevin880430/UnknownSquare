using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public GameObject CrashAnimation;                                                       //潰されるアニメーションを格納する
    public bool isPlayerMega = PlayerControl.isMega;                                        //PlayerControlからisMegaの判定を取得する
  
    void Update()
    {
        isPlayerMega = PlayerControl.isMega;                                                //isMegaの判定常に確認する
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("SquarePlayer")&&isPlayerMega)                  //最大化する正方形のプレイヤーと接触すると潰される
        {
           Instantiate(CrashAnimation, transform.position, transform.rotation);             //アニメーションを生成
            Destroy(this.gameObject);                                                       //自分を削除する
        }
    }
}
