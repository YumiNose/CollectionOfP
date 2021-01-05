using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ParticleController : MonoBehaviour
{
    [SerializeField]
    ParticleSystem pObject;

    //ここでパーティクルが停止される時間を指定
    float particleDelayTime = .2f;

    public GameObject Star_A;

    GameObject Wave;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        pObject.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K) )//&& pObject.isStopped)
        {
            pObject.gameObject.SetActive(true);
            pObject.Simulate(4.0f, true, false); //追記
            pObject.Play(); //追記
            StartCoroutine(delay(particleDelayTime, () => 
            {
                pObject.gameObject.SetActive(false);
            }));

            //for Debug
            Debug.Log("合わせた！");
        }
        Instantiate(this.Star_A, this.Wave.transform.position, transform.rotation);
    }


    IEnumerator delay(float waitTime, UnityAction action)
    {
        yield return new WaitForSeconds(waitTime);
        action();
    }
}
