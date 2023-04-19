using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarvesterScript : MonoBehaviour
{
   private bool _isLoaded;
   private MeshRenderer myMeshRenderer;

   private void Start() 
   {
        myMeshRenderer = GetComponent<MeshRenderer>();
        UnLoadHarvester(); //on start unload Harvester
   }

   public void UnLoadHarvester()
   {
        _isLoaded = false;
        myMeshRenderer.material.SetColor("_Red", Color.red);
   }
   
   public void LoadHarvester()
   {
        _isLoaded = true;
        myMeshRenderer.material.SetColor("_Red", Color.green);
   } 

    public bool IsHarvesterLoaded()
    {
        return _isLoaded;
    }

}
