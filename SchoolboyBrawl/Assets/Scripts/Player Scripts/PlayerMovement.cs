using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float xMovementSpeed;
    [SerializeField] private float zMovementSpeed;
    [SerializeField] private float slideDistance;
    private bool isSliding;
    private float doubleTapTime;
    private KeyCode lastKeyCode;

    private float horizontal;
    private float vertical;

    private Animator myAnimator;
    private Rigidbody myRB;
    private bool isFacingRight;

    private void Start()
    {
        myAnimator = this.GetComponent<Animator>();
        myRB = this.GetComponent<Rigidbody>();


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
        Slide();

    }

    void Movement(float horizontal)
    {
        if (!isSliding)
        {
            this.transform.Translate(Vector3.left * Input.GetAxis("Vertical") * this.zMovementSpeed * Time.deltaTime); //to move "up and down" on global Z Axis

            this.transform.Translate(Vector3.forward * Input.GetAxis("Horizontal") * this.xMovementSpeed * Time.deltaTime); //to move forwards and backwards on global X Axis

            this.myAnimator.SetFloat("Speed", Mathf.Abs(horizontal != 0 ? horizontal : vertical));
        }
       
    }

    void Slide()
    {

        if (Input.GetKeyDown(KeyCode.A))
        {
            if (doubleTapTime > Time.time && lastKeyCode == KeyCode.A)
            {
                StartCoroutine(SlideTackle(-1f));
                myAnimator.SetBool("isSliding", true);
            }
            else
            {
                doubleTapTime = Time.time + 0.3f;
            }
            lastKeyCode = KeyCode.A;
        }else
            myAnimator.SetBool("isSliding", false);

        if (Input.GetKeyDown(KeyCode.D))
        {
            if (doubleTapTime > Time.time && lastKeyCode == KeyCode.D)
            {
                StartCoroutine(SlideTackle(1f));
                myAnimator.SetBool("isSliding", true);
            }
            else
            {
                doubleTapTime = Time.time + 0.3f;
            }
            lastKeyCode = KeyCode.D;
        }else
            myAnimator.SetBool("isSliding", false);


    }


    void Flip(float horizontal)
    {
        if (horizontal < 0 && !isFacingRight || horizontal > 0 && isFacingRight)
        {
            isFacingRight = !isFacingRight;

            Vector3 scale = transform.localScale;

            scale.z *= -1;

            transform.localScale = scale;
        }
    }
    
    private IEnumerator SlideTackle(float direction)
    {
        isSliding = true;
        myRB.velocity = new Vector3(myRB.velocity.x, 0f, 0f);
        myRB.AddForce(new Vector3(slideDistance * direction, 0f, 0f), ForceMode.Impulse);
        yield return new WaitForSeconds(0.4f);
        isSliding = false;
        
    }
}