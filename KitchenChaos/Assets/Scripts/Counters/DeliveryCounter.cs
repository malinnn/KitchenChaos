using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryCounter : BaseCounter
{
    #region FIELDS
    public static DeliveryCounter Instance { get; private set; }
    #endregion

    #region FUNCTIONS
    private void Awake()
    {
        Instance = this;
    }

    public override void Interact(Player player)
    {
        if (player.HasKitchenObject() && player.GetKitchenObject().TryGetPlate(out PlateKitchenObject plateKitchenObject))
        {
            KitchenObject kitchenObject = player.GetKitchenObject();
            kitchenObject.SetKitchenObjectParent(this);

            DeliveryManager.Instance.DeliverRecipe(plateKitchenObject);

            kitchenObject.DestroySelf();
        }
    }
    #endregion
}
