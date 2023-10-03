using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    //�G�̈ړ��X�s�[�h
    public float moveSpeed = 3f;
    //�G�̍U���͈� 
    public float attackRange = 2f;
    //�G�̍U����
    public int attackDamage = 1;
    //�U���Ԋu
    public float attackCooldown = 2f;
    //�v���C���[�̈ʒu���
    private Transform player;
    //�v���C���[�T�m�`�F�b�N    
    private bool isPlayerInRange = false;
    //�U������
    private bool isAttacking = false;
    //�U���^�C�}�[
    private float attackTimer = 0f;                                                                                        

    private void Start()
    {
        //�v���C���[�̈ʒu�����擾
        player = GameObject.Find("Player").transform;                                                                       
    }

    private void Update()
    {
        //�v���C���[�Ƃ̋����͍U���͈͓��Ȃ�isPlayerRange���`�F�b�N
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        isPlayerInRange = distanceToPlayer <= attackRange;
        //isPlayerRange�`�F�b�N�ƍU������ł͂Ȃ��ꍇ
        if (isPlayerInRange && !isAttacking)                                                                                
        {
            //�v���C���[���U������
            AttackPlayer();                                                                                                 
        }
        //�v���C���[���U���͈͊O�Ȃ�
        else if (!isPlayerInRange)                                                                                          
        {
            //�p�g���[��
            Move();                                                                                                         
        }

       
        //�U������on��
        if (isAttacking)                                                                                                    
        {
            //�U���^�C�}�[�͍U���Ԋu���ԂɂȂ�����
            if (attackTimer >= attackCooldown)                                                                             
            {
                //�U���̔���off
                isAttacking = false;
                //�^�C�}�[���Z�b�g
                attackTimer = 0;                                                                                            
            }
            //�^�C�}�[�X�^�[�g
            }
            else
            {
                attackTimer += Time.deltaTime;                                                                              
            }
    } 

    private void Move()
    {
        //�E�Ɉړ�����
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        //�ړ�������3�ȏ㒴������
        if (transform.position.x >= 3f || transform.position.x <= -3f)                                                      
        {
            //�ړ��������t�ɂ���
            moveSpeed *= -1;
            //�����̌��������E���]
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
    }

    private void AttackPlayer()
    {
        //�U�����s���Ƃ��U�������on 
        isAttacking = true;
        //�U���A�j���[�V�����܂��ǉ����Ă��Ȃ��̂�DebugLog�ŕ\��    
        Debug.Log("Attacking the player!");
        // �v���C���[�Ƀ_���[�W��^���鏈����ǉ�����
        player.GetComponent<PlayerHealth>().TakeDamage(attackDamage);                                                       
    }
}
