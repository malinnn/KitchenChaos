using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ContainerCounter : BaseCounter
{
    public event EventHandler OnPlayerGrabbedObject;

    [SerializeField] private KitchenObjectSO _kitchenObjectSO;

    public override void Interact(Player player)
    {
        if (player.HasKitchenObject()) return;

        KitchenObject.SpawnKitchenObject(_kitchenObjectSO, player);
        OnPlayerGrabbedObject?.Invoke(this, EventArgs.Empty);

        /*if (!HasKitchenObject())
        {
            //if (player.HasKitchenObject()) return;
            GameObject kitchenObjectTransform = Instantiate(_kitchenObjectSO.prefab);
            kitchenObjectTransform.GetComponent<KitchenObject>().SetKitchenObjectParent(player);
        }
        else
        {
            _kitchenObject.SetKitchenObjectParent(player);
        }*/
    }
}
