using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    [SerializeField] private Movement movement;
    [SerializeField] private Character character;
    private PlayerInput playerInput;

    private void Awake()
    {
        playerInput = new PlayerInput();
        playerInput.Owner = character;
    }

    private void Start()
    {
        playerInput.previousJumpHeld = false;
        movement.Stepping = false;
    }

    void Update()
    {
        playerInput.ReadMovementInput();
        playerInput.ApplyInput();
        movement.Move();
    }
}
