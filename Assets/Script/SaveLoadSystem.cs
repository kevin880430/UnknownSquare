using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class SaveLoadSystem : MonoBehaviour
{
    public GameObject Player;
    
    public void SaveToJson()
    {
        PlayerDataJson data = new PlayerDataJson();
        data.PlayerPosX = Player.transform.position.x;
        data.PlayerPosY = Player.transform.position.y;
        data.PlayerPosZ = Player.transform.position.z;
        data.Health = PlayerHealth.currentHealth;
        data.Size=Player.transform.localScale;
        data.Shape = ShapeChange.currentShapeIndex;
        data.Stage = PlayerControl.Stage;
        string json = JsonUtility.ToJson(data);
        //File.WriteAllText(Application.dataPath + "PlayerDataFile.json", json);
        StreamWriter sw = new StreamWriter(Application.dataPath + "/PlayerDataFile.json");
        sw.Write(json);
        sw.Close();
        Debug.Log("Data has been Saved");
    }
    public void LoadFromJson()
    {
        StreamReader sr = new StreamReader(Application.dataPath + "/PlayerDataFile.json");
        string json = sr.ReadToEnd();
        sr.Close();
        //string json = File.ReadAllText(Application.dataPath + "PlayerDataFile.json");
        PlayerDataJson data = JsonUtility.FromJson<PlayerDataJson>(json);
        //SceneManager.LoadScene(data.Stage);
        Player.transform.localPosition = new Vector3(data.PlayerPosX,data.PlayerPosY,data.PlayerPosZ);
        ShapeChange.currentShapeIndex = data.Shape;
        Player.GetComponent<ShapeChange>().ChangeShape(data.Shape);
        Player.transform.localScale = data.Size;
        Debug.Log("Loaded");
    }
}
