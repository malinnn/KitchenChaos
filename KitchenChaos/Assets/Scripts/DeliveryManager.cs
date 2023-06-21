using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class DeliveryManager : MonoBehaviour
{
    public event EventHandler OnRecipeSpawned;
    public event EventHandler OnRecipeCompleted;

    public static DeliveryManager Instance { get; private set; }

    [SerializeField] private RecipeListSO _recipeSOList;
    private List<RecipeSO> _waitingRecipeSOList;

    private float _spawnRecipeTimer;
    private float _spawnRecipeTimerMax = 4f;
    private int waitingRecipeMax = 4;

    private void Awake()
    {
        Instance = this;

        _waitingRecipeSOList = new List<RecipeSO>();
    }

    private void Update()
    {
        _spawnRecipeTimer -= Time.deltaTime;

        if (_spawnRecipeTimer <= 0f)
        {
            _spawnRecipeTimer = _spawnRecipeTimerMax;

            if (_waitingRecipeSOList.Count < waitingRecipeMax)
            {
                RecipeSO waitingRecipe = _recipeSOList.recipeSOList[UnityEngine.Random.Range(0, _recipeSOList.recipeSOList.Count)];

                _waitingRecipeSOList.Add(waitingRecipe);

                OnRecipeSpawned?.Invoke(this, EventArgs.Empty);
            }
        }
    }

    public void DeliverRecipe(PlateKitchenObject plateKitchenObject)
    {
        for (int i=0;i<_waitingRecipeSOList.Count;i++)
        {
            RecipeSO waitingRecipeSO = _waitingRecipeSOList[i];

            if (waitingRecipeSO.kitchenObjectSOList.Count == plateKitchenObject.GetKitchenObjectSOList().Count)
            {
                //Has the same number of ingredients

                bool plateContentsMatchesRecipe = true;

                foreach (KitchenObjectSO recipeKitchenObjectSO in waitingRecipeSO.kitchenObjectSOList)
                {
                    //Cycling through all ingredients in the recipe

                    bool ingredientFound = false;

                    foreach (KitchenObjectSO plateKitchenObjectSO in plateKitchenObject.GetKitchenObjectSOList())
                    {
                        //Cycling through all ingredients on the Plate
                        if (plateKitchenObjectSO == recipeKitchenObjectSO)
                        {
                            //Ingredients match !
                            ingredientFound = true;
                            break;
                        }
                    }

                    if (!ingredientFound)
                    {
                        //Ingredient not found on the Plate
                        plateContentsMatchesRecipe = false;
                    }
                }

                if (plateContentsMatchesRecipe)
                {
                    //Player delivered the correct recipe
                    Debug.Log("Player delivered the correct recipe : " + waitingRecipeSO.recipeName);
                    _waitingRecipeSOList.RemoveAt(i);

                    OnRecipeCompleted?.Invoke(this, EventArgs.Empty);

                    return;
                }
            }
        }
        //No matches found, player did not deliver a correct recipe !
        Debug.Log("Player did not deliver a correct recipe !");
    }

    public List<RecipeSO> GetWaitingRecipeSOList()
    {
        return _waitingRecipeSOList;
    }

    /*public void DeliverRecipe(PlateKitchenObject plateKitchenObject)
    {
        for (int i=0;i<_waitingRecipeSOList.Count;i++)
        {
            RecipeSO waitingRecipeSO = _waitingRecipeSOList[i];
            
            bool recipeOk = true;

            if (plateKitchenObject.GetKitchenObjectSOList().Count == waitingRecipeSO.kitchenObjectSOList.Count)
            {

                foreach (var ingredient in plateKitchenObject.GetKitchenObjectSOList())
                {
                    if (!waitingRecipeSO.kitchenObjectSOList.Contains(ingredient))
                    {
                        recipeOk = false;
                        break;
                    }
                }
            }

            if (recipeOk)
            {
                Debug.Log("Player served the correct recipe : " + waitingRecipeSO.recipeName);
                _waitingRecipeSOList.RemoveAt(i);
                return;
            }
            Debug.Log("Player did not serve the correct recipe : " + waitingRecipeSO.recipeName);
        }

    }*/
}
