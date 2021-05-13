using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange;
    public LayerMask enemyLayers;

    private Animator myAnimator;
    private bool attack;
    [SerializeField] private int attackDmg;
    // Start is called before the first frame update
    void Start()
    {
        attack = false;
        myAnimator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
        ResetValues();
    }

    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.RightControl))
        {
            attack = true;
            if (attack && !this.myAnimator.GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
            {
                myAnimator.SetTrigger("Attack");
                Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
                Debug.Log(hitEnemies.Length);
                foreach (Collider2D enemy in hitEnemies)
                {
                    Debug.Log("Hit" + enemy.name);
                    enemy.GetComponent<EnemyController>().TakeDamage(attackDmg);
                }
            }
        }
    }

    void ResetValues()
    {
        attack = false;
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, this.attackRange);
    }

    //void HandleInput() //Para gestionar los golpes contra los enemigos
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        attack = true;

    //        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

    //        foreach (Collider2D enemy in hitEnemies)
    //        {
    //            Debug.Log("Hit" + enemy.name);
    //            enemy.GetComponent<BaseEnemy>().TakeDamage(attackDmg);
    //        }
    //    }
    //}
}
