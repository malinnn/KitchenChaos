using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }


    public event EventHandler<OnSelectedCounterChangedEventArgs>OnSelectedCounterChanged;
    public class OnSelectedCounterChangedEventArgs : EventArgs
    {
        public ClearCounter selectedCounter;
    }


    [SerializeField] private GameInput _gameInput;
    [SerializeField] private LayerMask _countersLayerMask;

    [SerializeField] private float _moveSpeed = 7f;
    [SerializeField] private float _rotateSpeed = 10f;
    [SerializeField] private float _playerWidth = 1f;
    [SerializeField] private float _playerHeight = 1f;

    private bool isWalking;
    private Vector3 lastInteractDir;
    private ClearCounter _selectedCounter;


    private void Awake()
    {
        if(Instance != null)
        {
            Debug.LogError("Instace was already set !");
        }
        Instance = this;
    }

    private void Start()
    {
        _gameInput.OnInteractAction += GameInput_OnInteractAction;
    }

    private void GameInput_OnInteractAction(object sender, System.EventArgs e)
    {
        if(_selectedCounter != null)
        {
            _selectedCounter.Interact();
        }

        /*Vector2 inputVector = _gameInput.GetInput();
        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);

        if (moveDir != Vector3.zero)
        {
            lastInteractDir = moveDir;
        }

        float interactDistance = 2f;

        if (Physics.Raycast(transform.position, moveDir, out RaycastHit raycastHit, interactDistance, _countersLayerMask))
        {
            //Debug.Log(raycastHit.transform);
            if (raycastHit.transform.TryGetComponent(out ClearCounter clearCounter))
            {
                //Has ClearCounter
                clearCounter.Interact();
            }
        }*/
    }

    private void Update()
    {
        HandleMovement();
        HandleInteractions();
    }

    public bool IsWalking()
    {
        return isWalking;
    }

    public void HandleInteractions()
    {
        Vector2 inputVector = _gameInput.GetInput();
        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);

        if(moveDir != Vector3.zero )
        {
            lastInteractDir = moveDir;
        }

        float interactDistance = 2f;

        if (Physics.Raycast(transform.position, moveDir, out RaycastHit raycastHit, interactDistance, _countersLayerMask))
        {
            //Debug.Log(raycastHit.transform);
            if (raycastHit.transform.TryGetComponent(out ClearCounter clearCounter))
            {
                //Has ClearCounter
                if (clearCounter != _selectedCounter)
                {
                    _selectedCounter = clearCounter;
                    ChangeSelectedCounter(clearCounter);
                }
                else
                {
                    ChangeSelectedCounter(null);
                }
                //clearCounter.Interact();
            }
            else
            {
                ChangeSelectedCounter(null);
            }
        }
        Debug.Log(_selectedCounter);
    }

    private void HandleMovement()
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

    public void ChangeSelectedCounter(ClearCounter clearCounter)
    {
        _selectedCounter = clearCounter;
        OnSelectedCounterChanged?.Invoke(this, new OnSelectedCounterChangedEventArgs
        {
            selectedCounter = _selectedCounter
        });
    }
}
