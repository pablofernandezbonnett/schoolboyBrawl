using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange;
    public LayerMask enemyLayers;

    private Rigidbody myRB;
    private Animator myAnimator;
    private bool punch;
    private bool kick;
    [SerializeField] private int attackDmg;
    // Start is called before the first frame update
    void Start()
    {
        punch = false;
        kick = false;
        myAnimator = this.GetComponent<Animator>();
        myRB = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Punch();
        Kick();
        ResetValues();
    }

    void Punch()
    {
        if (Input.GetKeyDown(KeyCode.RightControl) || (Input.GetKeyDown(KeyCode.LeftControl)))
        {
            punch = true;
            if (punch && !this.myAnimator.GetCurrentAnimatorStateInfo(0).IsTag("Punch"))
            {
                myAnimator.SetTrigger("Punch");
                Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);
                Debug.Log(hitEnemies.Length);
                foreach (Collider enemy in hitEnemies)
                {
                    Debug.Log("Hit" + enemy.name);
                    enemy.GetComponent<EnemyController>().TakeDamage(attackDmg);
                }


            }
        }
    }

    void Kick()
    {
        if (Input.GetKeyDown(KeyCode.Minus) || (Input.GetKeyDown(KeyCode.Less)))
        {
            kick = true;
            if (kick && !this.myAnimator.GetCurrentAnimatorStateInfo(0).IsTag("Kick"))
            {
                myAnimator.SetTrigger("Kick");
                Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);
                Debug.Log(hitEnemies.Length);
                foreach (Collider enemy in hitEnemies)
                {
                    Debug.Log("Hit" + enemy.name);
                    enemy.GetComponent<EnemyController>().TakeDamage(attackDmg);
                }


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
