using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float speed = 3;  // 移動速度

    Animator animator;

    SpriteRenderer spriteRenderer;  // 左右反転用

    Rigidbody2D rigidbody2D;  // ジャンプ用
    [SerializeField]
    float jumpForce = 300f; // ジャンプ力

    bool isGround = true;  // 地面に着いているのか

    //string deadAreaTag = "DeadArea";

    Vector3 defaultPosition;

    // Start is called before the first frame update
    void Start()
    {
        this.animator = GetComponent<Animator>();
        this.spriteRenderer = GetComponent<SpriteRenderer>();
        this.rigidbody2D = GetComponent<Rigidbody2D>();
        this.defaultPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.GetState() == GameManager.State.Reset)
        {
            Reset();
        }

        if (GameManager.Instance.GetState()!= GameManager.State.Game)
        {
            return;
        }
        // キー入力受付
        // 左キーまたはAキーが押されたら-1
        // 右キーまたはDキーが押されたら1
        float move = Input.GetAxis("Horizontal");

        // 左右移動
        transform.Translate(move * this.speed * Time.deltaTime, 0, 0);

        // アニメーション MoveSpeedというパラメータに値をセット
        this.animator.SetFloat("MoveSpeed", Mathf.Abs(move));

        // 左右反転
        if(move > 0)
        {
            this.spriteRenderer.flipX = false;
        }
        else if(move < 0)
        {
            this.spriteRenderer.flipX = true;
        }

        // ジャンプ
        if(Input.GetKeyDown(KeyCode.Space)&& this.isGround)
        {
            // 上に向けて力を加える
            this.rigidbody2D.AddForce(transform.up * this.jumpForce);

            // 地面から離れた
            this.isGround = false;

            // アニメーション変更
            this.animator.SetBool("Jump", true);

        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // タグを使って「地面に触れているなら」という条件を作った方が良い
        this.isGround = true;

        // アニメーション変更
        this.animator.SetBool("Jump", false);
    }

    // 左を向いているか
    // カメラコントローラー２で使用
    public bool isLeft()
    {
        return this.spriteRenderer.flipX;
    }

    /*
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == deadAreaTag)
        {
            ReceiveDamage(false);
        }
        
    }
    */

    void Reset()
    {
        transform.position = this.defaultPosition;   
    }



}
