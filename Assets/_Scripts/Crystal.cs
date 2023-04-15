using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour
{
    [SerializeField] GameObject crystal;
    [SerializeField] float crystalSpawnIntervalMin;
    [SerializeField] float crystalSpawnIntervalMax;
    float crystalSpawnInterval = 1;
    [SerializeField] float _crystalValue;

    void Start() 
    {
        crystalSpawnInterval = UnityEngine.Random.Range(crystalSpawnIntervalMin, crystalSpawnIntervalMax);
        StartCoroutine(spawnCrystal(crystalSpawnInterval));
    }

    IEnumerator spawnCrystal(float crystalSpawnInterval)
    {
        //spawn crystal in random range x -25, 25 and time crystalSpawnTinterval;
        
        Debug.Log("Momentalni interval spawnu crystalu je: " + crystalSpawnInterval);
        Vector3 crystalSpawnLocation = new Vector3 (UnityEngine.Random.Range(-25f, 25f), 1f, 0f);
        yield return new WaitForSeconds(crystalSpawnInterval);      
        Instantiate(crystal, crystalSpawnLocation, Quaternion.identity);  
    }

    private void OnTriggerEnter(Collider other) //Znic krystal pri kolizi s Harvesterem
    {
        if(other.gameObject.tag == "Harvester")
        {
            Destroy(gameObject);
        }
    }


}