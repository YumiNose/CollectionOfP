using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransitionUIController : MonoBehaviour
{
    Image panel;

    Color startColor;  // トランジション開始時の透明度
    Color targetColor; // トランジション終了時の透明度
    float totalTime;   // トランジションにかける時間
    float timer = 0f;    // 汎用タイマー
    
    // Start is called before the first frame update
    void Start()
    {
        this.panel = GetComponent<Image>();
        this.panel.enabled = false;  // 一旦無効
    }

    // Update is called once per frame
    void Update()
    {
        if(timer > 0)
        {
            this.timer -= Time.deltaTime;
            float per = this.timer / this.totalTime;  // 1.0～0.0の値を作る
            per = Mathf.Clamp01(per);  // 数字を0～1の値にする(0未満は0に、1より大きいのは1に)
            this.panel.color = Color.Lerp(this.targetColor, this.startColor, per);

            // 透明度が0になったら表示をやめる
            if(this.timer <= 0)
            {
                this.panel.enabled = false;  // 無効に
            }

        }
        
    }

    /// <summary>
    /// 画面を暗くしていく
    /// </summary>
    /// <param name="targetAlpha">目標透明度</param>
    /// <param name="totalTime">フェードにかける時間</param>
    public void Fade(float targetAlpha, float totalTime)
    {
        this.panel.enabled = true;
        
        // 開始時の色情報をセット
        this.startColor = this.panel.color;

        // 終了時の色を作る
        Color targetColor = this.panel.color;
        targetColor.a = targetAlpha;
        this.targetColor = targetColor;


        // タイマーをセット
        this.totalTime = totalTime;
        this.timer = totalTime;
    }


}
