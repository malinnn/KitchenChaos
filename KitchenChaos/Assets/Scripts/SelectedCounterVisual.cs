using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedCounterVisual : MonoBehaviour
{
    [SerializeField] private GameObject _selectedVisual;
    [SerializeField] private ClearCounter _currentCounter;


    private void Start()
    {
        Player.Instance.OnSelectedCounterChanged += Player_OnSelectedCounterChanged;
    }

    private void Player_OnSelectedCounterChanged(object sender, Player.OnSelectedCounterChangedEventArgs e)
    {
        /*if(e.selectedCounter == _currentCounter)
        {
            Show();
        }
        else
        {
            Hide();
        }*/
        _selectedVisual.SetActive(e.selectedCounter == _currentCounter);
    }

    private void Show()
    {
        _selectedVisual.SetActive(true);
    }

    private void Hide()
    {
        _selectedVisual.SetActive(false);
    }
}
