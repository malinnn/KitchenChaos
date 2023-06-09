using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameInput _gameInput;
    [SerializeField] private float _moveSpeed = 7f;
    [SerializeField] private float _rotateSpeed = 10f;

    private bool isWalking;

    private void Update()
    {
        Vector2 inputVector = _gameInput.GetInput();
        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);

        isWalking = moveDir != Vector3.zero;

        transform.position += moveDir * _moveSpeed * Time.deltaTime;

        if (isWalking)
        {
            transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * _rotateSpeed);
        }
    }

    public bool IsWalking()
    {
        return isWalking;
    }
}
