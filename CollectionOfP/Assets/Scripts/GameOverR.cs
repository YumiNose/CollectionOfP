using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverR : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        Invoke("Destroy", 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Destroy()
    {
        Destroy(gameObject);
        Debug.Log("消えた時間" + Time.time);
    }


    /*
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Finish")
        {
            Debug.Log("GameOver");
        }
    }
    */
}
