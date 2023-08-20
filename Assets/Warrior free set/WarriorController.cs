using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorController : MonoBehaviour
{
    // 攻撃のPrefab

    public GameObject attackPrefab;
    //アニメーションするためのコンポーネントを入れる
    Animator animator;

    //Unityちゃんを移動させるコンポーネントを入れる（追加）
    Rigidbody2D rigid2D;

    // ジャンプの速度の減衰（追加）
    private float dump = 0.8f;

    // ジャンプの速度（追加）
    float jumpVelocity = 20;

    // 地面の位置
    private float groundLevel = -5.87f;


    // Start is called before the first frame update
    void Start()
    {
        // アニメータのコンポーネントを取得する
        this.animator = GetComponent<Animator>();
        // Rigidbody2Dのコンポーネントを取得する（追加）
        this.rigid2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //左キー
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.rigid2D.velocity = new Vector2(-3.0f, 0.0f);
        }
        //右キー
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            this.rigid2D.velocity = new Vector2(3.0f, 0.0f);
        }

        //これ以上左に行かせない
        if (this.transform.position.x < -6.0f)
        {
            this.transform.position = new Vector2(-8.0f, this.transform.position.y);
        }
        //これ以上右に行かせない
        if (this.transform.position.x > 3.0f)
        {
            this.transform.position = new Vector2(5.0f, this.transform.position.y);
        }

        //攻撃
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.animator.SetTrigger("Attack");
        }
    

            // 走るアニメーションを再生するために、Animatorのパラメータを調節する
            this.animator.SetFloat("Horizontal", 1);

        // 着地しているかどうかを調べる
        bool isGround = (transform.position.y > this.groundLevel) ? false : true;
        this.animator.SetBool("isGround", isGround);

        // 着地状態でクリックされた場合（追加）
        if (Input.GetMouseButtonDown(0) && isGround)
        {
            // 上方向の力をかける（追加）
            this.rigid2D.velocity = new Vector2(0, this.jumpVelocity);
        }

        // クリックをやめたら上方向への速度を減速する（追加）
        if (Input.GetMouseButton(0) == false)
        {
            if (this.rigid2D.velocity.y > 0)
            {
                this.rigid2D.velocity *= this.dump;
            }
        }
    }
    //攻撃タイミング
    public void OnAttack()
    {
        Debug.Log("攻撃タイミング");

        GameObject attack = Instantiate(attackPrefab, this.transform.position + new Vector3(1.0f, 0.0f, 0.0f), Quaternion.identity);
        Destroy(attack.gameObject, 0.5f);
    }
}
