using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarUI : MonoBehaviour
{
    #region FIELDS
    [SerializeField] private GameObject _hasProgressGameObject;
    [SerializeField] private Image _barImage;
    [SerializeField] private Transform _uiHolder;

    private IHasProgress _hasProgress;
    #endregion

    #region SUBSCRIPTIONS
    private void Start()
    {
        _hasProgress = _hasProgressGameObject.GetComponent<IHasProgress>();

        if (_hasProgress == null)
        {
            Debug.LogError("GameObject " + _hasProgressGameObject + "does not have a component that implements IHasProgress !");
        }

        _hasProgress.OnProgressChanged += HasProgress_OnProgressChanged;
        _barImage.fillAmount = 0f;
        Hide();
    }

    private void OnDestroy()
    {
        _hasProgress.OnProgressChanged -= HasProgress_OnProgressChanged;
    }

    private void HasProgress_OnProgressChanged(object sender, IHasProgress.OnProgressChangedEventArgs e)
    {
        _uiHolder.gameObject.SetActive(true);
        float progress = e.progressNormalized;
        _barImage.fillAmount = progress;

        if(progress == 0 || progress == 1)
        {
            Hide();
        }
        else
        {
            Show();
        }
    }
    #endregion

    #region FUNCTIONS
    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
    #endregion
}
