using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController2 : MonoBehaviour
{
    [SerializeField]
    PlayerController playerController;

    [SerializeField]
    Vector3 offset;  // ターゲットとカメラのズレ

    [SerializeField]
    float smooth = 4f;  // 滑らかに動かすためのパラメータ


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // offsetの値を加工して使うのでコピーを作成
        Vector3 offset = this.offset;

        // カメラのZ座標は動かしたくないのでZ座標は元々の値を使用
        offset.z = transform.position.z;

        // 左を向いている場合
        if (this.playerController.isLeft())
        {
            // offset.xだけマイナスにする
            offset.x *= -1f;
            
        }

        // 目標地点の座標を作成
        Vector3 targetPosition = this.playerController.gameObject.transform.position + offset;
        targetPosition.y = transform.position.y;

        // 線形補間で座標を決める
        transform.position = Vector3.Lerp(transform.position, targetPosition, this.smooth * Time.deltaTime);
        
    }
}
