using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerHealth : MonoBehaviour
{
    //�v���C���[�ő�hp
    public int maxHealth = 3;
    //�v���C���[����hp
    public static int currentHealth;
    //hp�o�[�̐}�`
    public Image hpBar;
    //�A�j���[�V�������i�[����
    public GameObject CrashAnimation;                                                   
    private void Start()
    {
        //�v���C���[hp������������
        currentHealth = maxHealth;                                                     
    }
    public void TakeDamage(int damageAmount)
    {
        //�_���[�W�󂯂���hp������    
        currentHealth -= damageAmount;
        //hp�o�[����������
        hpBar.fillAmount -= 0.334f;
        //hp��0�ȉ��ɂȂ�����
        if (currentHealth <= 0)                                                         
        {
            //���S���b�Z�[�W��\������
            Debug.Log("Player has died!");
            //���S�A�j���[�V�����𐶐�
            Instantiate(CrashAnimation, transform.position, transform.rotation);
            Destroy(this.gameObject);
            //���S���\�b�h���Ă�
            Invoke("Die", 2f);

        }
    }

    private void Die()
    {
        //GameOver�ɉ�ʑJ��
        SceneManager.LoadScene("GameOver");
    }
}
