using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timeText;

    private float _spentTime;

    void Start()
    {
        _spentTime = 0.0f;
    }
    
    // Update is called once per frame
    void Update()
    {
        _spentTime += Time.deltaTime;
        DisplayTime(_spentTime);
    }
    
    /// <summary>
    /// Displays timer time on UI Canvas
    /// </summary>
    /// <param name="timeToDisplay"></param>
    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

}
