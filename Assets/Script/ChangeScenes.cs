using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeScenes : MonoBehaviour
{
    public string Stage2SceneName = "Stage2";                                                           //Stage2Sceneの名前を付ける
    public string MainSceneName = "Main";                                                               //MainSceneの名前を付ける
 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name==("Player")&& SceneManager.GetActiveScene().name == MainSceneName)        //プレイヤーと矢印接触すると次のStageに遷移
        {
            SceneManager.LoadScene("Stage2");
        }
        if (collision.gameObject.name == ("Player")&& SceneManager.GetActiveScene().name == Stage2SceneName)    //プレイヤーと矢印接触すると次のGameClearに遷移
        {
            SceneManager.LoadScene("GameClear");
        }
    }
}
