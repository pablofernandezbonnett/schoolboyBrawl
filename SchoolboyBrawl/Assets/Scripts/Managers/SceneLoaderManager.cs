using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderManager : MonoBehaviour
{
    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadNextScene()
    {
        var activeScene = SceneManager.GetActiveScene();
        var index = activeScene.buildIndex + 1;
        SceneManager.LoadScene(index);
    }

    public void Quit()
    {
        Debug.Log("EXIT APP");
        Application.Quit();
    }

    public void Options()
    {
        Debug.Log("OPTIONS");
    }
}
