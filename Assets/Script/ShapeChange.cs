using UnityEngine;
using UnityEngine.U2D;

public  class ShapeChange : MonoBehaviour
{
    // 各種形状のスプライトを保存する配列
    public Sprite[] shapeSprites;
    // 各形状に対応するタグを保存する配列
    public string[] shapeTags;                                          
    private SpriteRenderer spriteRenderer;
    public static int currentShapeIndex = 0;

    public void Start()
    {
        // SpriteRendererコンポーネントを取得
        spriteRenderer = GetComponent<SpriteRenderer>();
        // プレイヤーを最初の形状（正方形）に初期化
        ChangeShape(currentShapeIndex);                                
    }

    public void Update()
    {
        // Cキーが押されたかをチェック                                  
        if (Input.GetKeyDown(KeyCode.C))
        {
            //次の形状indexを切り替え
            currentShapeIndex++;                                        
            if (currentShapeIndex >= shapeSprites.Length)
            {
                //回数超えたらindexをリセット
                currentShapeIndex = 0;                                  
            }
            // 形状を切り替える
            ChangeShape(currentShapeIndex);                             
        }
    }

    public  void ChangeShape( int index)
    {
        // 形状のスプライトを設定
        spriteRenderer.sprite = shapeSprites[index];                    
        // タグを切り替える
        gameObject.tag = shapeTags[index];
        // 本来のColliderコンポーネントを削除
        Destroy(GetComponent<PolygonCollider2D>());
        // 新しいColliderを追加
        gameObject.AddComponent<PolygonCollider2D>();                   
    }
}