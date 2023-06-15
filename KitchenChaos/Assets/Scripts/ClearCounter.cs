using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : BaseCounter
{
    [SerializeField] private KitchenObjectSO _kitchenObjectSO;

    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {
            //No KitchenObject
            if (player.HasKitchenObject())
            {
                player.GetKitchenObject().SetKitchenObjectParent(this);
            }
        }
        else
        {
            //There is KitchenObject
            if (player.HasKitchenObject())
            {
                //Player is carrying smth
                Debug.LogWarning("Player is already carrying something !");
            }
            else
            {
                //Player is not carrying smth
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }
}
