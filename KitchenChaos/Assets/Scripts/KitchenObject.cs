using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField] private KitchenObjectSO _kitchenObjectSO;
    [SerializeField] private IKitchenObjectParent _kitchenObjectParent;

    public KitchenObjectSO GetKitchenObject()
    {
        return _kitchenObjectSO;
    }

    public IKitchenObjectParent GetCurrentCounter()
    {
        return _kitchenObjectParent;
    }

    public void SetKitchenObjectParent(IKitchenObjectParent kitchenObjectParent)
    {
        if (_kitchenObjectParent != null)
        {
            _kitchenObjectParent.ClearKitchenObject();
        }

        if (kitchenObjectParent.HasKitchenObject())
        {
            Debug.LogError("Counter already as food on it !");
        }

        this._kitchenObjectParent = kitchenObjectParent;

        kitchenObjectParent.SetKitchenObject(this);

        transform.parent = kitchenObjectParent.GetCounterTopPoint();
        
        transform.localPosition = Vector3.zero;
    }
}
