using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class UnitSpawner : MonoBehaviour
{
    [SerializeField] AttackingUnitSO[] attackingUnit;
    [SerializeField] public float ResourcesIncreasedPerSecond;
    [SerializeField] private TMP_Text _ResourcesTXT;
    [SerializeField] private TMP_Text _NotEnoughResourcesTXT;
    [SerializeField] Crystal _crystal;
    int attackingUnitIndex;
    private float _resourcesValue;
    
    private void Start() 
    {
        _NotEnoughResourcesTXT.enabled = false;
    }

    void FixedUpdate()
    {
        _ResourcesTXT.text = ((int)_resourcesValue).ToString();
        _resourcesValue += ResourcesIncreasedPerSecond * Time.fixedDeltaTime;
    }

    public void DeployUnit(int index) //immedietly deploy unit at spawnpoint if enough resources
    {
        if (HasEnoughResources(index))
        {
            PayForUnit(index);
            SpawnUnit(index);
        }
    }

    private void SpawnUnit(int attackingUnitIndex) //vypusti instanci attackera 
    {
        Vector3 spawnPosition = new Vector3(attackingUnit[attackingUnitIndex].GetAttackerSpawnPosition().x, 1f, 0f);
        GameObject instanceUnit = (GameObject) Instantiate(attackingUnit[attackingUnitIndex].GetPrefab(), spawnPosition, Quaternion.identity);
        // Debug.Log("spawn position: " + spawnPosition);
    }

    private void PayForUnit(int index) //pay for unit price form attackingUnitSO
    {
        _resourcesValue -= attackingUnit[index].GetAttackerPrice();
    } 

    private bool HasEnoughResources(int index) //check if you have resources to buy unit
    {
        bool enoughResources;
        
        if(_resourcesValue >= attackingUnit[index].GetAttackerPrice())
        {
            enoughResources = true;
           _NotEnoughResourcesTXT.enabled = false;
        }
        else
        {
             enoughResources = false; 
            _NotEnoughResourcesTXT.enabled = true;
        }
        return enoughResources;
    }


}
