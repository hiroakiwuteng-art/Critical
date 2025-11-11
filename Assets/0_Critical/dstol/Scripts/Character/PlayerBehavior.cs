using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    [SerializeField] private Movement movement;
    [SerializeField] private Character character;
    [SerializeField] private CameraControl cameraControl;
    private PlayerInput playerInput;
    
    private void Awake()
    {
        playerInput = new PlayerInput();
        playerInput.Owner = character;
        cameraControl.SetDifference();
    }

    private void Start()
    {
        character.StartPosition = transform.position;
        playerInput.previousJumpHeld = false;
        movement.Stepping = false;
    }

    void Update()
    {
        playerInput.ReadMovementInput();
        playerInput.ApplyInput();
        movement.Move();
        movement.ManageJumps();
        cameraControl.FollowCharacter();
    }
}
