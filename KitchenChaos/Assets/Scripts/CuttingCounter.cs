using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounter : BaseCounter
{
    [SerializeField] private CuttingRecipeSO[] _cutRecipeSOArray;
    private int cutCount;

    public event EventHandler<OnProgressChangedEventArgs> OnProgressChanged;
    public class OnProgressChangedEventArgs : EventArgs
    {
        public float progressNormalized;
    }

    public event EventHandler OnCut;

    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {
            //No KitchenObject
            if (player.HasKitchenObject() && HasRecipeWithInput(player.GetKitchenObject().GetKitchenObjectSO()))
            {
                KitchenObject kitchenObject = player.GetKitchenObject();
                kitchenObject.SetKitchenObjectParent(this);
                cutCount = 0;

                OnProgressChanged?.Invoke(this, new OnProgressChangedEventArgs()
                {
                    progressNormalized = (float)cutCount / GetMaximumCutsNeeded(kitchenObject.GetKitchenObjectSO())
                });
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

    public override void InteractAlternate(Player player)
    {
        KitchenObjectSO currentKitchenObject = GetKitchenObject().GetKitchenObjectSO();

        if (HasKitchenObject() && HasRecipeWithInput(currentKitchenObject))
        {
            cutCount++;

            OnCut?.Invoke(this, EventArgs.Empty);

            CuttingRecipeSO cuttingRecipeSO = GetCuttingRecipeSOWithInput(GetKitchenObject().GetKitchenObjectSO());

            OnProgressChanged?.Invoke(this, new OnProgressChangedEventArgs()
            {
                progressNormalized = (float)cutCount / cuttingRecipeSO.maximumNeededCuts
            });

            if (player.HasKitchenObject() == false && cutCount >= GetMaximumCutsNeeded(currentKitchenObject))
            {
                KitchenObjectSO outputKitchenObjectSO = GetOutputForInput(currentKitchenObject);

                GetKitchenObject().DestroySelf();

                KitchenObject.SpawnKitchenObject(outputKitchenObjectSO, this);
            }
        }
    }

    private bool HasRecipeWithInput(KitchenObjectSO inputKitchenObjectSO)
    {
        foreach (CuttingRecipeSO cuttingRecipeSO in _cutRecipeSOArray)
        {
            if (cuttingRecipeSO.input == inputKitchenObjectSO)
            {
                return true;
            }
        }
        return false;
    }    

    private KitchenObjectSO GetOutputForInput(KitchenObjectSO inputKitchenObjectSO)
    {
        CuttingRecipeSO cuttingRecipeSO = GetCuttingRecipeSOWithInput(inputKitchenObjectSO);

        if (cuttingRecipeSO != null)
        {
            return cuttingRecipeSO.output;
        }
        else
        {
            return null;
        }
    }

    private CuttingRecipeSO GetCuttingRecipeSOWithInput(KitchenObjectSO inputKitchenObjectSO)
    {
        foreach (CuttingRecipeSO cuttingRecipeSO in _cutRecipeSOArray)
        {
            if (cuttingRecipeSO.input == inputKitchenObjectSO)
            {
                return cuttingRecipeSO;
            }
        }
        return null;
    }

    private int GetMaximumCutsNeeded(KitchenObjectSO inputKitchenObjectSO)
    {
        foreach (CuttingRecipeSO cuttingRecipeSO in _cutRecipeSOArray)
        {
            if (cuttingRecipeSO.input == inputKitchenObjectSO)
            {
                return cuttingRecipeSO.maximumNeededCuts;
            }
        }
        return 0;
    }
}
