using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : MonoBehaviour
{
    [SerializeField] private KitchenObjectSO _kitchenObjectSO;
    [SerializeField] private GameObject _counterTopPoint;
    [SerializeField] private KitchenObject _kitchenObject;

    public bool testing;
    public ClearCounter secondCounter;

    private void Update()
    {
        if (testing && Input.GetKeyDown(KeyCode.T))
        {
            if(_kitchenObject != null)
            {
                _kitchenObject.SetCurrentCounter(secondCounter);
            }
        }
    }

    public void Interact()
    {
        if (_kitchenObject == null)
        {
            GameObject kitchenObjectTransform = Instantiate(_kitchenObjectSO.prefab, _counterTopPoint.transform);
            kitchenObjectTransform.transform.localPosition = Vector3.zero;

            _kitchenObject = kitchenObjectTransform.GetComponent<KitchenObject>();
            _kitchenObject.SetCurrentCounter(this);
        }
        else
        {
            Debug.Log("Food already on : " + _kitchenObject.GetCurrentCounter());
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
}
