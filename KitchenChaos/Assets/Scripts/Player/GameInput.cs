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

    public enum Binding
    {
        Move_Up,
        Move_Down,
        Move_Left,
        Move_Right,
        Interact,
        InteractAlternate,
        Pause,
    }

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

    public string GetBindingText(Binding binding)
    {
        switch (binding)
        {
            default:
            case Binding.Move_Up:
                return _inputActions.Character.Move.bindings[1].ToDisplayString();
            case Binding.Move_Down:
                return _inputActions.Character.Move.bindings[2].ToDisplayString();
            case Binding.Move_Left:
                return _inputActions.Character.Move.bindings[3].ToDisplayString();
            case Binding.Move_Right:
                return _inputActions.Character.Move.bindings[4].ToDisplayString();
            case Binding.Interact:
                return _inputActions.Character.Interact.bindings[0].ToDisplayString();  
            case Binding.InteractAlternate:
                return _inputActions.Character.InteractAlternate.bindings[0].ToDisplayString();
            case Binding.Pause:
                return _inputActions.Character.Pause.bindings[0].ToDisplayString();
        }
    }

    #endregion
}
