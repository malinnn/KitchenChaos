using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ContainerCounter : BaseCounter
{
    #region FIELDS
    public event EventHandler OnPlayerGrabbedObject;

    [SerializeField] private KitchenObjectSO _kitchenObjectSO;
    #endregion

    #region FUNCTIONS
    public override void Interact(Player player)
    {
        if (player.HasKitchenObject()) return;

        KitchenObject.SpawnKitchenObject(_kitchenObjectSO, player);
        OnPlayerGrabbedObject?.Invoke(this, EventArgs.Empty);
    }
    #endregion
}
