using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    #region FIELDS
    [SerializeField] private Player _player;

    private const string IS_WALKING = "isWalking";
    private Animator _animator;
    #endregion

    #region FUNCTIONS
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _animator.SetBool(IS_WALKING, _player.IsWalking());
    }
    #endregion
}
