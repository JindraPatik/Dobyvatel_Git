using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour
{
      

    private void OnTriggerEnter(Collider other) //Znic krystal pri kolizi s Harvesterem pokud neni nalozeny
    {

        if(other.gameObject.tag == "Harvester")
        {
            Destroy(this.gameObject); 
            Debug.Log("destroy crystal" + this.gameObject);
        }
    }
}
