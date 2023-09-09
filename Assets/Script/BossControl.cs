using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class BossControl : MonoBehaviour
{
    public GameObject triangleBulletPrefab;
    public GameObject circleBulletPrefab;
    public GameObject squareBulletPrefab;
    public float shootInterval = 2f;
    public float moveSpeed = 2f; // 移动速度
    private int moveDirection = 1; // 移动方向，1 表示向右，-1 表示向左
    public int maxHealth = 3;
    private int currentHealth;
    public Image BosshpBar;
    public int damage;
    private void Start()
    {
        currentHealth = maxHealth;
        InvokeRepeating("ShootRandomBullet", 0f, shootInterval);
    }

    private void Update()
    {
        MoveBoss();
    }

    private void MoveBoss()
    {
        // 移动 Boss
        Vector3 newPosition = transform.position + Vector3.right * moveDirection * moveSpeed * Time.deltaTime;
        transform.position = newPosition;

        // 检查是否需要改变移动方向
        if (transform.position.x > 5f)
        {
            moveDirection = -1; // 如果超过了一定位置，向左移动
        }
        else if (transform.position.x < -5f)
        {
            moveDirection = 1; // 如果超过了另一侧的位置，向右移动
        }
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;                                                  //ダメージ受けたらhpを減る    
        BosshpBar.fillAmount -= 0.334f;                                                     //hpバー長さを減る
        if (currentHealth <= 0)                                                         //hpが0以下になったら
        {
            SceneManager.LoadScene("GameClear");                                         //GameOverに画面遷移
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Reflect"))
        {
            TakeDamage(damage);
            Destroy(other.gameObject);
        }
    }
    private void ShootRandomBullet()
    {
        int randomBullet = Random.Range(0, 3);
        Vector3 spawnPosition = transform.position;

        switch (randomBullet)
        {
            case 0:
                Instantiate(triangleBulletPrefab, spawnPosition, Quaternion.identity);
                break;
            case 1:
                Instantiate(circleBulletPrefab, spawnPosition, Quaternion.identity);
                break;
            case 2:
                Instantiate(squareBulletPrefab, spawnPosition, Quaternion.identity);
                break;
        }
    }
}
