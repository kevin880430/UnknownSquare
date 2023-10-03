using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerHealth : MonoBehaviour
{
    //プレイヤー最大hp
    public int maxHealth = 3;
    //プレイヤー現在hp
    public static int currentHealth;
    //hpバーの図形
    public Image hpBar;
    //アニメーションを格納する
    public GameObject CrashAnimation;                                                   
    private void Start()
    {
        //プレイヤーhpを初期化する
        currentHealth = maxHealth;                                                     
    }
    public void TakeDamage(int damageAmount)
    {
        //ダメージ受けたらhpを減る    
        currentHealth -= damageAmount;
        //hpバー長さを減る
        hpBar.fillAmount -= 0.334f;
        //hpが0以下になったら
        if (currentHealth <= 0)                                                         
        {
            //死亡メッセージを表示する
            Debug.Log("Player has died!");
            //死亡アニメーションを生成
            Instantiate(CrashAnimation, transform.position, transform.rotation);
            Destroy(this.gameObject);
            //死亡メソッドを呼ぶ
            Invoke("Die", 2f);

        }
    }

    private void Die()
    {
        //GameOverに画面遷移
        SceneManager.LoadScene("GameOver");
    }
}
