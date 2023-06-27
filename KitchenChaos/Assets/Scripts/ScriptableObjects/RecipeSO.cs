using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class RecipeSO : ScriptableObject
{
    #region FIELDS
    public List<KitchenObjectSO> kitchenObjectSOList;
    public string recipeName;
    #endregion
}
