using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;

public class UIDisplay : MonoBehaviour
{
    public Text SaveTime1;
    public Text SaveTime2;
    public Text SaveTime3;
    public Text PlayTime1;
    public Text PlayTime2;
    public Text PlayTime3;
    public Text StageName1;
    public Text StageName2;
    public Text StageName3;
    PlayerDataJson data;

    // Update is called once per frame
   
    void UpdateUIFromFile(string filePath, Text saveTimeText, Text playTimeText, Text stageNameText)
    {
        if (File.Exists(filePath))
        {
            StreamReader sr = new StreamReader(filePath);
            string json = sr.ReadToEnd();
            sr.Close();
            PlayerDataJson data = JsonUtility.FromJson<PlayerDataJson>(json);

            saveTimeText.text = data.SaveTime;
            int minutes = Mathf.FloorToInt(data.PlayTime / 60);
            int remainingSeconds = Mathf.FloorToInt(data.PlayTime % 60);
            string formattedTime = string.Format("PLAYTIME:{0:D2}:{1:D2}", minutes, remainingSeconds);
            playTimeText.text = formattedTime;
            stageNameText.text = data.Stage;
        }
        else
        {
            // ファイルが見つからない場合デフォルトで表示
            saveTimeText.text = "0000/00/00";
            playTimeText.text = "00:00";
            stageNameText.text = "STAGE?";
        }
    }

    void Update()
    {
        UpdateUIFromFile(Application.dataPath + "/PlayerDataFile_1.json", SaveTime1, PlayTime1, StageName1);
        UpdateUIFromFile(Application.dataPath + "/PlayerDataFile_2.json", SaveTime2, PlayTime2, StageName2);
        UpdateUIFromFile(Application.dataPath + "/PlayerDataFile_3.json", SaveTime3, PlayTime3, StageName3);
    }

}
