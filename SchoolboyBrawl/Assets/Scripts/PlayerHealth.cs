using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    public int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        this.currentHealth = this.maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage()
    {

    }

    public void Death()
    {

    }
}
