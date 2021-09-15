using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<Image>().color = Color.green;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void calculateColor(int life)
    {
        if (life > 70)
        {
            this.gameObject.GetComponent<Image>().color = Color.green;
        }
        else if (life <=70 && life>= 50)
        {
            this.gameObject.GetComponent<Image>().color = Color.yellow;
        }
        else if (life < 50 && life >= 30)
        {
            this.gameObject.GetComponent<Image>().color = new Color32(247, 94, 37, 100);
        }
        else { 
        this.gameObject.GetComponent<Image>().color = Color.red;
        }
        this.gameObject.GetComponent<Image>().fillAmount = life / 100f;
    }
}
