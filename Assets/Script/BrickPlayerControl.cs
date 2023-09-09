using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class BrickPlayerControl : MonoBehaviour
{
    public float moveSpeed = 5f;
    public int maxHealth = 3;
    private int currentHealth;
    public Image hpBar;
    private float currentWidth = 1f; // 玩家的当前宽度
    public float maxWidth = 3f; // 最大宽度

    private void Start()
    {
        currentHealth = maxHealth;
    }
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;                                                  //ダメージ受けたらhpを減る    
        hpBar.fillAmount -= 0.334f;                                                     //hpバー長さを減る
        if (currentHealth <= 0)                                                         //hpが0以下になったら
        {
            SceneManager.LoadScene("GameOver");                                         //GameOverに画面遷移
        }
    }
    private void Update()
    {
        MovePlayer();

    }

    private void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 newPosition = transform.position + Vector3.right * horizontalInput * moveSpeed * Time.deltaTime;

        transform.position = newPosition;
    }

    public void IncreaseWidth()
    {
        // 增加玩家的宽度，但不超过最大宽度
        if (this.gameObject.transform.localScale.x <= maxWidth)
        {
            this.gameObject.transform.localScale += new Vector3(1, 0f, 0f);
        }
        
        // 在这里你可以修改玩家的显示宽度
        // 例如，修改玩家的SpriteRenderer的大小
        // 这里只是一个示例，实际的实现方式取决于你的游戏设置
        // GetComponent<SpriteRenderer>().transform.localScale = new Vector3(currentWidth, 1f, 1f);
    }
}
