using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerPersistence 
{
 public static void SaveData(PlayerControl rb)
    {
        PlayerPrefs.SetFloat("x", rb.transform.position.x);
        PlayerPrefs.SetFloat("y", rb.transform.position.y);
        PlayerPrefs.SetFloat("z", rb.transform.position.z);
        PlayerPrefs.SetInt("Health", PlayerHealth.currentHealth);
        //PlayerPrefs.SetFloat("Mass", );
        PlayerPrefs.SetFloat("PlayerScale_x", rb.transform.localScale.x);
        PlayerPrefs.SetFloat("PlayerScale_y", rb.transform.localScale.y);
        PlayerPrefs.SetFloat("PlayerScale_z", rb.transform.localScale.z);
    }  
 public static PlayerData LoadData()
    {
        float x = PlayerPrefs.GetFloat("x");
        float y = PlayerPrefs.GetFloat("y");
        float z = PlayerPrefs.GetFloat("z");
        int health = PlayerPrefs.GetInt("Health");
        float scale_x=PlayerPrefs.GetFloat("PlayerScale_x");
        float scale_y = PlayerPrefs.GetFloat("PlayerScale_y");
        float scale_z = PlayerPrefs.GetFloat("PlayerScale_z");
        int mass = PlayerPrefs.GetInt("Mass");

        PlayerData playerData = new PlayerData()
        {
            Location = new Vector3(x, y, z),
            Health = health,
            Size = new Vector3(scale_x, scale_y, scale_z),
            Mass= mass

        };
        return playerData;
    }
}
