using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField, Range(1,10), Tooltip("velocidad")] private float speed;
    [SerializeField, Range(1,10), Tooltip("salto")] private float jump;

    private Rigidbody _rigidbody;
    private bool _isTouchingFloor;
    private bool _faceRight;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _isTouchingFloor = true;
        _faceRight = true;
    }
    
    void Update()
    {
        Move();
        // Flip();
        float horizontal = Input.GetAxis("Horizontal") * speed; // A D
        if (horizontal > 0 && !_faceRight)
        {
            FlipV2();
        }
        if (horizontal < 0 && _faceRight)
        {
            FlipV2();
        }
        Jump();
    }

    private void Move()
    {
        float horizontal = Input.GetAxis("Horizontal") * speed; // A D
        float vertical = Input.GetAxis("Vertical") * speed; // W S
        vertical *= Time.deltaTime;
        horizontal *= Time.deltaTime;
        // transform.Translate(horizontal, vertical, 0);
        transform.Translate(horizontal, vertical, 0, Space.World);
       // _rigidbody.velocity = new Vector3(horizontal, _rigidbody.velocity.y, vertical);
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && _isTouchingFloor)
        {
            _rigidbody.AddForce(Vector3.up * jump, ForceMode.Impulse);
        }
    }

    private void FlipV2()
    {
        _faceRight = !_faceRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    
    /// <summary>
    /// Flips player when it changes direction
    /// </summary>
    private void Flip()
    {
        // if true, player is moving
        /*if (HasHorizontalSpeed(_rigidBody2D))
        {
            // changes x axis scale but keeps y axis scale as it is
            transform.localScale = new Vector2(Mathf.Sign(_rigidBody2D.velocity.x), 1f);
        }*/
        // TODO refactor
        // player is moving
        if (Mathf.Abs(_rigidbody.velocity.x) > Mathf.Epsilon)
        {
            // is player facing right?
            if (_rigidbody.velocity.x > Mathf.Epsilon && _faceRight)
            {
                // player is facing right and moving on right side
                // so do nothing
            } else if (_rigidbody.velocity.x > Mathf.Epsilon && !_faceRight)
            {
                // player is not facing right but moving on right side
                // so flip player
                _faceRight = true;
                transform.Rotate(0f, 180f, 0f);
            } else if (_rigidbody.velocity.x < Mathf.Epsilon && !_faceRight)
            {
                // player is facing left and moving on left side
                // so do nothing
            }
            else if (_rigidbody.velocity.x < Mathf.Epsilon && _faceRight)
            {
                // player is not facing left but moving on left side
                // so flip player
                _faceRight = false;
                transform.Rotate(0f, 180f, 0f);
            }
        }
    }

    private bool HasHorizontalSpeed(Rigidbody2D theRigidbody2D)
    {
        return Mathf.Abs(theRigidbody2D.velocity.x) > Mathf.Epsilon;
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            _isTouchingFloor = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            _isTouchingFloor = false;
        }
    }
}
