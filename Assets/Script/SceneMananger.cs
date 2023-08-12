using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMananger : MonoBehaviour
{
    public string titleSceneName = "Title";                                                         //タイトル画面の名前を付ける
    public string gameOverSceneName = "GameOver";   　                                              //GameOver画面の名前を付ける
    public string clearSceneName = "GameClear";                                                     //ClearScene画面の名前を付ける


    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == titleSceneName && Input.anyKeyDown)               //タイトル画面anyKeyでメイン画面遷移
        {
            SceneManager.LoadScene("Main");
        }
        if (SceneManager.GetActiveScene().name == gameOverSceneName && Input.GetKeyDown(KeyCode.R)) //GameOver画面RKeyでタイトル画面遷移
        {
            SceneManager.LoadScene(titleSceneName);
        }
        if (SceneManager.GetActiveScene().name == clearSceneName && Input.GetKeyDown(KeyCode.R))    //Clear画面RKeyでタイトル画面遷移
        {
            {
                SceneManager.LoadScene(titleSceneName);
            }
        }
    }
}
