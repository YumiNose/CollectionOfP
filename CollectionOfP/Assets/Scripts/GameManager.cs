using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// 全体の進行を管理するクラス
public class GameManager : MonoBehaviour
{
    // シングルトン
    static GameManager instance;  // 関数ではなくプロパティという書き方
    public static GameManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<GameManager>();
            }
            return instance;
        }
    }

    // 状態を列挙
    public enum State
    {
        Ready,      // みんなが動きだせる前の状態（スタート時の演出に利用）
        Game,       // ゲーム中
        Dead,       // 死んだ演出用
        Clear,      // クリア演出用
        Reset,      // リセット用
    }

    State state = State.Ready;  // 状態を管理する変数

    float timer = 0;  // 汎用タイマー

    int zanki = 3;  // 残り残基

    

    // 現在の状態を取得する関数
    public State GetState()
    {
        return this.state;
    }

    
    // Start is called before the first frame update
    void Start()
    {
        ChangeState(State.Ready);
    }


    // Update is called once per frame
    void Update()
    {
        switch (this.state)
        {
            case State.Ready: Ready(); break;
            case State.Game: Game(); break;
            case State.Dead: Dead(); break;
            case State.Clear: Clear(); break;
            case State.Reset: Reset(); break;
        }

    }

    public void TimeScale(float scale)
    {
        Time.timeScale = scale;
    }
    public void ReseTimeScale()
    {
        Time.timeScale = 1f;
    }


    void Ready()
    {
        
        // タイマーでステートを切り替える
        this.timer -= Time.deltaTime;

        //カウントダウンUI更新
        UIManager.Instance.CountDown(this.timer);

        if(this.timer <= 0)
        {
            ChangeState(State.Game);
        }
        
    }

    void Game()
    {
        /*
        if(Input.GetKeyDown(KeyCode.R))
        {
            ChangeState(State.Ready);
        }
        */

        // 先生に必ず聞くこと！！！！　ゴールについているタグ"GoalPoint"に触れたらゲームクリアシーンへ遷移したい
        void OnTriggerStay2D(Collider2D other)
        {
            if(other.gameObject.tag == "GoalPoint")
            {
                Debug.Log("やったね！ゴール！");
                ChangeState(State.Clear);
            }
        }

    }

    void Dead()
    {
        // タイマーでステートを切り替える
        this.timer -= Time.deltaTime;

        if (this.timer <= 0)
        {
            ChangeState(State.Reset);
        }
    }

    void Clear()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangeState(State.Ready);
        }
    }

    void Reset()
    {
        // 残基が０になったらGameOverシーンに遷移する
        this.zanki--;
        if(this.zanki == 0)
        {
            SceneManager.LoadScene("GameOver");
        }
        else
        {
            ChangeState(State.Game);
        }
        
        
    }

    // ステートを切り替える
    public void ChangeState(State next)
    {
        // 後始末
        switch (this.state)
        {
            case State.Ready:
                {
                    // ステートを切り替えた際に後始末が必要ならここに記述
                　　
                }
                break;

            case State.Game:
                {
                    // ステートを切り替えた際に後始末が必要ならここに記述

                }
                break;

            case State.Dead:
                {
                    // ステートを切り替えた際に後始末が必要ならここに記述

                }
                break;

            case State.Clear:
                {
                    // ステートを切り替えた際に後始末が必要ならここに記述

                }
                break;

            case State.Reset:
                {
                    // ステートを切り替えた際に後始末が必要ならここに記述

                }
                break;
        }

        this.state = next;  // ステートの切り替え

        // 初期化処理
        switch (this.state)
        {
            case State.Ready:
                {
                    // ステートを切り替えた際に初期化が必要ならここに記述
                    // ReadyからGameまで３秒
                    this.timer = 3f;
                }
                break;

            case State.Game:
                {
                    // ステートを切り替えた際に初期化が必要ならここに記述

                }
                break;

            case State.Dead:
                {
                    // ステートを切り替えた際に初期化が必要ならここに記述
                    
                    // 死んでから復活するまで４秒
                    this.timer = 4f;

                }
                break;

            case State.Clear:
                {
                    // ステートを切り替えた際に初期化が必要ならここに記述

                }
                break;

            case State.Reset:
                {
                    // ステートを切り替えた際に後始末が必要ならここに記述

                }
                break;

        }

    }




}
