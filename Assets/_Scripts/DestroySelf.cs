using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) //Znic krystal pri kolizi s Harvesterem
    {
        if(other.gameObject.TryGetComponent(out AttackingUnitActions AuA))
        {
            bool isLoaded = AuA.IsHarvesterLoaded();
            
            if(other.gameObject.tag == "Harvester" && isLoaded)
            {
                Destroy(this.gameObject); //nechce znicit instanci
                Debug.Log("destroy crystal" + this.gameObject);
            }
        }
    }
}
