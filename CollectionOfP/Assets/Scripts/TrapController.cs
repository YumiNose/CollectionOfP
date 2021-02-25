using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapController : MonoBehaviour
{
    [SerializeField]
    public GameObject EnemyS;


    // Trapについているコライダーに触れて
    private void OnTriggerEnter2D(Collider2D other)
    {
        // もしPlayerというタグに触れたら
        if (other.gameObject.CompareTag("Player"))
        {
            // 敵を見えるようにする(元々見えない状態)
            EnemyS.SetActive(true);
        }
        Debug.Log("Trap作動");
    }


}
