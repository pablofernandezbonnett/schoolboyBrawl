using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] Text timeText;
    private float _spentTime;
    void Start()
    {
        _spentTime = 61.0f;
    }

    // Update is called once per frame
    void Update()
    {
        _spentTime -= Time.deltaTime;
        DisplayTime(_spentTime);
      
    }
    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay -= 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
  
    }
}
