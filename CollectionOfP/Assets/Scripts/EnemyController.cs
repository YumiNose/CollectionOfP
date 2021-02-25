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
        Search,
        Found,
        Chase,
        Petrify,
    }
    State state;

    float timer;

    float speed = 3.0f;  // 敵の通常移動速度

    Vector3 target;


    // Start is called before the first frame update
    void Start()
    {
        // 位置を記録
        this.defaultPosition = transform.position;
        this.defaultRotation = transform.rotation;

        this.player = GameObject.Find("Player");
        this.rigidbody2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();

        target = transform.position;
    }

    // 再配置＆再表示
    void Restart()
    {
        this.animator.SetInteger("State", 0);
        this.state = State.Search;


        this.transform.position = this.defaultPosition;  // 
        this.transform.rotation = this.defaultRotation;  // 

    }


    // Update is called once per frame
    void Update()
    {
        


        // GameManagerのStateがGame以外でもなにか動かしたい場合は
        // ここに処理を書くーーーーーーーーーーーーーー

        //Debug.Log(GameManager.Instance.GetState());

        // GameManagerのStateがReadyの時に再配置を行う
        if (GameManager.Instance.GetState() == GameManager.State.Reset)
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
            case State.Search:
                {
                    

                    float distance = Vector3.Distance(transform.position, this.player.transform.position);
                    if (distance < 6 && distance > -6)
                    {
                        Debug.Log("発見");
                        this.rigidbody2D.AddForce(Vector2.up * 130);  // 見つけた瞬間、上にミニジャンプする
                        this.timer = 1;  // タイマーを1にセット

                        this.state = State.Found;

                        // 敵のアニメーション変更 (発見)
                        this.animator.SetInteger("State", 1);
                    }
                    else
                    {
                        transform.position = new Vector3(Mathf.Sin(Time.time) * 2.0f + target.x, target.y, target.z);
                        
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
                    else if(Input.GetKeyDown(KeyCode.X))
                    {
                        this.state = State.Petrify;

                         //敵のアニメーション変更 (石化)
                        this.animator.SetInteger("State", 3);
                    }


                }
                break;

            case State.Chase:
                {
                    // 左側に移動
                    transform.Translate(-2.0f * Time.deltaTime, 0, 0);


                    if (Input.GetKeyDown(KeyCode.X))
                    {
                        Debug.Log("今、石化しているよ");

                        this.state = State.Petrify;

                        // 敵のアニメーション変更 (石化)
                        this.animator.SetInteger("State", 3);
                    }
                    
                }
                break;

            case State.Petrify:
                {
                    // 黒蛇 回収
                    if (Input.GetKeyDown(KeyCode.V))
                    {
                        Debug.Log("黒蛇に食われて消えた状態");
                        Invoke("ActiveFalse", 1.0f);

                    }


                }
                break;

        }

    }
    void ActiveFalse()
    {
        transform.position = new Vector3(9999, 100, 9999);
    }


}
