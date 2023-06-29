using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenGameManager : MonoBehaviour
{
    #region FIELDS
    public static KitchenGameManager Instance { get; private set; }

    public event EventHandler OnStateChanged;
    public event EventHandler OnGamePaused;
    public event EventHandler OnGameUnpaused;
    
    public enum State
    {
        Tutorial,
        WaitingToStart,
        CountdownToStart,
        GamePlaying,
        GameOver,
    }

    private State _state;

    [SerializeField] 
    private float _gamePlayingTimerMax = 10f;
    private float _gamePlayingTimer;
    private float _waitingToStartTimer = 1f;
    private float _countdownToStartTimer = 3f;

    private bool _isGamePaused = false;

    #endregion

    #region SUBSCRIPTIONS
    private void Awake()
    {
        Instance = this;

        if (TutorialUI.Instance.GetDontShowTutorialBool() == false)
        {
            _state = State.Tutorial;
        }
        
        else
        {
            _state = State.WaitingToStart;
        }

        //_state = State.WaitingToStart;
        //State is set after Interact is first used, in order to close the tutorial
    }

    private void Start()
    {
        GameInput.Instance.OnPauseAction += GameInput_OnPauseAction;
    }

    private void OnDestroy()
    {
        GameInput.Instance.OnPauseAction -= GameInput_OnPauseAction;
    }

    private void GameInput_OnPauseAction(object sender, EventArgs e)
    {
        TogglePauseGame();
    }
    #endregion

    #region FUNCTIONS
    private void Update()
    {
        switch (_state)
        {
            case State.Tutorial:
                return;
            case State.WaitingToStart:
                _waitingToStartTimer -= Time.deltaTime;
                if (_waitingToStartTimer < 0f)
                {
                    _state = State.CountdownToStart;
                    OnStateChanged?.Invoke(this, EventArgs.Empty);
                }
                break;
            case State.CountdownToStart:
                _countdownToStartTimer -= Time.deltaTime;
                if (_countdownToStartTimer < 0f)
                {
                    _state = State.GamePlaying;
                    _gamePlayingTimer = _gamePlayingTimerMax;
                    OnStateChanged?.Invoke(this, EventArgs.Empty);
                }
                break;
            case State.GamePlaying:
                _gamePlayingTimer -= Time.deltaTime;
                if (_gamePlayingTimer < 0f)
                {
                    _state = State.GameOver;
                    OnStateChanged?.Invoke(this, EventArgs.Empty);
                }
                break;
            case State.GameOver:
                break;
        }
        //Debug.Log(_state);
    }

    public bool IsTutorial()
    {
        return _state == State.Tutorial;
    }

    public bool IsGamePlaying()
    {
        return _state == State.GamePlaying;
    }

    public bool IsGameOver()
    {
        return _state == State.GameOver;
    }

    public bool IsCountdownToStartActive()
    {
        return _state == State.CountdownToStart;
    }

    public float GetCountdownToStartTimer()
    {
        return _countdownToStartTimer;
    }

    public float GetPlayingTimerNormalized()
    {
        return (1 - (_gamePlayingTimer / _gamePlayingTimerMax));
    }

    public void TogglePauseGame()
    {
        _isGamePaused = !_isGamePaused;

        if (_isGamePaused)
        {
            Time.timeScale = 0f;

            OnGamePaused?.Invoke(this, EventArgs.Empty);

            Debug.Log("Game Paused !");
        }
        else
        {
            Time.timeScale = 1f;

            OnGameUnpaused?.Invoke(this, EventArgs.Empty);

            Debug.Log("Game Resumed !");
        }
    }

    public void SetState(State state)
    {
        _state = state;
    }

    #endregion
}
