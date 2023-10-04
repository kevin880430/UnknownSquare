using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SceneMananger : MonoBehaviour
{
    //タイトル画面の名前を付ける
    public string titleSceneName = "Title";
    //GameOver画面の名前を付ける
    public string gameOverSceneName = "GameOver";
    //ClearScene画面の名前を付ける
    public string clearSceneName = "GameClear";                                                     
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
        //タイトル画面anyKeyでメイン画面遷移
        if (SceneManager.GetActiveScene().name == titleSceneName && Input.anyKeyDown && !SaveDataCanvas.activeInHierarchy)
        {
            AnykeyText.SetActive(false);
            BottonCanvas.SetActive(true);
        }
        //GameOver画面RKeyでタイトル画面遷移
        if (SceneManager.GetActiveScene().name == gameOverSceneName && Input.GetKeyDown(KeyCode.R)) 
        {
            SceneManager.LoadScene(titleSceneName);
        }
        //Clear画面RKeyでタイトル画面遷移
        if (SceneManager.GetActiveScene().name == clearSceneName && Input.GetKeyDown(KeyCode.R))    
        {
            {
                SceneManager.LoadScene(titleSceneName);
            }
        }
        //メニュー画面
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
