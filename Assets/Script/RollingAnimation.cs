using UnityEngine;

public class RollingAnimation : MonoBehaviour
{
    public float rotationSpeed = 8.63f;                                             //プレイヤー回転スピード
    public float friction = 1f;                                                     //摩擦力
    private Rigidbody2D rb;                                                         //Rigidbody2Dを格納する
    public float scaleUPSpeed = 1.001f;                                             //拡大のスピード
    public float maxScale = 2f;                                                     //最大のサイズ
    public float minScale = 1f;                                                     //最小のサイズ
    private float initialMass;                                                      //初期の質量
    public float MscaleUPSpeed = 0.999f;                                            //質量減衰のスピード 
    public float MscaleDOWNSpeed = 1.001f;                                          //質量増加のスピード 
    public float scaleDOWNSpeed = 0.998f;                                           //縮小のスピード
    public bool rightClimb = false;                                                 //右側の壁と接触するときのチェック
    public bool leftClimb = false;                                                  //左側の壁と接触するときのチェック
    public bool topClimb = false;                                                   //天井の壁と接触するときのチェック
    public bool groundClimb = false;                                                //地面と接触するときのチェック

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        initialMass = rb.mass;
    }

    private void FixedUpdate()
    {
        Climb();                                                                                                    //常に壁との接触状態を確認する

        rb.AddTorque(-rotationSpeed);                                                                               //回転させる

        rb.angularVelocity *= friction;                                                                             // 摩擦力を加える
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("RightWall"))                                                           //右側の壁と接するとき
        {
            rightClimb = true;                                                                                      //右登りチェックon、他の方向チェックoff
            leftClimb = false;
            topClimb = false;
            groundClimb = false;
        }
        else if (collision.gameObject.CompareTag("LeftWall"))                                                       //左側の壁と接するとき
        {                                                                                                           //左登りチェックon、他の方向チェックoff
            leftClimb = true;
            rightClimb = false;
            topClimb = false;
            groundClimb = false;
        }
        else if (collision.gameObject.CompareTag("Top"))                                                            //天井の壁と接するとき
        {                                                                                                           //天井登りチェックon、他の方向チェックoff
            topClimb = true;
            leftClimb = false;
            rightClimb = false;
            groundClimb = false;
        }
        else
        {
            groundClimb = true;                                                                                     //地面にいるとき
            topClimb = false;                                                                                       //地面チェックon、他の方向チェックoff
            leftClimb = false;
            rightClimb = false;
        }
    }

    private void Climb()
    {
        if (rightClimb)                                                                                             //右登りチェックon時
        {

            rb.AddForce(new Vector3(9.81f, 0, 0));                                                                  //重力の基準方向を右にする
        }

        else if (topClimb)                                                                                          //天井りチェックon時
        {
            rb.AddForce(new Vector3(0, 9.8f, 0));                                                                   //重力の基準方向を天井にする
        }
        else if (leftClimb)                                                                                         //左登りチェックon時
        {
            rb.AddForce(new Vector3(-9.8f, 0, 0));                                                                  //重力の基準方向を左にする
        }
        else　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　//地面チェックon時
        {                                                                                                           
            rb.AddForce(new Vector3(0, -9.8f, 0));                                                                  //重力の基準方向を下にする
        }
    }

}