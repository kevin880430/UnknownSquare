using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crashed : MonoBehaviour
{
    public GameObject WallCrashedAnimation;                                             //壁が破壊されるアニメーションを格納する
    private Rigidbody2D rb;                                                             //rigidbody2Dを格納する

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();                                               //rigidbody2Dを取得する
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("CirclePlayer"))                            //プレイヤーは丸の状態なら
        {
            Instantiate(WallCrashedAnimation, transform.position, transform.rotation);  //壁を破壊するアニメションを生成
            Destroy(this.gameObject);                                                   //壁を削除

        }
    }
}
