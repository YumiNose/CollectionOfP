using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    
    Vector2 defaultPosition;  // 初期位置
    Quaternion defaultRotation;  // 初期向き

    GameObject player;

    Rigidbody2D rigidbody2D;

    enum State
    {
       Wait,
       Found,
       Chase,
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
                            this.rigidbody2D.AddForce(Vector2.up * 100);
                            this.timer = 1;

                            this.state = State.Found;
                        }
                    }
                }
                break;
            case State.Found:
                {
                    this.timer -= Time.deltaTime;
                    if(this.timer <= 0)
                    {
                        this.state = State.Chase;
                    }
                }
                break;
            case State.Chase:
                {
                    // 左側に移動
                    transform.Translate(-1f * Time.deltaTime, 0, 0);
                }
                break;


        }



        // 移動スクリプト
        //transform.Translate(1f * Time.deltaTime, 0, 0);

        /*
        // 死ぬ処理（仮）
        if(Input.GetKeyDown(KeyCode.D))
        {
            // 再配置を考え世界の果てに飛ばす
            transform.position = new Vector3(0, -500f, 0);
        }
        */


        

    }

}
