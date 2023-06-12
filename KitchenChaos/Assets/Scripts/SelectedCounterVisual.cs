using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedCounterVisual : MonoBehaviour
{
    [SerializeField] private GameObject _selectedVisual;
    [SerializeField] private ClearCounter _currentCounter;


    private void Start()
    {
        Player.Instance.OnSelectedCounterChanged += SelectedCounterChanged;
    }

    private void SelectedCounterChanged(object sender, Player.OnSelectedCounterChangedEventArgs e)
    {
        if(e.selectedCounter == _currentCounter)
        {
            Show();
            //_selectedVisual.SetActive(e.selectedCounter == _currentCounter);
        }
        else
        {
            Hide();
        }
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
