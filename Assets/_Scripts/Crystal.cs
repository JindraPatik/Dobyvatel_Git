using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour
{
    [SerializeField] private GameObject crystal;
    [SerializeField] float crystalSpawnIntervalMin;
    [SerializeField] float crystalSpawnIntervalMax;
    [SerializeField] float _crystalValue;
    [SerializeField] float _crystalSpawnRangeLeft;
    [SerializeField] float _crystalSpawnRangeRight;
    bool _spawnCrystals; 
    
    

    void Start() 
    {
        _spawnCrystals = true; //spawning crystals enabled

        StartCoroutine(spawnCrystal());
    }

    IEnumerator spawnCrystal()
    {
        while(_spawnCrystals)
        
        {
            float crystalSpawnInterval = UnityEngine.Random.Range(crystalSpawnIntervalMin, crystalSpawnIntervalMax);
            Debug.Log("Momentalni interval spawnu crystalu je: " + crystalSpawnInterval);
            Vector3 crystalSpawnLocation = new Vector3 (UnityEngine.Random.Range(_crystalSpawnRangeLeft, _crystalSpawnRangeRight), 1f, 0f);
            yield return new WaitForSeconds(crystalSpawnInterval);      
            GameObject _thisCrystal = (GameObject) Instantiate(crystal, crystalSpawnLocation, Quaternion.identity);  
        }
    }

    

    public float GetCrystalValue()
    {
        return _crystalValue;
    }


}