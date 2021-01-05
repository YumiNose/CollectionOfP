using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // UI作る時に必須

public class HPController : MonoBehaviour
{
    [SerializeField]
    int maxHP = 300;  // 最大HP
    public int hp;           // 現在のHP
    int lastHP;       // ダメージを受ける前のHP
    
    
    RectTransform damageUI;  // ダメージ用UI
    RectTransform hpUI;      // HP用UI

    float moveTime = 1; // ダメージUIを動かす　単位は秒
    float timer = 0;    // ダメージUIを動かす用のタイマー変数

    public int hpReset;  // 死んだらHPを元に戻す

    // Start is called before the first frame update
    void Start()
    {
        this.damageUI = transform.Find("Damage").GetComponent<RectTransform>();
        this.hpUI = transform.Find("HP").GetComponent<RectTransform>();

        // HPを最大HPに合わせる
        this.hp = this.maxHP;

    }

    public void Reset()
    {
        // HPを最大HPに合わせる
        this.hp = this.maxHP;

        // HPUIのスケールを変えてHPが減ったように見せる
        this.hpUI.localScale = new Vector3(1, 1, 1);

        // ダメージUIのスケールを変更
        this.damageUI.localScale = new Vector3(1, 1, 1);
    }


    // Update is called once per frame
    void Update()
    {
        // タイマー
        if(this.timer > 0)
        {
            this.timer -= Time.deltaTime;  // タイマーを減らす
            if(this.timer < 0)  // 下限チェック
            {
                this.timer = 0;
            }

            // ダメージを受ける前のHPからダメージを受けた後のHPまで徐々に減らす
            //                        A地点 0    B地点 1                   割合
            float scale = Mathf.Lerp(this.hp, this.lastHP, this.timer / this.moveTime) / this.maxHP;
            // ダメージUIのスケールを変更
            this.damageUI.localScale = new Vector3(scale, 1, 1);
        }
    }

    /// <summary>
    /// ダメージを与える
    /// </summary>
    /// <param name="damage"></param>
    public void Damage(int damage)
    {
        this.lastHP = this.hp;  // ダメージを受ける前のHPを記録
        
        this.hp -= damage;
        if(this.hp < 0)   // 下限チェック
        {
            this.hp = 0;
        }
        // HPUIのスケールを変えてHPが減ったように見せる
        this.hpUI.localScale = new Vector3((float)this.hp / this.maxHP, 1, 1);

        // タイマーをセット
        this.timer = this.moveTime;
    }

}
