using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSessionManager : MonoBehaviour
{
    // make the GameSession a Singleton pattern, only one active instance
    [SerializeField] private int playerLives = 3;
    [SerializeField] private int playerScore;
    [SerializeField] private Text lives;
    [SerializeField] private Text score;

    private void Awake()
    { 
        int numberOfGameSessions = FindObjectsOfType<GameSessionManager>().Length;
        if (numberOfGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            /* Call Object.DontDestroyOnLoad to preserve an Object during level loading.
               If the target Object is a component or GameObject, Unity also preserves all of the Transform’s children. 
               Object.DontDestroyOnLoad does not return a value.
            */
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        lives.text = playerLives.ToString();
        score.text = playerScore.ToString();
    }

    public void ProcessPlayerDeath()
    {
        if (playerLives > 1)
        {
            // take a life from player life's pool
            TakeLife();
        }
        else
        {
            // reset game progess/session, player is death, Game Over
            ResetGameSession();
        }
    }

    // called when player picks a coin up
    public void AddToScore(int pointToAdd)
    {
        // add new point to score
        playerScore += pointToAdd;
        // add updated score to score text
        score.text = playerScore.ToString();
    }

    private void TakeLife()
    {
        // take a life from player life's pool
        playerLives--;
        // reload current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        // update lives text
        lives.text = playerLives.ToString();
    }
    
    private void ResetGameSession()
    {
        // back to main scene (main menu, level1...)
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }
}
