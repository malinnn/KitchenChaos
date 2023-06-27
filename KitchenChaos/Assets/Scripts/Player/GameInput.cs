using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameInput : MonoBehaviour
{
    #region FIELDS
    public static GameInput Instance { get; private set; }

    public EventHandler OnInteractAction;
    public EventHandler OnInteractAlternateAction;
    public EventHandler OnPauseAction;
    private PlayerInputActions _inputActions;
    #endregion

    #region SUBSCRIPTIONS
    private void Awake()
    {
        Instance = this;

        _inputActions = new PlayerInputActions();
        _inputActions.Character.Enable();

        _inputActions.Character.Interact.performed += Interact_Performed;
        _inputActions.Character.InteractAlternate.performed += InteractAlternate_performed;
        _inputActions.Character.Pause.performed += Pause_performed;
    }

    private void OnDestroy()
    {
        _inputActions.Character.Interact.performed -= Interact_Performed;
        _inputActions.Character.InteractAlternate.performed -= InteractAlternate_performed;
        _inputActions.Character.Pause.performed -= Pause_performed;

        _inputActions.Dispose();
    }

    private void Pause_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnPauseAction?.Invoke(this, EventArgs.Empty);
    }

    private void InteractAlternate_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnInteractAlternateAction?.Invoke(this, EventArgs.Empty);
    }

    private void Interact_Performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnInteractAction?.Invoke(this, EventArgs.Empty);
    }
    #endregion

    #region FUNCTIONS
    public Vector2 GetInput()
    {
        Vector2 inputVector = _inputActions.Character.Move.ReadValue<Vector2>();

        inputVector = inputVector.normalized; //fixes the higher diagonal speed

        return inputVector;
    }
    #endregion
}
