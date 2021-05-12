using UnityEngine;

public class BeatEmUpMove : MonoBehaviour
{
    private CharacterController _controller;
    private Vector3 slopeNormal;
    private bool grounded;
    private float verticalVelocity;

    [Header("Configuration")] 
    [SerializeField, Range(1, 10)] private float speedX; // 5
    [SerializeField, Range(1, 10)] private float speedZ; // 5
    [SerializeField, Range(0, 10)] private float gravity; // 0.25
    [SerializeField, Range(1, 10)] private float terminalVelocity; // 5
    [SerializeField, Range(1, 10)] private float jump; // 8

    [Header("Ground Raycast Stuff")] [SerializeField]
    private float extremitiesOffset = 0.05f;

    [SerializeField,] private float innerVerticalOffset = 0.25f;
    [SerializeField] private float distanceGrounded = 0.15f;
    [SerializeField] private float slopeThreshold = 0.55f;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }

    void Start()
    {
    }


    void Update()
    {
        Vector3 inputVector = PoolInput();
        // x, y , z => esta usando y como z
        Vector3 moveVector3 = new Vector3(inputVector.x * speedX, 0, inputVector.y * speedZ);

        grounded = Grounded();
        if (grounded)
        {
            // Apply slight gravity
            verticalVelocity = -1;

            if (Input.GetButtonDown("Jump"))
            {
                verticalVelocity = jump;
                slopeNormal = Vector3.up;
            }
        }
        else
        {
            verticalVelocity -= gravity;
            slopeNormal = Vector3.up;

            if (verticalVelocity < -terminalVelocity)
            {
                verticalVelocity = -terminalVelocity;
            }
        }

        // recordar Time.deltaTime
        _controller.Move(moveVector3 * Time.deltaTime);
    }

    private Vector3 PoolInput()
    {
        Vector3 vector3 = default(Vector3);
        vector3.x = Input.GetAxisRaw("Horizontal");
        vector3.y = Input.GetAxisRaw("Vertical");
        return vector3.normalized;
    }

    private bool Grounded()
    {
        if (verticalVelocity > 0)
        {
            return false;
        }

        float yRay = (_controller.bounds.center.y - (_controller.height * 0.5f) + innerVerticalOffset);
        RaycastHit hit;
        // Mid
        if (Physics.Raycast(new Vector3(_controller.bounds.center.x, yRay, _controller.bounds.center.z), -Vector3.up,
            out hit, innerVerticalOffset + distanceGrounded))
        {
            Debug.DrawRay(new Vector3(_controller.bounds.center.x, yRay, _controller.bounds.center.z),
                -Vector3.up * (innerVerticalOffset + distanceGrounded), Color.red);
            slopeNormal = hit.normal;
            return (slopeNormal.y > slopeThreshold) ? true : false;
        }

        // Front-Right
        if (Physics.Raycast(new Vector3(
                _controller.bounds.center.x + (_controller.bounds.extents.x - extremitiesOffset), yRay,
                _controller.bounds.center.z + (_controller.bounds.extents.z - extremitiesOffset)), -Vector3.up, out hit,
            innerVerticalOffset + distanceGrounded))
        {
            Debug.DrawRay(new Vector3(_controller.bounds.center.x, yRay, _controller.bounds.center.z),
                -Vector3.up * (innerVerticalOffset + distanceGrounded));
            slopeNormal = hit.normal;
            return (slopeNormal.y > slopeThreshold) ? true : false;
        }

        // Front-left
        if (Physics.Raycast(new Vector3(
                _controller.bounds.center.x - (_controller.bounds.extents.x - extremitiesOffset), yRay,
                _controller.bounds.center.z + (_controller.bounds.extents.z - extremitiesOffset)), -Vector3.up, out hit,
            innerVerticalOffset + distanceGrounded))
        {
            Debug.DrawRay(new Vector3(_controller.bounds.center.x, yRay, _controller.bounds.center.z),
                -Vector3.up * (innerVerticalOffset + distanceGrounded));
            slopeNormal = hit.normal;
            return (slopeNormal.y > slopeThreshold) ? true : false;
        }

        // Back-right
        if (Physics.Raycast(new Vector3(
                _controller.bounds.center.x + (_controller.bounds.extents.x - extremitiesOffset), yRay,
                _controller.bounds.center.z - (_controller.bounds.extents.z - extremitiesOffset)), -Vector3.up, out hit,
            innerVerticalOffset + distanceGrounded))
        {
            slopeNormal = hit.normal;
            return (slopeNormal.y > slopeThreshold) ? true : false;
        }
        // Back-left
        if (Physics.Raycast(new Vector3(
                _controller.bounds.center.x - (_controller.bounds.extents.x - extremitiesOffset), yRay,
                _controller.bounds.center.z - (_controller.bounds.extents.z - extremitiesOffset)), -Vector3.up, out hit,
            innerVerticalOffset + distanceGrounded))
        {
            slopeNormal = hit.normal;
            return (slopeNormal.y > slopeThreshold) ? true : false;
        }

        return false;
    }
}