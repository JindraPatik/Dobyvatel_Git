using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    [SerializeField] AttackerSpawner _attackerSpawner;
    GameObject _instance;
    HarvesterScript _harvesterScript;
    

    private void Start() 
    {
       _attackerSpawner = GetComponent<AttackerSpawner>();
       _instance = _attackerSpawner.GetUnitInstance(_instance);
       _harvesterScript = _instance.GetComponent<HarvesterScript>();
    }
    
    private void OnTriggerEnter(Collider other) //Znic krystal pri kolizi s Harvesterem pokud neni nalozeny
    {

        if(other.gameObject.tag == "Harvester" && !_harvesterScript.IsHarvesterLoaded())
        {
            Destroy(this.gameObject); 
            Debug.Log("destroy crystal" + this.gameObject);
            Debug.Log("Is loaded v DestroySelf" + _harvesterScript.IsHarvesterLoaded());
        }
    }
}
