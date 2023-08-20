using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{
        //�A�j���[�V�������邽�߂̃R���|�[�l���g������
        Animator animator;

        //�ړ�������R���|�[�l���g������
        Rigidbody2D rigid2D;

        // Start is called before the first frame update
        void Start()
        {
            // �A�j���[�^�̃R���|�[�l���g���擾����
            this.animator = GetComponent<Animator>();
            // Rigidbody2D�̃R���|�[�l���g���擾����
            this.rigid2D = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            //���ֈړ�
            this.rigid2D.velocity = new Vector2(-2.0f, 0.0f);

            //��ʒ[�Ŕj��
            if(transform.position.x <= -7.0f)
           {
            Destroy(this.gameObject);
           }
        // 10%�̊m����Attack�A�j���[�V���������s
        if (Random.Range(0, 10) == 0)
        {
            animator.SetTrigger("Attack");
        }

    }

        void OnTriggerEnter2D(Collider2D other)
        {
            //�v���C���[�̍U���H
            if (other.gameObject.tag == "AttackTag")
            {
                //�A�j���[�V����
                animator.SetTrigger("Death");

                //�Փ˔�����~�߂�
                GetComponent<BoxCollider2D>().enabled = false;
                //���R���������Ȃ�
                GetComponent<Rigidbody2D>().gravityScale = 0;
            }
        }
    }

