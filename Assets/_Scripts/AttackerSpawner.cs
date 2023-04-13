using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] AttackingUnitSO[] attackingUnit;
    [SerializeField] public float ResourcesIncreasedPerSecond;
    [SerializeField] private TMP_Text _ResourcesTXT;
    int attackingUnitIndex;
    int attackingUnitsCount;
    PlayerController Player;
    private bool _isAvailable;
    private float _resourcesValue;

    
     void FixedUpdate()
    {
        _ResourcesTXT.text = ((int)_resourcesValue).ToString();
        _resourcesValue += ResourcesIncreasedPerSecond * Time.fixedDeltaTime;
    }

    public void DeployUnit(int index)
    {
        if(isAvailable())
        {
            PayForUnit();
            SpawnUnitForward(index);
        }
    }


    private void SpawnUnitForward(int attackingUnitIndex) //vypusti instanci attackera
    {
        Vector3 spawnPosition = new Vector3(attackingUnit[attackingUnitIndex].GetAttackerSpawnPosition().x, 1f, 0f);
        Instantiate(attackingUnit[attackingUnitIndex].GetPrefab(), spawnPosition, Quaternion.identity);
    }

    private bool isAvailable()
    {
        if (attackingUnit[attackingUnitIndex].GetAttackerPrice() >= _resourcesValue) 
        {
            _isAvailable = true;
        }
        return _isAvailable;
        
    }

    private void PayForUnit()
    {
        _resourcesValue -= attackingUnit[attackingUnitIndex].GetAttackerPrice();
    } 



}
