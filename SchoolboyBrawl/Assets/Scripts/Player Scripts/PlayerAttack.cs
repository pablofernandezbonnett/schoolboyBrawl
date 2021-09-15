using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ComboState
{
    NONE,
    PUNCH1,
    PUNCH2,
    PUNCH3,
    KICK1,
    KICK2
}
public class PlayerAttack : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange;
    public LayerMask enemyLayers;
    public bool isDoAtack;
    private Rigidbody myRB;
    private Animator myAnimator;
    private AudioSource myAudio;
    private bool punch;
    private bool kick;
    [SerializeField] private int attackDmg;
    [SerializeField] private AudioClip attackSound, hitSound;
   
    private bool activateTimerToReset;
    private float default_ComboTimer = 0.4f;
    private float current_ComboTimer;
    private ComboState currentComboState;

    
    // Start is called before the first frame update
    void Start()
    {
        punch = false;
        kick = false;
        isDoAtack = false;
        myAnimator = this.GetComponent<Animator>();
        myRB = this.GetComponent<Rigidbody>();
        current_ComboTimer = default_ComboTimer;
        currentComboState = ComboState.NONE;
   
    }

    // Update is called once per frame
    void Update()
    {
        Punch();
        Kick();
        ResetValues();
        ComboAttacks();
        ResetComboState();
        Debug.Log(currentComboState);
    }

    void Punch()
    {
        if (Input.GetKeyDown(KeyCode.RightControl) || (Input.GetKeyDown(KeyCode.LeftControl)))
        {
            punch = true;
            isDoAtack = true;
            Invoke("changeValueAtack", 0.9f);
            if (punch) //&& !this.myAnimator.GetCurrentAnimatorStateInfo(0).IsTag("Punch"))
            {
                //myAnimator.SetTrigger("Punch");
                Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);
                Debug.Log(hitEnemies.Length);
                foreach (Collider enemy in hitEnemies)
                {
                    Debug.Log("Hit" + enemy.name);
                    enemy.GetComponent<EnemyController>().TakeDamage(attackDmg);
                    
                }

                AudioSource.PlayClipAtPoint(attackSound, this.transform.position);
                if (hitEnemies.Length > 0)
                {
                    AudioSource.PlayClipAtPoint(hitSound, this.transform.position);
                }
               

            }
        }
    }

    void Kick()
    {
        if (Input.GetKeyDown(KeyCode.Z) || (Input.GetKeyDown(KeyCode.Minus)))
        {
            kick = true;
            if (kick)// && !this.myAnimator.GetCurrentAnimatorStateInfo(0).IsTag("Kick"))
            {
                isDoAtack = true;
                Invoke("changeValueAtack", 0.9f);
                //myAnimator.SetTrigger("Kick");
                Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);
                Debug.Log(hitEnemies.Length);
                foreach (Collider enemy in hitEnemies)
                {
                    Debug.Log("Hit" + enemy.name);
                    enemy.GetComponent<EnemyController>().TakeDamage(attackDmg);
                }
                AudioSource.PlayClipAtPoint(attackSound, this.transform.position);
                if (hitEnemies.Length > 0)
                {
                    AudioSource.PlayClipAtPoint(hitSound, this.transform.position);
                }
            }
        }
    }


    void changeValueAtack()
    {
        isDoAtack = false;
    } 
    void ComboAttacks()
    {
        if (Input.GetKeyDown(KeyCode.RightControl) || (Input.GetKeyDown(KeyCode.LeftControl)))
        {
            currentComboState++;
            activateTimerToReset = true;
            current_ComboTimer = default_ComboTimer;

            if (currentComboState == ComboState.KICK1 || currentComboState == ComboState.KICK2)
                return;

            if(currentComboState == ComboState.PUNCH1)
            {
                myAnimator.Play("Jab");
            }
            if (currentComboState == ComboState.PUNCH2)
            {
                myAnimator.Play("ElbowPunch");
            }
            if (currentComboState == ComboState.PUNCH3)
            {
                myAnimator.Play("CrossPunch");
            }
        }

        if (Input.GetKeyDown(KeyCode.Minus) || (Input.GetKeyDown(KeyCode.Less)))
        {

            if (currentComboState == ComboState.KICK2 || currentComboState == ComboState.PUNCH3)
                return;

            if(currentComboState == ComboState.NONE || currentComboState == ComboState.PUNCH1 || currentComboState == ComboState.PUNCH2)
            {
                currentComboState = ComboState.KICK1;
            }else if(currentComboState == ComboState.KICK1) {
                currentComboState++;
            }
            
            activateTimerToReset = true;
            current_ComboTimer = default_ComboTimer;

            if(currentComboState == ComboState.KICK1)
            {
                myAnimator.Play("HiKick");
            }

            if (currentComboState == ComboState.KICK2)
            {
                myAnimator.Play("ScissorKick");
            }
        }
    }

    void ResetComboState()
    {
        if (activateTimerToReset)
        {
            current_ComboTimer -= Time.deltaTime;

            if(current_ComboTimer <= 0)
            {
                currentComboState = ComboState.NONE;
                activateTimerToReset = false;
                current_ComboTimer = default_ComboTimer;
                isDoAtack = false;
            }
        }
    }


    void ResetValues()
    {
        punch = false;
        kick = false;
      
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, this.attackRange);
    }


}
