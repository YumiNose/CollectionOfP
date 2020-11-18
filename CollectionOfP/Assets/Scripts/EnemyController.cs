using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Vector2 defaultPosition;  // 初期位置
    Quaternion defaultRotation;  // 初期向き


    // [SerializeField]を使って座標を書く？


    // Start is called before the first frame update
    void Start()
    {
        // 位置を記録
        this.defaultPosition = transform.position;
        this.defaultRotation = transform.rotation;
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

        
        // GameManagerのStateがReadyの時に再配置を行う
        if(GameManager.Instance.GetState() == GameManager.State.Ready)
        {
            Restart();  // 再配置
        }

        if (GameManager.Instance.GetState() != GameManager.State.Game)
        {
            return;
        }


        // 移動スクリプト
        transform.Translate(1f * Time.deltaTime, 0, 0);

        // 死ぬ処理（仮）
        if(Input.GetKeyDown(KeyCode.D))
        {
            // 再配置を考え世界の果てに飛ばす
            transform.position = new Vector3(0, -500f, 0);
        }
    }
}
