using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounterVisual : MonoBehaviour
{
    #region FIELDS
    [SerializeField] private CuttingCounter _cuttingCounter;
    private Animator _animator;
    private const string CUT = "Cut";
    #endregion

    #region SUBSCRIPTIONS
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        _cuttingCounter.OnProgressChanged += ContainerCounter_OnPlayerGrabbedObject;
        _cuttingCounter.OnCut += CuttingCounter_OnCut;
    }

    private void OnDestroy()
    {
        _cuttingCounter.OnProgressChanged -= ContainerCounter_OnPlayerGrabbedObject;
        _cuttingCounter.OnCut -= CuttingCounter_OnCut;
    }

    private void CuttingCounter_OnCut(object sender, EventArgs e)
    {
        _animator.SetTrigger(CUT);
    }

    private void ContainerCounter_OnPlayerGrabbedObject(object sender, EventArgs e)
    {
        _animator.SetTrigger(CUT);
    }
    #endregion
}
