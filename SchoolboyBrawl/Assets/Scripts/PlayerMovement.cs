using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    private float horizontal;
    private float vertical;

    private Animator myAnimator;
    private bool isFacingRight;
    //private bool isAttacking = false;

    private void Start()
    {
        myAnimator = this.GetComponent<Animator>();
 
    }
    // Update is called once per frame
    private void Update()
    {
        
    }
    void FixedUpdate()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        Movement(horizontal);
        Flip(horizontal);
        //Attack();
        //ResetValues();
    }

    void Movement(float horizontal)
    {
        this.transform.Translate(Vector3.up * Input.GetAxis("Vertical") * this.movementSpeed * Time.deltaTime);

        this.transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * this.movementSpeed * Time.deltaTime);

        this.myAnimator.SetFloat("Speed", Mathf.Abs(horizontal != 0 ? horizontal : vertical));
    }

    void Flip(float horizontal)
    {
        if (horizontal < 0 && !isFacingRight || horizontal > 0 && isFacingRight)
        {
            isFacingRight = !isFacingRight;

            Vector3 scale = transform.localScale;

            scale.x *= -1;

            transform.localScale = scale;
        }
    }

    //void Attack()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        isAttacking = true;
    //        if (vertical != 0 || horizontal != 0)
    //        {
    //            vertical = 0;
    //            horizontal = 0;
    //            myAnimator.SetFloat("Speed", 0);
    //        }
    //        myAnimator.SetTrigger("Attack");

    //    }
    //}

    //void ResetValues()
    //{
    //    isAttacking = false;
        
    //}
}