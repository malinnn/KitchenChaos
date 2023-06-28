using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.UI;

public class OptionsUI : MonoBehaviour
{
    #region FIELDS
    public static OptionsUI Instance { get; private set; }

    [SerializeField] private Scrollbar _sfxScroll;
    [SerializeField] private Scrollbar _musicScroll;
    [SerializeField] private Button _cancelButton;

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

    [SerializeField] private Transform _pressToRebindKeyTranform;


    #endregion

    #region SUBSCRIPTIONS

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _sfxScroll.onValueChanged.AddListener((float valueNormalized) =>
        {
            SoundManager.Instance.ChangeVolume(valueNormalized);
        });

        _musicScroll.onValueChanged.AddListener((float valueNormalized) =>
        {
            MusicManager.Instance.ChangeVolume(valueNormalized);
        });

        _cancelButton.onClick.AddListener(() =>
        {
            Hide();
        });

        _moveUpButton.onClick.AddListener(() =>
        {
            RebindBinding(GameInput.Binding.Move_Up);
        });
        
        _moveDownButton.onClick.AddListener(() =>
        {
            RebindBinding(GameInput.Binding.Move_Down);
        });
        
        _moveLeftButton.onClick.AddListener(() =>
        {
            RebindBinding(GameInput.Binding.Move_Left);
        });
        
        _moveRightButton.onClick.AddListener(() =>
        {
            RebindBinding(GameInput.Binding.Move_Right);
        });
        
        _interactButton.onClick.AddListener(() =>
        {
            RebindBinding(GameInput.Binding.Interact);
        });
        
        _interactAlternateButton.onClick.AddListener(() =>
        {
            RebindBinding(GameInput.Binding.InteractAlternate);
        });
        
        _pauseButton.onClick.AddListener(() =>
        {
            RebindBinding(GameInput.Binding.Pause);
        });

        _sfxScroll.value = SoundManager.Instance.GetVolume();
        _musicScroll.value = MusicManager.Instance.GetVolume();

        UpdateButtonVisual();
        HidePressToRebindKey();
        Hide();
    }

    #endregion

    #region FUNCTIONS

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    private void ShowPressToRebindKey()
    {
        _pressToRebindKeyTranform.gameObject.SetActive(true);
    }

    private void HidePressToRebindKey()
    {
        _pressToRebindKeyTranform.gameObject.SetActive(false);
    }

    private void RebindBinding(GameInput.Binding binding)
    {
        ShowPressToRebindKey();
        GameInput.Instance.ResetBinding(binding, () => 
        {
            HidePressToRebindKey();
            UpdateButtonVisual();
        });
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

    #endregion
}
