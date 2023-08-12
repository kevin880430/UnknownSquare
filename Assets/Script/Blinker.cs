using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blinker : MonoBehaviour
{
    public float speed = 1.0f;                                                      //点滅の速さ  
    private Text text;                                                              //テキストオブジェクトを宣言
    private float time;                                                             //時間周期
    void Start()
    {
        text = this.gameObject.GetComponent<Text>();                                //テキストオブジェクトを取得
    }

    
    void Update()
    {
        text.color = GetAlphaColor(text.color);                                     //テキストの色を変更メソッドを呼ぶ
    }

    Color GetAlphaColor(Color color)                                                //色変更メソッド
    {
        time += Time.deltaTime * 5.0f * speed;                                      //時間流れのスピード
        color.a = Mathf.Sin(time);                                                  //Sin関数で色を変更する

        return color;                                                               //色情報を返却
    }
}