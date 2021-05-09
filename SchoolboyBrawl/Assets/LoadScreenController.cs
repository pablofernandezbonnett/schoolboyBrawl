using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadScreenController : MonoBehaviour
{
     [SerializeField] private TextMeshProUGUI tittleText;
    [SerializeField] private TextMeshProUGUI subTittleText;
    private string tittle="";
    private string subTittle = "";
    private int counter=0;
    //char[] tittleArray = { 'S', 'c', 'h', 'o', 'o', 'l', 'B', 'o', 'y', ' ', 'B', 'r', 'a', 'w', 'l' };
    [SerializeField] private  string tittleArray = "SchoolBoy Brawl";
    [SerializeField]  private string subTittleArray = "An Unepic Adventure";
    [SerializeField] private AudioSource whiteBoardAudio;
    // Start is called before the first frame update
    void Start()
    {
        // tittleText = GetComponent<TextMeshProUGUI>();
        Invoke("TittleFill", 1.2f);
 
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    void TittleFill()
    {
        tittle= tittle+ tittleArray[counter];
        tittleText.text = tittle;
        if (counter+1 < tittleArray.Length)
        {
            counter++;
            Invoke("TittleFill", 0.15f);
        }
        else
        {
            counter=0;
            Invoke("SubTittleFill", 0.15f);
        }
    }

    void SubTittleFill()
    {
        subTittle = subTittle + subTittleArray[counter];
        subTittleText.text = subTittle;
        if (counter + 1 < subTittleArray.Length)
        {
            counter++;
            Invoke("SubTittleFill", 0.15f);
        }
        else
        {
            Invoke("MenuScreenLoader", 1.2f);

        }
    }

    void MenuScreenLoader()
    {
        SceneManager.LoadScene("MenuScreen");
    }
}
