using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    
    Vector2 defaultPosition;  // 初期位置
    Quaternion defaultRotation;  // 初期向き

    GameObject player;

    Rigidbody2D rigidbody2D;

    Animator animator;

    enum State
    {
       Wait,
       Found,
       Chase,
       Petrify,
    }
    State state;

    float timer;



    // Start is called before the first frame update
    void Start()
    {
        // 位置を記録
        this.defaultPosition = transform.position;
        this.defaultRotation = transform.rotation;

        this.player = GameObject.Find("Player");
        this.rigidbody2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
    }

    // 再配置＆再表示
    void Restart()
    {
        this.defaultPosition = this.transform.position;  // チェックポイントを超えていたらこの２行
        this.defaultRotation = this.transform.rotation;  // 超えていなけれなこの処理をする
        
    }


    // Update is called once per frame
    void Update()
    {
        // 黒蛇 回収
        if(Input.GetKeyDown(KeyCode.P))
        {
            Destroy(this.gameObject, 1.0f);
        }


        // GameManagerのStateがGame以外でもなにか動かしたい場合は
        // ここに処理を書くーーーーーーーーーーーーーー

        Debug.Log(GameManager.Instance.GetState());
        // GameManagerのStateがReadyの時に再配置を行う
        if (GameManager.Instance.GetState() == GameManager.State.Ready)
        {
            Restart();  // 再配置
            
        }

        if (GameManager.Instance.GetState() != GameManager.State.Game)
        {
            return;
        }

        // 敵の状態を分岐する
        switch (this.state)
        {
            case State.Wait:
                {
                    if (Input.GetKeyDown(KeyCode.K))
                    {
                        float distance = Vector3.Distance(transform.position, this.player.transform.position);

                        if (distance < 11 && distance > -11)
                        {
                            Debug.Log("発見");
                            this.rigidbody2D.AddForce(Vector2.up * 130);  // Kを押した瞬間に上にミニジャンプする
                            this.timer = 1;  // タイマーを1にセット

                            this.state = State.Found;

                            // 敵のアニメーション変更 (発見)
                            this.animator.SetInteger("State", 1);
                        }
                    }
                }
                break;

            case State.Found:
                {
                    this.timer -= Time.deltaTime;
                    // ジャンプして1秒経ったらChaseに移行
                    if (this.timer <= 0)
                    {
                        this.state = State.Chase;

                        // 敵のアニメーション変更 (突進)
                        this.animator.SetInteger("State", 2);
                    }
                }
                break;

            case State.Chase:
                {
                    // 左側に移動
                    transform.Translate(-2f * Time.deltaTime, 0, 0);

                    if (Input.GetKeyDown(KeyCode.I))
                    {
                        float distance = Vector3.Distance(transform.position, this.player.transform.position);

                        if (distance < 10 && distance > -10)
                        {
                            Debug.Log("今、石化しているよ");

                            this.state = State.Petrify;

                            // 敵のアニメーション変更 (石化)
                            this.animator.SetInteger("State", 3);
                        }
                    }
                }
                break;

            case State.Petrify:
                {
                    


                }
                break;

        }

    }

}
