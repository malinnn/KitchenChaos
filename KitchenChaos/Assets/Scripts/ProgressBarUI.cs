using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarUI : MonoBehaviour
{
    [SerializeField] private CuttingCounter _cuttingCounter;
    [SerializeField] private Image _barImage;
    [SerializeField] private Transform _uiHolder;

    private void Start()
    {
        _cuttingCounter.OnProgressChanged += CuttingCounter_OnProgressChanged;
        Hide();
    }

    private void CuttingCounter_OnProgressChanged(object sender, CuttingCounter.OnProgressChangedEventArgs e)
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

    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
