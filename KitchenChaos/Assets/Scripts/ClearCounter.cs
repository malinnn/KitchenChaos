using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : MonoBehaviour
{
    [SerializeField] private KitchenObjectSO _kitchenObject;
    [SerializeField] private GameObject _counterTopPoint;

    public void Interact()
    {
        Debug.Log("Interacted with : " + transform.gameObject.name);
        Transform kitchenObjectTransform = Instantiate(_kitchenObject.prefab, _counterTopPoint.transform).transform;
        kitchenObjectTransform.localPosition = Vector3.zero;

        Debug.Log(kitchenObjectTransform.GetComponent<KitchenObject>().GetKitchenObject());
    }
}
