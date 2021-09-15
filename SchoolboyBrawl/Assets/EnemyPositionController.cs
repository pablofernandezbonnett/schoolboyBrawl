using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyPositionController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject[] listOfEnemies;
    [SerializeField] private Transform[] listOfPositions;
       [SerializeField] private GameObject bigBoss;
    [SerializeField] private AudioClip normalSound;
    [SerializeField] private AudioClip bossSound;
    public AudioSource myMusic; 
    [SerializeField] private GameObject[] enemySimbolsArray;
    [SerializeField] private GameObject theBossText;
    [SerializeField] private GameObject winText;

    private int pos = 0;
    private int numberOfEnemies;


    private void Awake()
    {
        myMusic.GetComponent<AudioSource>();
        myMusic.Stop();
        myMusic.clip = normalSound;
        myMusic.Play();
        bossTextDisable();
        WinTextDisable();

    }
    void Start()
    {
    
        numberOfEnemies = listOfEnemies.Length;
        while (numberOfEnemies > pos-1) { 
        listOfEnemies[pos].transform.position = listOfPositions[pos].position;
            if (pos == numberOfEnemies - 1)
            {
                listOfEnemies[pos].GetComponent<EnemyMovement>().setNotActive();
            }
            pos++;
        }
       
    }

    // Update is called once per frame
    void Update()
    {

        if (numberOfEnemies > 0)
        {
           // listOfEnemies[listOfEnemies.Length].transform.position = listOfPositions[listOfEnemies.Length-1].position;
        }
        else
        {
            Win();
        }
        if (numberOfEnemies == 2)
        {
            bossComing();
           
        }
        
      
    }


    public void Win()
    {
        WinTextActive();
        Invoke("nextLevel",3.0f);
       
    }

    public void nextLevel()
    {
        SceneManager.LoadScene("Level2");
    }
    public void bossComing()
    {
        bossTextActive();
        listOfEnemies[pos-1].GetComponent<EnemyMovement>().setActive();
        Invoke("bossTextDisable", 3.0f);
        bossSoundActive();
    }


    public void bossSoundActive()
    {
        myMusic.Stop();
        myMusic.clip = bossSound;
        myMusic.Play();
    }
 
    public void bossTextActive()
    {
        theBossText.SetActive(true);
    }
    public void bossTextDisable()
    {
        theBossText.SetActive(false);
    }


    public void WinTextActive()
    {
        winText.SetActive(true);
    }
    public void WinTextDisable()
    {
        winText.SetActive(false);
    }
    public void decreaseEnemies()
    {
        numberOfEnemies--;
 
        Debug.Log("resta enemigo");
        Destroy(enemySimbolsArray[this.numberOfEnemies].gameObject);
        if (numberOfEnemies <= 0)
        {
            listOfEnemies[listOfEnemies.Length].transform.position = listOfPositions[listOfEnemies.Length].position;
        }
        
    }
}
