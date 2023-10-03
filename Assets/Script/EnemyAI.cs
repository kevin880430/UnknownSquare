using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    //敵の移動スピード
    public float moveSpeed = 3f;
    //敵の攻撃範囲 
    public float attackRange = 2f;
    //敵の攻撃力
    public int attackDamage = 1;
    //攻撃間隔
    public float attackCooldown = 2f;
    //プレイヤーの位置情報
    private Transform player;
    //プレイヤー探知チェック    
    private bool isPlayerInRange = false;
    //攻撃判定
    private bool isAttacking = false;
    //攻撃タイマー
    private float attackTimer = 0f;                                                                                        

    private void Start()
    {
        //プレイヤーの位置情報を取得
        player = GameObject.Find("Player").transform;                                                                       
    }

    private void Update()
    {
        //プレイヤーとの距離は攻撃範囲内ならisPlayerRangeをチェック
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        isPlayerInRange = distanceToPlayer <= attackRange;
        //isPlayerRangeチェックと攻撃判定ではない場合
        if (isPlayerInRange && !isAttacking)                                                                                
        {
            //プレイヤーを攻撃する
            AttackPlayer();                                                                                                 
        }
        //プレイヤーが攻撃範囲外なら
        else if (!isPlayerInRange)                                                                                          
        {
            //パトロール
            Move();                                                                                                         
        }

       
        //攻撃判定on時
        if (isAttacking)                                                                                                    
        {
            //攻撃タイマーは攻撃間隔時間になったら
            if (attackTimer >= attackCooldown)                                                                             
            {
                //攻撃の判定off
                isAttacking = false;
                //タイマーリセット
                attackTimer = 0;                                                                                            
            }
            //タイマースタート
            }
            else
            {
                attackTimer += Time.deltaTime;                                                                              
            }
    } 

    private void Move()
    {
        //右に移動する
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        //移動距離は3以上超えたら
        if (transform.position.x >= 3f || transform.position.x <= -3f)                                                      
        {
            //移動方向を逆にする
            moveSpeed *= -1;
            //自分の向きを左右反転
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
    }

    private void AttackPlayer()
    {
        //攻撃を行うとき攻撃判定をon 
        isAttacking = true;
        //攻撃アニメーションまだ追加していないのでDebugLogで表示    
        Debug.Log("Attacking the player!");
        // プレイヤーにダメージを与える処理を追加する
        player.GetComponent<PlayerHealth>().TakeDamage(attackDamage);                                                       
    }
}
