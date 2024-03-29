using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatesCounterVisual : MonoBehaviour
{
    #region FIELDS
    [SerializeField] private PlatesCounter _platesCounter;
    [SerializeField] private Transform _counterTopPoint;
    [SerializeField] private Transform _plateVisualPrefab;

    private List<GameObject> _plateVisualGameObjectList;
    #endregion

    #region SUBSCRIPTIONS
    private void Awake()
    {
        _plateVisualGameObjectList = new List<GameObject>();
    }

    private void Start()
    {
        _platesCounter.OnPlateSpawned += PlatesCounter_OnPlateSpawned;
        _platesCounter.OnPlateRemoved += PlatesCounter_OnPlateRemoved;
    }

    private void OnDestroy()
    {
        _platesCounter.OnPlateSpawned -= PlatesCounter_OnPlateSpawned;
        _platesCounter.OnPlateRemoved -= PlatesCounter_OnPlateRemoved;
    }

    private void PlatesCounter_OnPlateRemoved(object sender, System.EventArgs e)
    {
        GameObject plateGameObject = _plateVisualGameObjectList[_plateVisualGameObjectList.Count - 1];
        _plateVisualGameObjectList.Remove(plateGameObject);
        Destroy(plateGameObject);
    }

    private void PlatesCounter_OnPlateSpawned(object sender, System.EventArgs e)
    {
        Transform plateVisualTranform = Instantiate(_plateVisualPrefab, _counterTopPoint);

        float plateOffsetY = 0.1f;

        plateVisualTranform.localPosition = new Vector3(0, plateOffsetY * _plateVisualGameObjectList.Count, 0);

        _plateVisualGameObjectList.Add(plateVisualTranform.gameObject);
    }
    #endregion
}
