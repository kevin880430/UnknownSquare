using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeScenes : MonoBehaviour
{
    //����Scene���O
    public string NextSceneName = "Stage2";                                                           

    public void Start()
    {
        this.transform.tag = "Gate";
    }
    public void LoadScene()
    {
        //����Scene�ɑJ��
        SceneManager.LoadScene(NextSceneName);                                                         
    }
}
