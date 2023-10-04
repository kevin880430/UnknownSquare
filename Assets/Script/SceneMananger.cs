using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SceneMananger : MonoBehaviour
{
    //�^�C�g����ʂ̖��O��t����
    public string titleSceneName = "Title";
    //GameOver��ʂ̖��O��t����
    public string gameOverSceneName = "GameOver";
    //ClearScene��ʂ̖��O��t����
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
        //�^�C�g�����anyKey�Ń��C����ʑJ��
        if (SceneManager.GetActiveScene().name == titleSceneName && Input.anyKeyDown && !SaveDataCanvas.activeInHierarchy)
        {
            AnykeyText.SetActive(false);
            BottonCanvas.SetActive(true);
        }
        //GameOver���RKey�Ń^�C�g����ʑJ��
        if (SceneManager.GetActiveScene().name == gameOverSceneName && Input.GetKeyDown(KeyCode.R)) 
        {
            SceneManager.LoadScene(titleSceneName);
        }
        //Clear���RKey�Ń^�C�g����ʑJ��
        if (SceneManager.GetActiveScene().name == clearSceneName && Input.GetKeyDown(KeyCode.R))    
        {
            {
                SceneManager.LoadScene(titleSceneName);
            }
        }
        //���j���[���
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
