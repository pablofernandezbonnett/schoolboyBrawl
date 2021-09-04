using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    public int currentHealth;
    [SerializeField] private Player player;

    [SerializeField] private AudioClip hurtSound, deathSound;
    [HideInInspector] public Animator myAnimator;

    public HealthBar healthbar;

    private bool isDead;

    // Start is called before the first frame update
    void Start()
    {
        this.currentHealth = this.maxHealth;
        this.healthbar.SetMaxHealth(maxHealth);
        this.myAnimator = this.GetComponent<Animator>();
        this.isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            ResetHitCounter();
            TakeDamage(20);
            
        }
    }

    public void TakeDamage(int damage)
    {
        this.currentHealth -= damage;
        this.healthbar.SetHealth(currentHealth);
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
            myAnimator.SetTrigger("isDead");
            myAnimator.Play("Death");
            AudioSource.PlayClipAtPoint(deathSound, this.transform.position);
            healthbar.SetHealth(currentHealth);
            this.enabled = false;
            //score.Reset();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") && currentHealth > 0)
        {
            TakeDamage(20);
        }
        else if (other.gameObject.CompareTag("Enemy") && currentHealth <= 0)
        {
            Death();
        }
    }

    private void ResetHitCounter()
    {
        
        player.GetComponent<PlayerAttack>().hitCount = 0;
        player.GetComponent<PlayerAttack>().textMeshPro.enabled = false;
    }
}
