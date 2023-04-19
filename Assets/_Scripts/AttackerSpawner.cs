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
    AttackingUnitActions _attackingUnitActions;
    [SerializeField] Crystal _crystal;

    int attackingUnitIndex;
    int attackingUnitsCount;
    PlayerController Player;
    private bool _isAvailable;
    private float _resourcesValue;
    [SerializeField] public GameObject harvesterInstance;
    MeshRenderer _myMeshRenderer;
    AttackingUnitActions AuA;

    
    private void Start() 
    {
        _NotEnoughResourcesTXT.enabled = false;
        // AttackingUnitActions AuA = harvesterInstance.GetComponent<AttackingUnitActions>();
        _myMeshRenderer = GetComponent<MeshRenderer>();
    }

    void FixedUpdate()
    {
        _ResourcesTXT.text = ((int)_resourcesValue).ToString();
        _resourcesValue += ResourcesIncreasedPerSecond * Time.fixedDeltaTime;
    }

    private void Update() 
    {

    // if(AuA.IsHarvesterLoaded()) // test jestli je nalozenej
    //     {
    //         _myMeshRenderer.material.SetColor("_Red", Color.red);
    //     }
    //     else
    //     {
    //         _myMeshRenderer.material.SetColor("_Red", Color.green);
    //     }    
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
        GameObject harvesterInstance = (GameObject)Instantiate(attackingUnit[attackingUnitIndex].GetPrefab(), spawnPosition, Quaternion.identity);
        Debug.Log("spawn position: " + spawnPosition);
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

    private void OnTriggerEnter(Collider other) //collision with Base when harvester is loaded
    {
        if(other.gameObject.TryGetComponent(out AttackingUnitActions AuA))
        
        {
            if(other.gameObject.tag == "Harvester" && AuA.IsHarvesterLoaded())
            {
                _resourcesValue += _crystal.GetCrystalValue();
                Debug.Log(_crystal.GetCrystalValue() + " added to resources");
                AuA.DeliverHarvest();
                Destroy(other.gameObject); //Destroy Harvester
            }
        }
    }
        



}
