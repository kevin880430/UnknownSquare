using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeScenes : MonoBehaviour
{
    //ŽŸ‚ÌScene–¼‘O
    public string NextSceneName = "Stage2";                                                           

    public void Start()
    {
        this.transform.tag = "Gate";
    }
    public void LoadScene()
    {
        //ŽŸ‚ÌScene‚É‘JˆÚ
        SceneManager.LoadScene(NextSceneName);                                                         
    }
}
