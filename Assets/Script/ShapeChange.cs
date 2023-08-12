using UnityEngine;
using UnityEngine.U2D;

public class ShapeChange : MonoBehaviour
{
    public Sprite[] shapeSprites;                                        // 各種形状のスプライトを保存する配列
    public string[] shapeTags;                                           // 各形状に対応するタグを保存する配列
    private SpriteRenderer spriteRenderer;
    private int currentShapeIndex = 0;

    private void Start()
    {                                                                 
        spriteRenderer = GetComponent<SpriteRenderer>();                // SpriteRendererコンポーネントを取得
        
        ChangeShape(currentShapeIndex);                                 // プレイヤーを最初の形状（正方形）に初期化
    }

    private void Update()
    {
                                                                        // Cキーが押されたかをチェック
        if (Input.GetKeyDown(KeyCode.C))
        {                                                               
            currentShapeIndex++;                                        //次の形状indexを切り替え
            if (currentShapeIndex >= shapeSprites.Length)
            {
                currentShapeIndex = 0;                                  //回数超えたらindexをリセット
            }

            ChangeShape(currentShapeIndex);                             // 形状を切り替える
        }
    }

    private void ChangeShape(int index)
    {                                                              
        spriteRenderer.sprite = shapeSprites[index];                    // 形状のスプライトを設定

        gameObject.tag = shapeTags[index];                              // タグを切り替える

        Destroy(GetComponent<PolygonCollider2D>());                     // 旧のColliderコンポーネントを削除

        gameObject.AddComponent<PolygonCollider2D>();                   // 新しいColliderを追加
    }
}