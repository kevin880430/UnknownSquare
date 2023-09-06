using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SceneMananger : MonoBehaviour
{
    public string titleSceneName = "Title";                                                         //�^�C�g����ʂ̖��O��t����
    public string gameOverSceneName = "GameOver";   �@                                              //GameOver��ʂ̖��O��t����
    public string clearSceneName = "GameClear";                                                     //ClearScene��ʂ̖��O��t����
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
        if (SceneManager.GetActiveScene().name == titleSceneName && Input.anyKeyDown && !SaveDataCanvas.activeInHierarchy)//�^�C�g�����anyKey�Ń��C����ʑJ��
        {
            AnykeyText.SetActive(false);
            BottonCanvas.SetActive(true);
        }
        if (SceneManager.GetActiveScene().name == gameOverSceneName && Input.GetKeyDown(KeyCode.R)) //GameOver���RKey�Ń^�C�g����ʑJ��
        {
            SceneManager.LoadScene(titleSceneName);
        }
        if (SceneManager.GetActiveScene().name == clearSceneName && Input.GetKeyDown(KeyCode.R))    //Clear���RKey�Ń^�C�g����ʑJ��
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
