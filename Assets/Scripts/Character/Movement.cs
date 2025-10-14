using UnityEngine;

public class Movement : MonoBehaviour
{
    private Vector2 lateralMovement;
    private bool jumpInput;

    [SerializeField] private Character owner;

    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;

    [SerializeField] private Rigidbody rb;

    [SerializeField] private bool grounded;
    [SerializeField] private float groundedCheckDistance;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private GameObject feet;

    [SerializeField] private bool canJump;
    [SerializeField] private int maxJumps;
    [SerializeField] private int previousJumps;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckIfGrounded();
        ManageJumps();
    }
    private void Move()
    {
        if(owner.Alive)
        {
            rb.linearVelocity = new Vector3(lateralMovement.y * speed, rb.linearVelocity.y, lateralMovement.x * speed);
            if(jumpInput)
            {
                Jump();
            }
        }
    }
    private void Jump()
    {
        if(canJump)
        {
            previousJumps++;
            rb.linearVelocity = rb.linearVelocity + Vector3.up * jumpPower;
        }
    }
    public Vector2 LateralMovement
    {
        get { return lateralMovement; }
        set { lateralMovement = value; }
    }
    private void CheckIfGrounded()
    {
        grounded = Physics.Raycast(feet.transform.position, Vector3.down, groundedCheckDistance, groundLayer);
    }
    private void ManageJumps()
    {
        if(!grounded && previousJumps == 0)
        {
            previousJumps = 1;
        }
        if(grounded)
        {
            previousJumps = 0;
        }
        if(previousJumps >= maxJumps)
        {
            canJump = false;
        }
        else
        {
            canJump = true;
        }
    }
    public bool JumpInput
    {
        get { return jumpInput; }
        set { jumpInput = value; }
    }
}
