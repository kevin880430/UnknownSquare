using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float rotationSpeed = 8.63f;                                           //プレイヤー回転スピード
    public float friction = 1f;                                                   //摩擦力
    private Rigidbody2D rb;                                                       //Rigidbody2Dを格納する
    public float scaleUPSpeed = 1.001f;　　　　　　　　　　　　　　　　　　       //拡大のスピード
    public float maxScale = 2f;                                                   //最大のサイズ
    public float minScale = 1f;                                                   //最小のサイズ
    private float initialMass;                                                    //初期の質量
    public float MscaleUPSpeed = 0.999f;                                          //質量減衰のスピード 
    public float MscaleDOWNSpeed = 1.001f;                                        //質量増加のスピード 
    public float scaleDOWNSpeed=0.998f;                                           //縮小のスピード
    public static bool isMega;                                                    //プレイヤーが最大化かどうかのチェック

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();                                           //プレイヤーのrigidbody2Dを取得する
        initialMass = rb.mass;                                                      //プレイヤーの質量を初期化
    }
    

    private void Update()
    {

        if (Input.GetKey(KeyCode.Z))
        {
            Vector3 newScale = transform.localScale * scaleUPSpeed;                                                 //拡大した大きさを新しい大きさに代入
            if (newScale.x <= maxScale && newScale.y <= maxScale && newScale.z <= maxScale)                         //新しい大きさが最大になるまでに
            {
                transform.localScale = newScale;                                                                    //大きさを変更する                                           
                rb.mass *=  MscaleUPSpeed;                                                                          //拡大する同時に質量を調整
            }
            if (newScale.x >= maxScale)                                                                             //大きさが最大になったら
            {
                rb.mass = initialMass*0.5f;                                                                         //質量を固定
                isMega = true;                                                                                      //最大化状態チェックonにする
            }
        }
        if (Input.GetKey(KeyCode.X))
        {
            Vector3 newScale = transform.localScale * scaleDOWNSpeed;                                               //拡大した大きさを新しい大きさに代入
            if (newScale.x >= minScale && newScale.y >= minScale && newScale.z >= minScale)                         //新しい大きさが最小になるまでに
            {
                transform.localScale = newScale;
                rb.mass *=MscaleDOWNSpeed;                                                                          //縮小する同時に質量を調整
                isMega = false;                                                                                     //最大化チェック状態offにする
            }
            if (newScale.x <= minScale)                                                                             //大きさが最小化になったら
            {
                
                rb.mass = initialMass;                                                                              // 質量をリセット
            }
        }
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");                                                         //方向キー入力を取得する

        if (moveHorizontal > 0)                                         
        {
            rb.AddTorque(-rotationSpeed);                                                                           //入力方向に応じて回転させる

                                                                                                                    
            rb.angularVelocity *= friction;                                                                         // 摩擦力を加える
        }
        else if (moveHorizontal < 0)
        {
            rb.AddTorque(rotationSpeed);                                                                            //入力方向に応じて回転させる


            rb.angularVelocity *= friction;                                                                         // 摩擦力を加える
        }
        else
        {
            
            rb.angularVelocity *= friction;                                                                         // 摩擦力を加えて停止する
        }
        
    }
    

}