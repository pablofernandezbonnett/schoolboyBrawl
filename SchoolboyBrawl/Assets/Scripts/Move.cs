using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private float speedX = 5.0f;
    [SerializeField] private float speedZ = 10.0f;
    [SerializeField] private float jump = 3.0f;
    
    private CharacterController _characterController;
    private Rigidbody _rigidbody;
    
    private Vector3 playerVelocity;
    // private bool groundedPlayer;
    // private float playerSpeed = 2.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;
    
    private bool _faceRight;

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _rigidbody = GetComponent<Rigidbody>();
        _faceRight = true;
    }
    
    void Update()
    {
        Movement();
        float horizontal = Input.GetAxis("Horizontal"); 
        if (horizontal > 0 && !_faceRight)
        {
            Flip();
        }
        if (horizontal < 0 && _faceRight)
        {
            Flip();
        }
        Jump();
    }

    private void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal");  // A D
        float vertical = Input.GetAxis("Vertical");      // W S
        Vector3 move = new Vector3(horizontal * speedX, _rigidbody.velocity.y, vertical * speedZ);
        _characterController.Move(move * Time.deltaTime);
        
    //     groundedPlayer = _characterController.isGrounded;
    //     if (groundedPlayer && playerVelocity.y < 0)
    //     {
    //         playerVelocity.y = 0f;
    //     }
    //
    //     Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    //     _characterController.Move(move * (Time.deltaTime * playerSpeed));
    //
    //     if (move != Vector3.zero)
    //     {
    //         gameObject.transform.forward = move;
    //     }
    //
    //     // Changes the height position of the player..
    //     if (Input.GetButtonDown("Jump") && groundedPlayer)
    //     {
    //         playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
    //     }
    //
    //     playerVelocity.y += gravityValue * Time.deltaTime;
    //     _characterController.Move(playerVelocity * Time.deltaTime);
    
    }
    
    private void Flip()
    {
        _faceRight = !_faceRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    
    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && _characterController.isGrounded)
        {
            _rigidbody.AddForce(Vector3.up * jump, ForceMode.Impulse);
        }
    }
}
