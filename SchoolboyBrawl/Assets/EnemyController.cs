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

    void Start()
    {
        myAnimator = this.GetComponent<Animator>();
        myAnimator.SetBool("Walking", true);

       
    }

    // Update is called once per frame
    void Update()
    {
        ChangeEnemyPosition();
        CheckFlip();

    }


  public void CheckFlip()
    {
        if(transform.position.x < waypointsEnemy[nextPosition].transform.position.x)
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


}
