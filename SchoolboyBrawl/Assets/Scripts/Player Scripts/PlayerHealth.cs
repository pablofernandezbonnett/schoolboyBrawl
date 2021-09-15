using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    public int currentHealth;

    [SerializeField] private AudioClip hurtSound, deathSound;
    private Animator myAnimator;

    private bool isDead;

    // Start is called before the first frame update
    void Start()
    {
        this.currentHealth = this.maxHealth;
        this.myAnimator = this.GetComponent<Animator>();
        this.isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage()
    {
        this.currentHealth -= 10;
        //healthBar.SetHealth(currentHP);
        this.myAnimator.SetTrigger("isHit");
        AudioSource.PlayClipAtPoint(hurtSound, this.transform.position);
    
        if (this.currentHealth <= 0)
        {
            Death();
        }
    } 

    public void Death()
    {
        if (this.currentHealth <= 0)
        {
            isDead = true;
            myAnimator.SetBool("isDead", true);
            AudioSource.PlayClipAtPoint(deathSound, this.transform.position);
            //healthBar.SetHealth(currentHP);
            this.enabled = false;
            //score.Reset();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") && currentHealth > 0){
            TakeDamage();
        }
        else if(other.gameObject.CompareTag("Enemy") && currentHealth <= 0)
        {
            Death();
        }
    }
}
