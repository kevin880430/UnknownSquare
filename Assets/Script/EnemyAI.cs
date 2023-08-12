using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float moveSpeed = 3f;                                                                                           //敵の移動スピード     
    public float attackRange = 2f;                                                                                         //敵の攻撃範囲 
    public int attackDamage = 1;                                                                                           //敵の攻撃力
    public float attackCooldown = 2f;                                                                                      //攻撃間隔

    private Transform player;                                                                                              //プレイヤーの位置情報
    private bool isPlayerInRange = false;                                                                                  //プレイヤー探知チェック    
    private bool isAttacking = false;                                                                                      //攻撃判定
    private float attackTimer = 0f;                                                                                        //攻撃タイマー

    private void Start()
    {
        player = GameObject.Find("Player").transform;                                                                       //プレイヤーの位置情報を取得
    }

    private void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        isPlayerInRange = distanceToPlayer <= attackRange;                                                                  //プレイヤーとの距離は攻撃範囲内ならisPlayerRangeをチェック

        if (isPlayerInRange && !isAttacking)                                                                                //isPlayerRangeチェックと攻撃判定ではない場合
        {
            AttackPlayer();                                                                                                 //プレイヤーを攻撃する
        }
        else if (!isPlayerInRange)                                                                                          //プレイヤーが攻撃範囲外なら
        {
            Move();                                                                                                         //パトロール
        }

        // タイマーの更新
        if (isAttacking)                                                                                                    //攻撃判定on時
        {
            if (attackTimer >= attackCooldown)                                                                              //攻撃タイマーは攻撃間隔時間になったら
            {
                isAttacking = false;                                                                                        //攻撃の判定off
                attackTimer = 0;                                                                                            //タイマーリセット
            }
            else
            {
                attackTimer += Time.deltaTime;                                                                              //タイマースタート
            }
        }
    }

    private void Move()
    {
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);                                                    //右に移動する

        if (transform.position.x >= 3f || transform.position.x <= -3f)                                                      //移動距離は3以上超えたら
        {
            moveSpeed *= -1;                                                                                                //移動方向を逆にする
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);//自分の向きを左右反転
        }
    }

    private void AttackPlayer()
    { 
        isAttacking = true;                                                                                                 //攻撃を行うとき攻撃判定をon    
            
        Debug.Log("Attacking the player!");                                                                                 //攻撃アニメーションまだ追加していないのでDebugLogで表示

        
        player.GetComponent<PlayerHealth>().TakeDamage(attackDamage);                                                       // プレイヤーにダメージを与える処理を追加する
    }
}
