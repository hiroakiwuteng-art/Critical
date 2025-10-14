using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] Character owner;
    [SerializeField] private Vector2 lateralInput;
    [SerializeField] private bool jumpInput;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ReadInput();
        ApplyInput();
    }
    private void ReadInput()
    {
        lateralInput = new Vector2(
            Input.GetAxisRaw("Vertical"),
            Input.GetAxisRaw("Horizontal"));
        jumpInput = Input.GetButtonDown("Jump");
    }
    private void ApplyInput()
    {
        owner.CharacterMovement.LateralMovement = lateralInput;
        owner.CharacterMovement.JumpInput = jumpInput;
    }
}
