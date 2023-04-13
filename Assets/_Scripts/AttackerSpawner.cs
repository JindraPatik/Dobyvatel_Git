using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] AttackingUnitSO[] attackingUnit;
    int attackingUnitIndex;
    int attackingUnitsCount;
    PlayerController Player;
    private bool _isAvailable;
    private float _resourcesValue;

    private void Start() 
    {
    
    }

    private void Update() 
    {
        isAvailable(); //zjisti jestli je dostupna
        // _resourcesValue = Player.GetResourcesAvailable(); //zjistit proc NULL
    }


    public void DeployUnit(int attackingUnitIndex) //vypusti instanci attackera
    {
        //Debug.Log("Resources:" + Player.GetResourcesAvailable());
        if(_isAvailable)
        {
            Vector3 spawnPosition = new Vector3(attackingUnit[attackingUnitIndex].GetAttackerSpawnPosition().x, 1f, 0f);
            Instantiate(attackingUnit[attackingUnitIndex].GetPrefab(), spawnPosition, Quaternion.identity);
        }
        else
        {
            //Debug.Log("Malo zdroju");
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



    


}
