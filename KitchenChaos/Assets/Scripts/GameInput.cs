using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    private PlayerInputActions _inputActions;
    private void Awake()
    {
        _inputActions = new PlayerInputActions();
        _inputActions.Player.Enable();
    }

    public Vector2 GetInput()
    {
        Vector2 inputVector = _inputActions.Player.Move.ReadValue<Vector2>();

       /* if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            inputVector.y = +1;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            inputVector.x = -1;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            inputVector.y = -1;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            inputVector.x = +1;
        }*/

        inputVector = inputVector.normalized; //fixes the higher diagonal speed

        return inputVector;
    }
}
