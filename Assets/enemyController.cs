using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{
        //アニメーションするためのコンポーネントを入れる
        Animator animator;

        //移動させるコンポーネントを入れる
        Rigidbody2D rigid2D;

        // Start is called before the first frame update
        void Start()
        {
            // アニメータのコンポーネントを取得する
            this.animator = GetComponent<Animator>();
            // Rigidbody2Dのコンポーネントを取得する
            this.rigid2D = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            //左へ移動
            this.rigid2D.velocity = new Vector2(-2.0f, 0.0f);

            //画面端で破棄
            if(transform.position.x <= -7.0f)
           {
            Destroy(this.gameObject);
           }
        // 10%の確率でAttackアニメーションを実行
        if (Random.Range(0, 10) == 0)
        {
            animator.SetTrigger("Attack");
        }

    }

        void OnTriggerEnter2D(Collider2D other)
        {
            //プレイヤーの攻撃？
            if (other.gameObject.tag == "AttackTag")
            {
                //アニメーション
                animator.SetTrigger("Death");

                //衝突判定を止める
                GetComponent<BoxCollider2D>().enabled = false;
                //自由落下させない
                GetComponent<Rigidbody2D>().gravityScale = 0;
            }
        }
    }

