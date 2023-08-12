using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;                                                           //プレイヤー最大hp
    public int currentHealth;                                                           //プレイヤー現在hp
    public Image hpBar;                                                                 //hpバーの図形
    public GameObject CrashAnimation;                                                   //アニメーションを格納する
    private void Start()
    {
        currentHealth = maxHealth;                                                      //プレイヤーhpを初期化する
    }
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;                                                  //ダメージ受けたらhpを減る    
        hpBar.fillAmount -= 0.334f;                                                     //hpバー長さを減る
        if (currentHealth <= 0)                                                         //hpが0以下になったら
        {
            Die();                                                                      //死亡メソッドを呼ぶ
            Instantiate(CrashAnimation, transform.position, transform.rotation);        //死亡アニメーションを生成
            SceneManager.LoadScene("GameOver");                                         //GameOverに画面遷移
        }
    }

    private void Die()
    {
        
        Debug.Log("Player has died!");                                                  //死亡メッセージを表示する
       
    }
}
