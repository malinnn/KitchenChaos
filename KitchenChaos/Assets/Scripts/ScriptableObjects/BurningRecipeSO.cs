using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class BurningRecipeSO : ScriptableObject
{
    #region FIELDS
    public KitchenObjectSO input;
    public KitchenObjectSO output;
    public float burningTimerMax;
    #endregion
}
