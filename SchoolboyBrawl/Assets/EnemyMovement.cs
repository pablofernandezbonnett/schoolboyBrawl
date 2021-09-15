using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float xMovementSpeed;
    [SerializeField] private float zMovementSpeed;
    [SerializeField] private float slideDistance;
    [SerializeField] private bool activeEnemy;
    [SerializeField] private bool isBigBoss;
    private float horizontal;
    private float vertical;

    private Animator myAnimator;
    private Rigidbody myRB;
    private bool isFacingRight;
    private bool isSliding;
    private bool isPlayerNear;
    private float speed;
    private Vector3 playerPosition;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject enemy;
    void Start()
    {
        myAnimator = this.GetComponent<Animator>();
        myRB = this.GetComponent<Rigidbody>();
        this.isSliding = false;
        this.isPlayerNear = false;
       // myAnimator.SetBool("isIdle", true);
       // myAnimator.SetBool("isWalking", false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        controlEnemy();

    }
  


   public void controlEnemy()
    {

        if (isBigBoss == true)
        {
            if (activeEnemy == false) {    
            myAnimator.SetBool("isIdle", true);
                this.transform.position = this.transform.position;
            }
            else
            {
                lookAtObject();
                myAnimator.SetBool("isIdle", false);
                myAnimator.SetBool("isWalking", true);
                myAnimator.SetBool("isFighting", false);
            }
        }
        else { 
            if (activeEnemy == true)
           {

              lookAtObject();
             myAnimator.SetBool("isIdle", false);
             myAnimator.SetBool("isWalking", true);
              myAnimator.SetBool("isFighting", false);
         }
             else
            {
            myAnimator.SetBool("isFighting", true);
            myAnimator.SetBool("isIdle", false);
            myAnimator.SetBool("isWalking", false);
            
            }
        }
    }
    void lookAtObject()
    {
        playerPosition = player.transform.position;
        playerPosition.y = 0;
        enemy.transform.LookAt(playerPosition);
        speed = zMovementSpeed/2 * Time.deltaTime;
        speed = speed / 2;
        enemy.transform.position= Vector3.MoveTowards(transform.position,   playerPosition , speed);
        myAnimator.SetFloat("Speed", speed);
        myAnimator.SetFloat("Walk", 1);

    }

  

    public void setNotActive()
    {

        this.activeEnemy = false;

    }
    public void setActive()
    {

        this.activeEnemy = true;

    }
 
}
