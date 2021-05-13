using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform[] waypointsEnemy;
    [SerializeField]  float velocity = 2;
    [SerializeField] float distance = 0.2f;
    private int nextPosition = 0;
    private Animator myAnimator;
    private bool FacingRight = true;
    public Transform player;
    private InstantiateEnemy instantiator;
    
    [SerializeField] private int enemyHealth;
    
    

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        enemyHealth = 15;
        myAnimator = this.GetComponent<Animator>();
        myAnimator.SetBool("Walking", true);
        instantiator = FindObjectOfType<InstantiateEnemy>();


    }

    // Update is called once per frame
    void Update()
    {
       // ChangeEnemyPosition();
       // CheckFlip();
        GoToPlayer();
    }


  public void CheckFlip()
    {
        if(transform.position.x < player.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }


    public void ChangeEnemyPosition()

    {
        
        transform.position = Vector3.MoveTowards(transform.position, waypointsEnemy[nextPosition].transform.position, velocity * Time.deltaTime);
        if(Vector3.Distance(transform.position, waypointsEnemy[nextPosition].transform.position)< distance)
        {
            myAnimator.SetBool("Walking", true);
            if (nextPosition < waypointsEnemy.Length-1)
            {
                nextPosition++;
               
            }
            else
            {
                nextPosition = 0;
            

            }
          

        }
    }

    public void TakeDamage(int damage)
    {
        enemyHealth -= damage;
        if (enemyHealth <= 0)
        {
            EnemyDeath();
        }
    }

    private void EnemyDeath()
    {
        Destroy(this.gameObject);
        Debug.Log(instantiator);
        this.instantiator.NewEnemy();
    }

    private void GoToPlayer()
    {
        
       // transform.LookAt(new Vector3(player.position.x, player.position.y, 0));
        transform.position = Vector2.MoveTowards(transform.position, player.position, velocity * Time.deltaTime);
    }
}
