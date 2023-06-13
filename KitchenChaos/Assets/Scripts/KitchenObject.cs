using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField] private KitchenObjectSO _kitchenObjectSO;
    [SerializeField] private ClearCounter _currentCounter;

    public KitchenObjectSO GetKitchenObject()
    {
        return _kitchenObjectSO;
    }

    public ClearCounter GetCurrentCounter()
    {
        return _currentCounter;
    }

    public void SetCurrentCounter(ClearCounter clearCounter)
    {
        if (_currentCounter != null)
        {
            _currentCounter.SetKitchenObject(null);
        }
        _currentCounter = clearCounter;
        transform.parent = clearCounter.GetCounterTopPoint();
        clearCounter.SetKitchenObject(this);
        transform.localPosition = Vector3.zero;
    }
}
