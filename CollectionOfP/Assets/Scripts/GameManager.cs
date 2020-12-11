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

    public int zanki = 3;  // 残り残基

    

    // 現在の状態を取得する関数
    public State GetState()
    {
        return this.state;
    }

    
    // Start is called before the first frame update
    void Start()
    {
        // Readyから開始する
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


    void Ready()
    {
        Debug.Log("Ready");
        if (this.timer > 0)
        {
            timer = 0;
        }
        else
        {
            ChangeState(State.Game);
        }
        
    }

    void Game()
    {
        
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
        SceneManager.LoadScene("GameClear");
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
            ChangeState(State.Ready);
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
                    // ReadyからGame開始まで３秒
                    //this.timer = 3f;
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
                    
                    // 死んでから復活するまで2秒
                    this.timer = 2f;

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
