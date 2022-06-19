using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItems : MonoBehaviour
{
    [Header("Amounts")]
    public float currentWater;
    public float totalWood;
    public float totalCarrots;
    public float totalFishs;

    [Header("Limits")]
    private float _waterLimit = 50;
    private float _woodLimit = 10;
    private float _carrotLimit = 5;
    private float _fishsLimit = 10;

    public float waterLimit { get => _waterLimit; set => _waterLimit = value; }
    public float woodLimit { get => _woodLimit; set => _woodLimit = value; }
    public float carrotLimit { get => _carrotLimit; set => _carrotLimit = value; }
    public float fishsLimit { get => _fishsLimit; set => _fishsLimit = value; }

    public void WaterLimit(float water)
    {
        if (currentWater < _waterLimit)
        {
            currentWater += water;
        }
        else
        {
            currentWater = _waterLimit;
        }

        currentWater += water;
    }

    private void WoodLimit(float wood)
    {
        if (totalWood < _woodLimit)
        {
            totalWood += wood;
        }
        else
        {
            totalWood = _woodLimit;
        }

        totalWood += wood;
    }

    private void CarrotsLimit(float carrots)
    {
        if (totalCarrots < _carrotLimit)
        {
            totalCarrots += carrots;
        }
        else
        {
            totalCarrots = _carrotLimit;
        }

        totalCarrots += carrots;
    }

    public void FishsLimit(float fishs)
    {
        if (totalFishs < _fishsLimit)
        {
            totalFishs += fishs;
        }
        else
        {
            totalFishs = _fishsLimit;
        }

        totalFishs += fishs;
    }
}
