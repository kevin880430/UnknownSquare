using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerPersistence 
{
    
 public static void SaveData(PlayerControl Player)
    {
        //PlayerPref機能でデータを保存する
        PlayerPrefs.SetFloat("x", Player.transform.position.x);
        PlayerPrefs.SetFloat("y", Player.transform.position.y);
        PlayerPrefs.SetFloat("z", Player.transform.position.z);
        PlayerPrefs.SetInt("Health", PlayerHealth.currentHealth);
        PlayerPrefs.SetInt("Shape",ShapeChange.currentShapeIndex);
        PlayerPrefs.SetFloat("PlayerScale_x", Player.transform.localScale.x);
        PlayerPrefs.SetFloat("PlayerScale_y", Player.transform.localScale.y);
        PlayerPrefs.SetFloat("PlayerScale_z", Player.transform.localScale.z);
        PlayerPrefs.SetFloat("PlayTime", PlayerControl.PlayTimer);
    }  
 public static PlayerData LoadData()
    {
        //PlayerPref機能でデータを読み込む
        float x = PlayerPrefs.GetFloat("x");
        float y = PlayerPrefs.GetFloat("y");
        float z = PlayerPrefs.GetFloat("z");
        int health = PlayerPrefs.GetInt("Health");
        float scale_x=PlayerPrefs.GetFloat("PlayerScale_x");
        float scale_y = PlayerPrefs.GetFloat("PlayerScale_y");
        float scale_z = PlayerPrefs.GetFloat("PlayerScale_z");
        int shape = PlayerPrefs.GetInt("Shape");
        float PlayTime= PlayerPrefs.GetFloat("PlayTime");

        PlayerData playerData = new PlayerData()
        {
            //保存したいデータをキーで上書き
            Location = new Vector3(x, y, z),
            Health = health,
            Size = new Vector3(scale_x, scale_y, scale_z),
            Shape= shape,
            PlayTime= PlayTime

    };
        //データを返却
        return playerData;
    }
}
