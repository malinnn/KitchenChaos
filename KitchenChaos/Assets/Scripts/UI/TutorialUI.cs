using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class TutorialUI : MonoBehaviour
{
    #region FIELDS
    public static TutorialUI Instance { get; private set; }

    private bool _dontShowTutorial = false;

    private const string SHOULD_SHOW_TUTORIAL = "ShouldShowTutorial";

    [Header("Buttons")]
    [SerializeField] private Button _moveUpButton;
    [SerializeField] private Button _moveDownButton;
    [SerializeField] private Button _moveLeftButton;
    [SerializeField] private Button _moveRightButton;
    [SerializeField] private Button _interactButton;
    [SerializeField] private Button _interactAlternateButton;
    [SerializeField] private Button _pauseButton;

    [Header("Buttons Text")]
    [SerializeField] private TextMeshProUGUI _moveUpText;
    [SerializeField] private TextMeshProUGUI _moveDownText;
    [SerializeField] private TextMeshProUGUI _moveLeftText;
    [SerializeField] private TextMeshProUGUI _moveRightText;
    [SerializeField] private TextMeshProUGUI _interactText;
    [SerializeField] private TextMeshProUGUI _interactAlternateText;
    [SerializeField] private TextMeshProUGUI _pauseText;

    [Header("Toggle")]
    [SerializeField] private Toggle _dontShowTutorialToggle;

    #endregion

    #region SUBSCRIPTIONS

    private void Awake()
    {
        Instance = this;

        //For testing, in order to show the TutorialUI, set bool to == 0, not 1
        //if 1 -> true, if 0 -> false

        _dontShowTutorial = PlayerPrefs.GetInt(SHOULD_SHOW_TUTORIAL) == 1; 
        Debug.Log("DontShowTutorial : " + _dontShowTutorial);

        if (_dontShowTutorial == true)
        {
            HideTutorial();
        }
        else
        {
            ShowTutorial();
        }
    }

    private void Start()
    {
        if (_dontShowTutorial == false)
        {
            GameInput.Instance.OnInteractAction += GameInput_OnInteractAction;
        }

        _dontShowTutorialToggle.isOn = false;
        _dontShowTutorialToggle.onValueChanged.AddListener(OnToggleValueChanged);

        UpdateButtonVisual();
    }

    private void OnDestroy()
    {
        if (_dontShowTutorial == true)
        {
            GameInput.Instance.OnInteractAction -= GameInput_OnInteractAction;
        }
    }

    private void OnToggleValueChanged(bool value)
    {
        if (value)
        {
            _dontShowTutorial = true;
            SaveShouldShowTutorialBool();
            Debug.Log("DontShowTutorialToggle is ON !");
        }
        else
        {
            _dontShowTutorial = false;
            SaveShouldShowTutorialBool();
            Debug.Log("DontShowTutorialToggle is OFF !");
        }
    }

    private void GameInput_OnInteractAction(object sender, EventArgs e)
    {
        HideTutorial();

        if (KitchenGameManager.Instance.IsTutorial())
        {
            KitchenGameManager.Instance.SetState(KitchenGameManager.State.WaitingToStart);
        }
    }

    #endregion

    #region FUNCTIONS

    private void SaveShouldShowTutorialBool()
    {
        PlayerPrefs.SetInt(SHOULD_SHOW_TUTORIAL, _dontShowTutorial ? 1 : 0);
        PlayerPrefs.Save();
    }

    public void ShowTutorial()
    {
        gameObject.SetActive(true);
    }

    public void HideTutorial()
    {
        gameObject.SetActive(false);
    }

    public void UpdateButtonVisual()
    {
        _moveUpText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Move_Up);
        _moveDownText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Move_Down);
        _moveLeftText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Move_Left);
        _moveRightText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Move_Right);
        _interactText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Interact);
        _interactAlternateText.text = GameInput.Instance.GetBindingText(GameInput.Binding.InteractAlternate);
        _pauseText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Pause);
    }

    public bool GetDontShowTutorialBool()
    {
        return _dontShowTutorial;
    }

    #endregion
}
