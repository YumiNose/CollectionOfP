using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class BackGroundController : MonoBehaviour
{
    [SerializeField]
    GameObject bgA;  // 背景A

    [SerializeField]
    GameObject bgB;  // 背景B

    float width;  // カメラが写している範囲(ｍ)

    // Start is called before the first frame update
    void Start()
    {
        // カメラが写す範囲を求める
        float aspect = (float)Screen.width / Screen.height;
        this.width = Camera.main.orthographicSize * aspect * 2;
    }

    // Update is called once per frame
    void Update()
    {
        Move(this.bgA);
        Move(this.bgB);
    }

    // 背景を動かす関数
    void Move(GameObject bg)
    {
        float cameraX = Camera.main.gameObject.transform.position.x;

        // カメラと背景のX方向の位置の差を求める
        float distanceX = cameraX - bg.transform.position.x;

        // 求めた結果 画面幅以上離れたら
        if(distanceX > this.width)
        {
            // カメラの位置 + this.width
            bg.transform.Translate(this.width * 2, 0, 0);
        }
        if(distanceX < -this.width)
        {
            // カメラの位置 + this.width
            bg.transform.Translate(-this.width * 2, 0, 0);
        }

    }

}
