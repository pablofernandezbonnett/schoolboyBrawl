using TMPro;
using UnityEngine;

public class HitCounter : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI textMeshPro;
    [HideInInspector] public int _hitCounter;
    private float defaultTimer = 3f;
    private float currentTimer;
    private bool activateTimeToReset;
    
    void Start()
    {
        _hitCounter = 0;
        textMeshPro = GetComponentInChildren<TextMeshProUGUI>();
        HideHitCounter();
        currentTimer = defaultTimer;
        activateTimeToReset = false;

    }
    
    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl))
        //{
        //    IncreaseHitCounter();
        //}
        TimedResetCount();
        
    }

    public void IncreaseHitCounter()
    {
        textMeshPro.enabled = true;
        _hitCounter++;
        textMeshPro.text = _hitCounter.ToString() + "HITS";
        activateTimeToReset = true;

    }

    private void HideHitCounter()
    {
        textMeshPro.enabled = false;
    }

    public void TimedResetCount()
    {
        if (activateTimeToReset)
        {
            currentTimer -= Time.deltaTime;
            if(currentTimer <= 0)
            {
                _hitCounter = 0;
                textMeshPro.enabled = false;
                activateTimeToReset = false;
                currentTimer = defaultTimer;
            }
        }
    }

    public void OnHitReset()
    {
        _hitCounter = 0;
        this.textMeshPro.enabled = false;
    }
}
