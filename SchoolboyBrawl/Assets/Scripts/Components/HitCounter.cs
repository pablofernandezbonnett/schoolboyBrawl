using TMPro;
using UnityEngine;

public class HitCounter : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI textMeshPro;
    
    private int _hitCounter;
    
    void Start()
    {
        _hitCounter = 0;
        textMeshPro = GetComponentInChildren<TextMeshProUGUI>();
    }
    
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            IncreaseHitCounter();
        }
    }

    private void IncreaseHitCounter()
    {
        _hitCounter++;
        textMeshPro.text = _hitCounter.ToString() + "HITS";
    }
}
