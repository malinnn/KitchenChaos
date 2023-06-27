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

        _sfxScroll.value = SoundManager.Instance.GetVolume();
        _musicScroll.value = MusicManager.Instance.GetVolume();

        UpdateButtonVisual();
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
