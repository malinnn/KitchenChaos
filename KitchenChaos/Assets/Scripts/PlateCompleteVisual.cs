using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlateCompleteVisual : MonoBehaviour
{
    [Serializable]
    public struct KitchenObjectSO_GameObject
    {
        public KitchenObjectSO kitchenObjectSO;
        public GameObject gameObject;
    }


    [SerializeField] private GameObject _plateCompleteVisual;
    [SerializeField] private PlateKitchenObject _plateKitchenObject;

    public List<KitchenObjectSO_GameObject> kitchenObjectSOGameObjectList;
    

    private void Start()
    {
        _plateKitchenObject.OnIngredientAdded += PlateKitchenObject_OnIngredientAdded;

        foreach(var burgerObject in kitchenObjectSOGameObjectList)
        {
            burgerObject.gameObject.SetActive(false);
        }
    }

    private void PlateKitchenObject_OnIngredientAdded(object sender, PlateKitchenObject.OnIngredientAddedEventArgs e)
    {
        foreach (var burgerObject in kitchenObjectSOGameObjectList)
        {
            if (e.kitchenObjectSO == burgerObject.kitchenObjectSO)
            {
                burgerObject.gameObject.SetActive(true);
            }
        }
    }
}
