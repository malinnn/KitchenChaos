using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoaderCallback : MonoBehaviour
{
    #region FIELDS
    private bool _isFirstUpdate = true;
    #endregion

    #region FUNCTIONS
    void Update()
    {
        if (_isFirstUpdate)
        {
            _isFirstUpdate = false;
            Loader.LoaderCallback();
        }
    }
    #endregion
}
