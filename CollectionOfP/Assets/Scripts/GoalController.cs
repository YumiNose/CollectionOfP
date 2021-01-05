using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Invoke("OnTriggerStay2D", 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("ゴール");
        GameManager.Instance.ChangeState(GameManager.State.Clear);
    }
}
