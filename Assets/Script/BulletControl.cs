using UnityEngine;

public class BulletControl : MonoBehaviour
{
    public float speed = 5f;
    public BulletType bulletType; // 子弹类型，可以在 Inspector 面板中设置
    public int damage = 1;
    private Rigidbody2D rb;
    private void Start()
    {
        // 随机选择一个初始方向，但偏向下方
        float randomAngle = Random.Range(-45f, 45f); // 在-45度到45度之间选择一个随机角度
        Vector2 initialDirection = Quaternion.Euler(0, 0, randomAngle) * Vector2.down;

        // 设置子弹的初始速度
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = initialDirection * speed;
    }
    private void Update()
    {
        //MoveBullet();
        // 如果子弹超出边界，销毁它
        if (transform.position.y < -10f)
        {
            Destroy(gameObject);
        }
    }

    private void MoveBullet()
    {
        // 让子弹向下飞行
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            HandlePlayerCollision(other.gameObject);
        }
    }

    private void HandlePlayerCollision(GameObject player)
    {
        BrickPlayerControl BrickPlayerControl = player.GetComponent<BrickPlayerControl>();

        switch (bulletType)
        {
            case BulletType.Triangle:
                BrickPlayerControl.TakeDamage(damage);
                Destroy(gameObject);// 三角形子弹扣血
                break;
            case BulletType.Square:
                BrickPlayerControl.IncreaseWidth();
                Destroy(gameObject);// 方形子弹增加宽度
                break;
            case BulletType.Circle:
                ReflectBullet(); // 圆形子弹反弹
                break;
        }

        // 子弹与玩家碰撞后销毁
    }
    

    private void ReflectBullet()
    {
        // 子弹反弹的逻辑，可以根据需要实现
        // 例如，修改子弹的速度或方向
         // 简单地改变速度方向
        float randomAngle = Random.Range(-45f, 45f); // 在-45度到45度之间选择一个随机角度
        Vector2 initialDirection = Quaternion.Euler(0, 0, randomAngle) * Vector2.down;

        // 设置子弹的初始速度
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = initialDirection * -speed;
        this.gameObject.tag = "Reflect";
    }
}

public enum BulletType
{
    Triangle,
    Square,
    Circle
}
