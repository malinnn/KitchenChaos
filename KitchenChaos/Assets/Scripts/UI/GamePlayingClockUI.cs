using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayingClockUI : MonoBehaviour
{
    #region FIELDS
    [SerializeField] private Image _timerImage;
    #endregion

    #region FUNCTIONS
    private void Update()
    {
        _timerImage.fillAmount = KitchenGameManager.Instance.GetPlayingTimerNormalized();
    }
    #endregion
}
