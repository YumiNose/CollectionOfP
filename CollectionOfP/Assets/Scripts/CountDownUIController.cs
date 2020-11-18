using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// CountDownTextにアタッチする
public class CountDownUIController : MonoBehaviour
{
    Text text;
    
    
    // Start is called before the first frame update
    void Start()
    {
        this.text = GetComponent<Text>();
        this.text.text = "";  // 空文字で初期化
    }

    // UI更新
    public void UpdateUI(float timer)
    {
        if(timer <= 0)
        {
            this.text.text = "GO";
            Invoke("HideText", 1f);  // 1秒後にHideText関数を呼ぶ
        }
        else
        {
            int value = (int)timer + 1;  // 3, 2, 1という数字を作る
            this.text.text = value.ToString();  // ToStringで文字列に変換
        }
        
    }

    void HideText()
    {
        this.text.text = "";
    }
}
