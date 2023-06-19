using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatesCounter : BaseCounter
{
    public event EventHandler OnPlateSpawned;
    public event EventHandler OnPlateRemoved;

    [SerializeField] private KitchenObjectSO _plateKitchenObjectSO;

    private float _spawnPlateTimer;
    private float _spawnPlateTimerMax = 4f;
    private int _stackedPlates;
    private int _stackedPlatesMax = 5;

    private void Update()
    {
        _spawnPlateTimer += Time.deltaTime;

        if (_spawnPlateTimer > _spawnPlateTimerMax && _stackedPlates < _stackedPlatesMax)
        {
            _spawnPlateTimer = 0f;
            _stackedPlates++;
            OnPlateSpawned?.Invoke(this, EventArgs.Empty);
        }
    }

    public override void Interact(Player player)
    {
        if (player.HasKitchenObject() == false)
        {
            if (_stackedPlates > 0)
            {
                KitchenObject.SpawnKitchenObject(_plateKitchenObjectSO, player);
                _stackedPlates--;
                OnPlateRemoved?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
