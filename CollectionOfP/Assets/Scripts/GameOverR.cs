using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverR : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Invoke("Destroy", 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*
    void Destroy()
    {
        Destroy(gameObject);
        Debug.Log("消えた時間" + Time.time);
    }
    */

    
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("GameOver");
        GameManager.Instance.ChangeState(GameManager.State.Dead);
    }
    //other.gameObject.tag == "Finish"
}
