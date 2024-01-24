using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [SerializeField] private PlayerInputActions playerInput;

    private void Awake()
    {
        playerInput = new PlayerInputActions();

        playerInput.Player.Enable();
        playerInput.Player.Fire.performed += Fire;
    }

    private void Fire(InputAction.CallbackContext obj)
    {
        GunController.instance.Fire();
    }

    private void MovePlayer(Vector2 input)
    {
        PlayerController.instance.Move(input);
    }
    private void Update()
    {
        //if (StatesBool.IsLose()) return;

        Vector2 input = playerInput.Player.Move.ReadValue<Vector2>();

        MovePlayer(input);
    }
}
