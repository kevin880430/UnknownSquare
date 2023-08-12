using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBlink : MonoBehaviour
{
    public float speed = 1.0f;                                                      //点滅周期
    private SpriteRenderer Arrow;                                                   //SpriteRendererを格納する
    private float time;                                                             //時間周期
    void Start()
    {
        Arrow = this.gameObject.GetComponent<SpriteRenderer>();                     //オブジェクトを取得する
    }


    void Update()
    {
        Arrow.color = GetAlphaColor(Arrow.color);                                   //Spriterendererの色変更メソッドを呼ぶ
    }

    Color GetAlphaColor(Color color)
    {
        time += Time.deltaTime * 5.0f * speed;                                      //時間を足す
        color.a = Mathf.Sin(time);                                                  //Sin関数の周期による色を変更する

        return color;                                                               //色情報を返却
    }
}
