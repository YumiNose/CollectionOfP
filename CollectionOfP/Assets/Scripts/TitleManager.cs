using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    bool isStartButtonPressed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
        }
        
    }


    /*

    // スタートボタンを押したときに呼ぶ関数
    public void OnStartButtonPressed()          // 覚えておくと便利だがあまり良くない
    {
        if (!this.isStartButtonPressed)         // どっちか　if(this.isStartButtonPressed == false)
        {
            this.isStartButtonPressed = true;
            // 音を鳴らす
            Invoke("LoadScene", 2f);
        }
    }

    void LoadScene()
    {
        SceneManager.LoadScene("GameScene");   // GameSceneをロード
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
    */
}
