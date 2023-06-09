using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameInput _gameInput;

    [SerializeField] private float _moveSpeed = 7f;
    [SerializeField] private float _rotateSpeed = 10f;
    [SerializeField] private float _playerWidth = 1f;
    [SerializeField] private float _playerHeight = 1f;

    private bool isWalking;

    private void Update()
    {
        Vector2 inputVector = _gameInput.GetInput();
        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);

        float moveDistance = _moveSpeed * Time.deltaTime;
        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * _playerHeight, _playerWidth, moveDir, moveDistance);

        if (!canMove)
        {
            //can't move diagonally

            Vector3 moveDirX = new Vector3(moveDir.x, 0, 0);
            canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * _playerHeight, _playerWidth, moveDirX, moveDistance);

            //can move only on x

            if (canMove)
            {
                moveDir = moveDirX;
            }
            else
            {
                //if can't move on x, try z

                Vector3 moveDirZ = new Vector3(0, 0, moveDir.z);
                canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * _playerHeight, _playerWidth, moveDirZ, moveDistance);

                //can move only on z

                if (canMove)
                {
                    moveDir = moveDirZ;
                }
            }
        }

        var step = moveDir * moveDistance;

        if (canMove)
        {
            transform.position += step;
        }

        isWalking = moveDir != Vector3.zero;

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
