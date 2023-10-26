using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class SaveLoadSystem : MonoBehaviour
{
    //プレイヤーから情報を取る
    public GameObject Player;
    //プレイヤーがタイトルから入るかどうかを判断する
    public bool FromTitle=false;
    public int dataNumber;
    public string Stage;
    private DateTime dt = DateTime.Now;
    private void Start()
    {
        
        Stage = SceneManager.GetActiveScene().name;
        dataNumber = PlayerPrefs.GetInt("dataNumber");
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
    public void SetSaveData1()
    {
        PlayerPrefs.SetInt("dataNumber", 1);
        dataNumber = PlayerPrefs.GetInt("dataNumber");
        PlayerPrefs.Save();
    }
    public void SetSaveData2()
    {
        PlayerPrefs.SetInt("dataNumber", 2);
        dataNumber = PlayerPrefs.GetInt("dataNumber");
        PlayerPrefs.Save();
    }
    public void SetSaveData3()
    {
        PlayerPrefs.SetInt("dataNumber", 3);
        dataNumber = PlayerPrefs.GetInt("dataNumber");
        PlayerPrefs.Save(); 
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
        //Save時間の情報をstringとして保存
        data.SaveTime= dt.GetDateTimeFormats('g')[0].ToString();
        //Playした時間を保存
        data.PlayTime = PlayerControl.PlayTimer;
        //dataの資料をJSON形(string)にする
        string json = JsonUtility.ToJson(data);
        //パスとファイル名を指定
        StreamWriter sw = new StreamWriter(Application.dataPath + "/PlayerDataFile_"+dataNumber+".json");
        sw.Write(json);
        sw.Close();
        Debug.Log("Data has been Saved");
    }
    public void LoadFromJson()
    {
        string savefilePath = Application.dataPath + "/PlayerDataFile_" + dataNumber + ".json";
        if (File.Exists(savefilePath))
        {
            //パスとファイル名から読む
            StreamReader sr = new StreamReader(Application.dataPath + "/PlayerDataFile_" + dataNumber + ".json");
            string json = sr.ReadToEnd();
            sr.Close();
            //逆直列化
            PlayerDataJson data = JsonUtility.FromJson<PlayerDataJson>(json);
            //プレイヤーの各パラメータを反応する
            Player.transform.localPosition = new Vector3(data.PlayerPosX, data.PlayerPosY, data.PlayerPosZ);
            ShapeChange.currentShapeIndex = data.Shape;
            Player.GetComponent<ShapeChange>().ChangeShape(data.Shape);
            Player.transform.localScale = data.Size;
            PlayerControl.PlayTimer = data.PlayTime;
            Debug.Log("Loaded" + dataNumber + "data");
        }
            
    }
    public void LoadStageFromJson()
    {
        FromTitle = true;
        // FromTitleの真偽を判断、真なら1の値で保存。偽なら0の値で保存
        PlayerPrefs.SetInt("FromTitle", FromTitle ? 1 : 0);
        PlayerPrefs.Save();

        string savefilePath = Application.dataPath + "/PlayerDataFile_" + dataNumber + ".json";

        if (File.Exists(savefilePath))
        {
            StreamReader sr = new StreamReader(savefilePath);
            string json = sr.ReadToEnd();
            sr.Close();
            PlayerDataJson data = JsonUtility.FromJson<PlayerDataJson>(json);
            SceneManager.LoadScene(data.Stage);
            Debug.Log("Loaded" + dataNumber );
        }
        else
        {
            PlayerPrefs.DeleteKey("Shape");
            PlayerPrefs.SetFloat("PlayerScale_x",1);
            PlayerPrefs.SetFloat("PlayerScale_y", 1);
            PlayerPrefs.SetFloat("PlayerScale_z", 1);
            // セーブファイルが見つからない場合Main画面に遷移
            SceneManager.LoadScene("Main");
            
        }
    }
    public void DeleteSaveData()
    {
        // ファイルパスを指定
        string saveFilePath = Application.dataPath + "/PlayerDataFile_" + dataNumber + ".json";

        // ファイルがあったら消す
        if (File.Exists(saveFilePath))
        {
            File.Delete(saveFilePath);
            Debug.Log("Save data deleted for slot " + dataNumber);
        }
        else
        {
            Debug.LogWarning("Save data not found for slot " + dataNumber);
        }
    }
    public void Quit()
    {
        //ゲームを離脱
        Application.Quit();
    }

}
