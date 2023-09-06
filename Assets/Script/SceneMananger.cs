using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SceneMananger : MonoBehaviour
{
    public string titleSceneName = "Title";                                                         //タイトル画面の名前を付ける
    public string gameOverSceneName = "GameOver";   　                                              //GameOver画面の名前を付ける
    public string clearSceneName = "GameClear";                                                     //ClearScene画面の名前を付ける
    [Header("AnykeyText")]
    public GameObject AnykeyText;
    [Header("NewGameBtn")]
    public GameObject BottonCanvas;
    public GameObject SaveDataCanvas;
    public GameObject SystemPageCanvas;
    private bool isSystemPage;

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == titleSceneName && Input.anyKeyDown && !SaveDataCanvas.activeInHierarchy)//タイトル画面anyKeyでメイン画面遷移
        {
            AnykeyText.SetActive(false);
            BottonCanvas.SetActive(true);
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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isSystemPage = !isSystemPage;
            SystemPageCanvas.SetActive(isSystemPage);
        }
        
    }
    public void LoadMainScene()
    {
        SceneManager.LoadScene("Main");
    }
    public void LoadTitleScene()
    {
        SceneManager.LoadScene("Title");
    }
     
}
