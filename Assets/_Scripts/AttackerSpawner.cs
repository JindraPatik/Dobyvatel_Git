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
    [SerializeField] private TMP_Text _NotEnoughResourcesTXT;
    int attackingUnitIndex;
    int attackingUnitsCount;
    PlayerController Player;
    private bool _isAvailable;
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

    public void DeployUnit(int index)
    {
        if (HasEnoughResources(index))
        {
            PayForUnit(index);
            SpawnUnitForward(index);
        }
    }


    private void SpawnUnitForward(int attackingUnitIndex) //vypusti instanci attackera
    {
        isAvailable(); //zjisti jestli je dostupna
        // _resourcesValue = Player.GetResourcesAvailable(); //zjistit proc NULL
    }


    private void PayForUnit(int index)
    {
        _resourcesValue -= attackingUnit[index].GetAttackerPrice();
    } 

    private bool HasEnoughResources(int index)
    {
        //Debug.Log("Resources:" + Player.GetResourcesAvailable());
        if(_isAvailable)
        {
            enoughResources = true;
           _NotEnoughResourcesTXT.enabled = false;
        }
        else
        {
             enoughResources = false; 
            _NotEnoughResourcesTXT.enabled = true;
        }
    }

    public bool isAvailable()
    {
        if (attackingUnit[attackingUnitIndex].GetAttackerPrice() >= Player.GetResourcesAvailable()) //nefunguje GetResourcesAvailable
        {
            _isAvailable = true;
        }
        return _isAvailable;
    }

    //implementovat delivery Resources



}
