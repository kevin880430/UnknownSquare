using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class SaveLoadSystem : MonoBehaviour
{
    //プレイヤーから情報を取る
    public GameObject Player;
    //プレイヤーがタイトルから入るかどうかを判断する
    public bool FromTitle=false;
    private void Start()
    {
        //FromTitleの値を取得、別途宣言のint変数に代入する(PlayerPrefはbool形を保存できないから)
        int fromTitleValue = PlayerPrefs.GetInt("FromTitle", 0); 
        //資料をint形からbool形に変換する
        FromTitle = fromTitleValue == 1;
        //プレイヤーがタイトル画面からアクセスたら資料を読み込む
        if (FromTitle)
        {
            //Sceneが切り替える時資料がリセットされるからFromTitleの値を保存する(次のScene使う)
            FromTitle = false;
            PlayerPrefs.SetInt("FromTitle", FromTitle ? 1 : 0);
            PlayerPrefs.Save();
            LoadFromJson();
        }
    }
    public void SaveToJson()
    {
        //資料を新しい保存する
        PlayerDataJson data = new PlayerDataJson();
        //位置情報数値を保存
        data.PlayerPosX = Player.transform.position.x;
        data.PlayerPosY = Player.transform.position.y;
        data.PlayerPosZ = Player.transform.position.z;
        //プレイヤーHP数値を保存
        data.Health = PlayerHealth.currentHealth;
        //プレイヤーサイズ数値を保存
        data.Size　=　Player.transform.localScale;
        //プレイヤー形数値を保存
        data.Shape = ShapeChange.currentShapeIndex;
        //ステージ情報を保存
        data.Stage = PlayerControl.Stage;
        //dataの資料をJSON形(string)にする
        string json = JsonUtility.ToJson(data);
        //パスとファイル名を指定
        StreamWriter sw = new StreamWriter(Application.dataPath + "/PlayerDataFile.json");
        sw.Write(json);
        sw.Close();
        Debug.Log("Data has been Saved");
    }
    public void LoadFromJson()
    {
        //パスとファイル名から読む
        StreamReader sr = new StreamReader(Application.dataPath + "/PlayerDataFile.json");
        string json = sr.ReadToEnd();
        sr.Close();
        //逆直列化
        PlayerDataJson data = JsonUtility.FromJson<PlayerDataJson>(json);
        //プレイヤーの各パラメータを反応する
        Player.transform.localPosition = new Vector3(data.PlayerPosX, data.PlayerPosY, data.PlayerPosZ);
        ShapeChange.currentShapeIndex = data.Shape;
        Player.GetComponent<ShapeChange>().ChangeShape(data.Shape);
        Player.transform.localScale = data.Size;
        Debug.Log("Loaded");
    }
    public void LoadStageFromJson()
    {
        FromTitle = true;
        //FromTitleの真偽を判断、真なら1の値で保存。偽なら0の値で保存
        PlayerPrefs.SetInt("FromTitle", FromTitle ? 1 : 0);
        PlayerPrefs.Save();
        StreamReader sr = new StreamReader(Application.dataPath + "/PlayerDataFile.json");
        string json = sr.ReadToEnd();
        sr.Close();
        PlayerDataJson data = JsonUtility.FromJson<PlayerDataJson>(json);
        SceneManager.LoadScene(data.Stage);
        
    }
}
