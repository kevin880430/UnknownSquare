using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerControl : MonoBehaviour
{
    //プレイヤー回転スピード
    public float rotationSpeed = 8.63f;
    //摩擦力
    public float friction = 1f;
    //Rigidbody2Dを格納する
    public static Rigidbody2D rb;
    //拡大のスピード
    public float scaleUPSpeed = 1.001f;
    //縮小のスピード
    public float scaleDOWNSpeed = 0.998f;
    //最大のサイズ
    public float maxScale = 2f;
    //最小のサイズ
    public float minScale = 0f;
    //初期の質量
    private float initialMass;
    //質量減衰のスピード 
    public float MscaleUPSpeed = 0.99f;
    //質量増加のスピード 
    public float MscaleDOWNSpeed = 1.001f;
                                             
    public static bool isMega;
    public float Scale=0.01f;
    public static string Stage;
    
    

    public PlayerData PlayerData { get; private set; }


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();                                          
        initialMass = rb.mass;
        Stage = SceneManager.GetActiveScene().name;
        
    }
    private void OnEnable()
    {
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
        //方向キー入力を取得する
        float moveHorizontal = Input.GetAxis("Horizontal");
        
        if (moveHorizontal > 0)
        {
            //入力方向に応じて回転させる
            rb.AddTorque(-rotationSpeed);
            // 摩擦力を加える                                                                                             
            rb.angularVelocity *= friction;                                                                         
        }
        else if (moveHorizontal < 0)
        {
            //入力方向に応じて回転させる
            rb.AddTorque(rotationSpeed);
            // 摩擦力を加える
            rb.angularVelocity *= friction;                                                                         
        }
        else
        {
            // 摩擦力を加えて停止する
            rb.angularVelocity *= friction;                                                                         
        }
        
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        //チェックポイントで画面遷移
        if (coll.gameObject.tag == "Gate")
        {
            PlayerPersistence.SaveData(this);
            coll.gameObject.GetComponent<ChangeScenes>().LoadScene();
        }
    }

}