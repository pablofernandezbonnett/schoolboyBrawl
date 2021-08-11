
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private Animator myAnimator;
    private Rigidbody myRB;
    private bool jump;
    private bool grounded;


    // Start is called before the first frame update
    void Start()
    {
        myRB = this.GetComponent<Rigidbody>();
        myAnimator = this.GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        Debug.Log(OnGround());
        Debug.DrawRay(this.transform.position, this.transform.TransformDirection(Vector3.down) * 1f, Color.red);
        ResetValues();
    }

    void Jump()
    {
        if (OnGround() && Input.GetButtonDown("Jump"))
        {
            myRB.velocity = Vector3.up * jumpForce;
            jump = true;
            grounded = false;
        }
        else
          
            jump = false;
            grounded = true;

        if (jump)
        {
            this.myAnimator.SetBool("IsJumping", true);
            this.myAnimator.SetBool("OnGround", false);
        }
        else
            this.myAnimator.SetBool("IsJumping", false);
        this.myAnimator.SetBool("OnGround", true);
    }

    bool OnGround()
    {
         return Physics.Raycast(this.transform.position, Vector3.down, 1f);

    }

   void ResetValues()
    {
        jump = false;
        grounded = true;
    }
}
