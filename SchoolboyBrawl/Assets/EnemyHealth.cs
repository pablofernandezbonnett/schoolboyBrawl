using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    public int currentHealth;
    private EnemyMovement myEnemy;
    [SerializeField] private AudioClip hurtSound, deathSound;
    private Animator myAnimator;
    [SerializeField] HealthBarController myHealthBar;
    [SerializeField] private EnemyPositionController myPositionController;
    private bool isDead;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        this.currentHealth = this.maxHealth;
        this.myAnimator = this.GetComponent<Animator>();
        this.myEnemy = this.GetComponent<EnemyMovement>();
        this.isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        myHealthBar.calculateColor(currentHealth);
    }

    public void TakeDamage(int damage)
    {
        this.currentHealth -= damage;
        //healthBar.SetHealth(currentHP);
        this.myAnimator.SetTrigger("isHit");
        AudioSource.PlayClipAtPoint(hurtSound, this.transform.position);

        if (this.currentHealth <= 0)
        {
            Death();
        }
        
        Debug.Log("Salud enemigo:" + this.currentHealth);
        //Destroy(this.gameObject);
       // myAnimator.SetBool("isDead", true);
        //myEnemy.NoMovement();
        //this.myPositionController.decreaseEnemies();


    }

    public void Death()
    {
        if (this.currentHealth <= 0)
        {
            isDead = true;
            myAnimator.SetBool("isDead", true);
            AudioSource.PlayClipAtPoint(deathSound, this.transform.position);
            Destroy(this.gameObject);
            // myAnimator.SetBool("isDead", true);
            //myEnemy.NoMovement();
            this.myPositionController.decreaseEnemies();
            this.enabled = false;
            Destroy(this, 0.5f);
            //score.Reset();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player = other.gameObject;
            if (player.GetComponent<PlayerAttack>().isDoAtack == true) { 
            TakeDamage(20);
        }
            if( currentHealth > 0)
            {

            }




        }
      
    }

    private void OnTriggerExit(Collider other)
    {
    

    }

}

