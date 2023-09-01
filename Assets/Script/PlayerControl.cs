using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerControl : MonoBehaviour
{
    public float rotationSpeed = 8.63f;                                           //プレイヤー回転スピード
    public float friction = 1f;                                                   //摩擦力
    public static Rigidbody2D rb;                                                       //Rigidbody2Dを格納する
    public float scaleUPSpeed = 1.001f;　　　　　　　　　　　　　　　　　　       //拡大のスピード
    public float maxScale = 2f;                                                   //最大のサイズ
    public float minScale = 0f;                                                   //最小のサイズ
    private float initialMass;                                                    //初期の質量
    public float MscaleUPSpeed = 0.99f;                                          //質量減衰のスピード 
    public float MscaleDOWNSpeed = 1.001f;                                        //質量増加のスピード 
    public float scaleDOWNSpeed=0.998f;                                           //縮小のスピード
    public static bool isMega;
    public float Scale=0.01f;
    public static string Stage;



    public PlayerData PlayerData { get; private set; }


    private void Start()
    {
        //プレイヤーのrigidbody2Dを取得する
        //プレイヤーの質量を初期化
        rb = GetComponent<Rigidbody2D>();                                          
        initialMass = rb.mass;
        Stage = SceneManager.GetActiveScene().name;
    }
    private void OnEnable()
    {
        //プレイヤーのパラメータを取得
        PlayerData = PlayerPersistence.LoadData();
        transform.localScale = PlayerData.Size;
        PlayerHealth.currentHealth = PlayerData.Health;
        ShapeChange.currentShapeIndex = PlayerData.Shape;
        
    }

    private void Update()
    {
        //ボタンを押すと体積、質量大きくなる
        if (Input.GetKey(KeyCode.Z))
        { 
            if (transform.localScale.x <= maxScale )                                                                                  
            {
                this.gameObject.transform.localScale+= new Vector3(Scale,Scale,0f);                                                                                             
                rb.mass *=  MscaleUPSpeed;                                                                          
            }

        }
        //最大化の時質量を固定、最大化状態チェックonにする
        if (transform.localScale.x >= maxScale)                                                                             
        {
            rb.mass = initialMass * 0.5f;
            isMega = true;                                                                                      
        }
        //ボタンを押すと体積、質量小さくくなる、最大化チェック状態offにする
        if (Input.GetKey(KeyCode.X))
        {
            if (transform.localScale.x >= minScale )                         
            {
                this.gameObject.transform.localScale += new Vector3(-Scale,-Scale, 0f);
                rb.mass *= MscaleDOWNSpeed;
                isMega = false;                                                                                     
            }
            
        }
        // 最小化の時質量を固定
        if (transform.localScale.x <= minScale)
        {
            rb.mass = initialMass;
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
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Gate")
        {
            PlayerPersistence.SaveData(this);
            coll.gameObject.GetComponent<ChangeScenes>().LoadScene();
        }
    }

}