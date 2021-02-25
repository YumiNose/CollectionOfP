using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    bool isStartButtonPressed;

    // Update is called once per frame
    void Update()
    {
        
    }

    // チュートリアルを押したときに呼ぶ関数
    public void OnTuatrialButtonPressed()
    {
        if (!this.isStartButtonPressed)
        {
            this.isStartButtonPressed = true;

            SceneManager.LoadScene("GameScene");
        }
    }

    // Stage1ボタンを押したときに呼ぶ関数
    public void OnStage1ButtonPressed()
    {
        if (!this.isStartButtonPressed)
        {
            this.isStartButtonPressed = true;

            SceneManager.LoadScene("Stage1");
        }
    }

    // Stage2ボタンを押したときに呼ぶ関数
    public void OnStage2ButtonPressed()
    {
        if (!this.isStartButtonPressed)
        {
            this.isStartButtonPressed = true;

            SceneManager.LoadScene("Stage2");
        }
    }

    // Quitボタンを押した時に呼ぶ関数
    public void OnQuitButtonPressed()
    {
#if UNITY_EDITOR
        // UnityEditorでゲームを実行している場合の終了方法
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE
        // ビルド後のゲームを終了する方法
        Application.Quit();
#endif
    }




}
