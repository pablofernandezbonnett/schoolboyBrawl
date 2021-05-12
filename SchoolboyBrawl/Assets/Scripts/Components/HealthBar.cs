using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Gradient gradient;
    [SerializeField] private Image fill;

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
        // full health => green color
        fill.color = gradient.Evaluate(slider.maxValue);
    }
    
    public void SetHealth(int health)
    {
        slider.value = health;
        // health bar takes yellow or red color depending on health level
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public float GetHealth()
    {
        return slider.value;
    }

    public void DecreaseHealth(int decrease)
    {
        float currentHealth = GetHealth();
        if (currentHealth > 0)
        {
            currentHealth -= decrease;
            SetHealth((int)currentHealth);
        }
    }
    
    // for testing only
    void Start()
    {
        SetMaxHealth(100);
        Debug.Log(" START GetHealth " + GetHealth());
    }
    
    void Update()
    {
        int damage = 10;
        if (Input.GetButtonDown("Jump"))
        {
            DecreaseHealth(damage);
        }
    }
}
