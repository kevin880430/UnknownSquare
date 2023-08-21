using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeScenes : MonoBehaviour
{
    public string NextSceneName = "Stage2";                                                           //次のScene名前
    private Transform player;                                                                       　//プレイヤーの位置

    public void Start()
    {
        this.transform.tag = "Gate";
    }
    public void LoadScene()
    {
        SceneManager.LoadScene(NextSceneName);                                                         //次のSceneに遷移
    }
}
