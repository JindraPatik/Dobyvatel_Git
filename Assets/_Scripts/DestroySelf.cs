using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) //Znic krystal pri kolizi s Harvesterem
    {
        if(other.gameObject.tag == "Harvester")
        {
            Destroy(this.gameObject); //nechce znicit instanci
            Debug.Log("destroy crystal" + this.gameObject);
        }
    }
}
