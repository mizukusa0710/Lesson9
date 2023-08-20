using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorController : MonoBehaviour
{
    // �U����Prefab

    public GameObject attackPrefab;
    //�A�j���[�V�������邽�߂̃R���|�[�l���g������
    Animator animator;

    //Unity�������ړ�������R���|�[�l���g������i�ǉ��j
    Rigidbody2D rigid2D;

    // �W�����v�̑��x�̌����i�ǉ��j
    private float dump = 0.8f;

    // �W�����v�̑��x�i�ǉ��j
    float jumpVelocity = 20;

    // �n�ʂ̈ʒu
    private float groundLevel = -5.87f;


    // Start is called before the first frame update
    void Start()
    {
        // �A�j���[�^�̃R���|�[�l���g���擾����
        this.animator = GetComponent<Animator>();
        // Rigidbody2D�̃R���|�[�l���g���擾����i�ǉ��j
        this.rigid2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //���L�[
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.rigid2D.velocity = new Vector2(-3.0f, 0.0f);
        }
        //�E�L�[
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            this.rigid2D.velocity = new Vector2(3.0f, 0.0f);
        }

        //����ȏ㍶�ɍs�����Ȃ�
        if (this.transform.position.x < -6.0f)
        {
            this.transform.position = new Vector2(-8.0f, this.transform.position.y);
        }
        //����ȏ�E�ɍs�����Ȃ�
        if (this.transform.position.x > 3.0f)
        {
            this.transform.position = new Vector2(5.0f, this.transform.position.y);
        }

        //�U��
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.animator.SetTrigger("Attack");
        }
    

            // ����A�j���[�V�������Đ����邽�߂ɁAAnimator�̃p�����[�^�𒲐߂���
            this.animator.SetFloat("Horizontal", 1);

        // ���n���Ă��邩�ǂ����𒲂ׂ�
        bool isGround = (transform.position.y > this.groundLevel) ? false : true;
        this.animator.SetBool("isGround", isGround);

        // ���n��ԂŃN���b�N���ꂽ�ꍇ�i�ǉ��j
        if (Input.GetMouseButtonDown(0) && isGround)
        {
            // ������̗͂�������i�ǉ��j
            this.rigid2D.velocity = new Vector2(0, this.jumpVelocity);
        }

        // �N���b�N����߂��������ւ̑��x����������i�ǉ��j
        if (Input.GetMouseButton(0) == false)
        {
            if (this.rigid2D.velocity.y > 0)
            {
                this.rigid2D.velocity *= this.dump;
            }
        }
    }
    //�U���^�C�~���O
    public void OnAttack()
    {
        Debug.Log("�U���^�C�~���O");

        GameObject attack = Instantiate(attackPrefab, this.transform.position + new Vector3(1.0f, 0.0f, 0.0f), Quaternion.identity);
        Destroy(attack.gameObject, 0.5f);
    }
}
