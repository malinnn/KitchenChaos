using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    #region FUNCTIONS
    private void LateUpdate()
    {
        transform.forward = Camera.main.transform.forward;
    }
    #endregion
}
