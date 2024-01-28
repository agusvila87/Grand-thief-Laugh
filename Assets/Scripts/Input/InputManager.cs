using System;
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
        playerInput.Player.Pause.performed += Pause;
    }

    private void Pause(InputAction.CallbackContext context)
    {
        UIPauseManager.instance.PauseGame();
    }

    private void Fire(InputAction.CallbackContext obj)
    {
        if (GameStateManager.currentState != GameState.Playing) return;

        PlayerController.instance.Shoot();
        GunController.instance.Fire();
    }

    private void MovePlayer(Vector2 input)
    {
        PlayerController.instance.Move(input);
    }

    private void Update()
    {
        if (GameStateManager.currentState != GameState.Playing) return;

        Vector2 input = playerInput.Player.Move.ReadValue<Vector2>();

        MovePlayer(input);
    }
}
