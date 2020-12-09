using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZankiUIController : MonoBehaviour
{
    public Image zanki1;
    public Image zanki2;
    public Image zanki3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.zanki== 3)
        {
            this.zanki1.enabled = true;
            this.zanki2.enabled = true;
            this.zanki3.enabled = true;
        }
        else if (GameManager.Instance.zanki == 2)
        {
            this.zanki1.enabled = true;
            this.zanki2.enabled = true;
            this.zanki3.enabled = false;
        }
        else if (GameManager.Instance.zanki == 1)
        {
            this.zanki1.enabled = true;
            this.zanki2.enabled = false;
            this.zanki3.enabled = false;
        }
        else if (GameManager.Instance.zanki == 0)
        {
            this.zanki1.enabled = false;
            this.zanki2.enabled = false;
            this.zanki3.enabled = false;
        }
    }
}
