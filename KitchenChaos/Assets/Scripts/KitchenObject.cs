using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField] private KitchenObjectSO _kitchenObjectSO;

    public KitchenObjectSO GetKitchenObject()
    {
        return _kitchenObjectSO;
    }
}
