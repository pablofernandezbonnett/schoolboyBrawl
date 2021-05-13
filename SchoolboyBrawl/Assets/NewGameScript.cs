using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class NewGameScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void NewGame()
    {
        SceneManager.LoadScene("SelectCharacterScreen");
    }
    public void StartNewGame()
    {
        SceneManager.LoadScene("PruebasEnemigo");
    }
    public void Options()
    {
        SceneManager.LoadScene("PantallaMenu");
    }
    public void Menu()
    {
        SceneManager.LoadScene("MenuScreen");
    }
    public void Options2()
    {
        SceneManager.LoadScene("PantallaMenuOptions");
    }
}
