using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class DeliveryManager : MonoBehaviour
{
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
                RecipeSO waitingRecipe = _recipeSOList.recipeSOList[Random.Range(0, _recipeSOList.recipeSOList.Count)];
                _waitingRecipeSOList.Add(waitingRecipe);

                Debug.Log("Generated recipe : " + waitingRecipe.recipeName);
            }
        }
    }

    public void DeliverRecipe(PlateKitchenObject plateKitchenObject)
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

    }
}
