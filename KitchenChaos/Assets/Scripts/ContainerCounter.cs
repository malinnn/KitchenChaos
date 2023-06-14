using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounter : BaseCounter, IKitchenObjectParent
{
    [SerializeField] private KitchenObjectSO _kitchenObjectSO;
    [SerializeField] private GameObject _counterTopPoint;
    [SerializeField] private KitchenObject _kitchenObject;

    public void Interact(Player player)
    {
        if (_kitchenObject == null)
        {
            if (player.HasKitchenObject()) return;

            GameObject kitchenObjectTransform = Instantiate(_kitchenObjectSO.prefab, _counterTopPoint.transform);
            kitchenObjectTransform.GetComponent<KitchenObject>().SetKitchenObjectParent(player);
        }
    }

    public Transform GetCounterTopPoint()
    {
        return _counterTopPoint.transform;
    }

    public KitchenObject GetKitchenObject()
    {
        return _kitchenObject;
    }

    public void SetKitchenObject(KitchenObject kitchenObject)
    {
        this._kitchenObject = kitchenObject;
    }

    public void ClearKitchenObject()
    {
        _kitchenObject = null;
    }

    public bool HasKitchenObject()
    {
        return _kitchenObject != null;
    }
}
