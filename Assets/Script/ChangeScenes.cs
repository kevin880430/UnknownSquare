using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeScenes : MonoBehaviour
{
    public string NextSceneName = "Stage2";                                                           //����Scene���O
    private Transform player;                                                                       �@//�v���C���[�̈ʒu
    private PlayerControl PlayerControl;
    public void Start()
    {
        this.transform.tag = "Gate";
    }
    public void LoadScene()
    {
        SceneManager.LoadScene(NextSceneName);                                                         //����Scene�ɑJ��
    }
}
