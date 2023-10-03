using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class BossControl : MonoBehaviour
{
    public GameObject triangleBulletPrefab;
    public GameObject circleBulletPrefab;
    public GameObject squareBulletPrefab;
    public float shootInterval = 2f;
    // 移动速度
    public float moveSpeed = 2f; 
    //移動方向、1は右に
    private int moveDirection = 1; 
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
        // Bossを動かす
        Vector3 newPosition = transform.position + Vector3.right * moveDirection * moveSpeed * Time.deltaTime;
        transform.position = newPosition;

        // 一定の距離で移動方向を変更
        if (transform.position.x > 5f)
        {
            moveDirection = -1; 
        }
        else if (transform.position.x < -5f)
        {
            moveDirection = 1; 
        }
    }
    public void TakeDamage(int damage)
    {
        //ダメージ受けたらhpを減る 
        currentHealth -= damage;
        //hpバー長さを減る
        BosshpBar.fillAmount -= 0.334f;
        //hpが0以下になったら
        if (currentHealth <= 0)                                                         
        {
            //GameOverに画面遷移
            SceneManager.LoadScene("GameClear");                                         
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        //反射された弾を受けたら
        if (other.CompareTag("Reflect"))
        {
            //Bossにダメージを加えて
            TakeDamage(damage);
            //弾を消す
            Destroy(other.gameObject);
        }
    }
    private void ShootRandomBullet()
    {
        //ランダムで弾を飛ばす
        int randomBullet = Random.Range(0, 3);
        Vector3 spawnPosition = transform.position;
        //三種類の弾
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
