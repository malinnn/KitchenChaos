using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveCounterVisual : MonoBehaviour
{
    #region FIELDS

    [SerializeField] private StoveCounter _stoveCounter;
    [SerializeField] private GameObject _stoveOnGameObject;
    [SerializeField] private GameObject _particlesGameObject;
    [SerializeField] private GameObject _warningImage;

    #endregion

    #region SUBSCRIPTIONS
    private void Start()
    {
        _stoveCounter.OnStateChanged += StoveCounter_OnStateChanged;
        _stoveCounter.OnWarning += StoveCounter_OnWarning;
        _warningImage.SetActive(false);
    }

    private void StoveCounter_OnWarning(object sender, System.EventArgs e)
    {
        _warningImage.SetActive(true);
    }

    private void OnDestroy()
    {
        _stoveCounter.OnStateChanged -= StoveCounter_OnStateChanged;
        _stoveCounter.OnWarning -= StoveCounter_OnWarning;
    }

    private void StoveCounter_OnStateChanged(object sender, StoveCounter.OnStateChangedEventArgs e)
    {
        bool showVisual = e.state == StoveCounter.State.Frying || e.state == StoveCounter.State.Fried;
        _stoveOnGameObject.SetActive(showVisual);
        _particlesGameObject.SetActive(showVisual);

        if (e.state != StoveCounter.State.Fried)
        {
            _warningImage.SetActive(false);
        }
    }
    #endregion
}
