using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarvesterScript : MonoBehaviour
{
   [SerializeField] public AttackingUnitSO _attackingUnit;
   Rigidbody _myRigidBody;
   private float _speed;
   private bool _isLoaded;
   private MeshRenderer myMeshRenderer;
   private const string _crystalTag = "Crystal";
   private const string _spawnerTag = "Spawner";  
   private const string _unit = "Unit";
   UnitSpawner _unitSpawner;
   [SerializeField] GameObject _spawner;

   private void Awake() 
   {
          _unitSpawner = _spawner.GetComponent<UnitSpawner>();
   }

   private void Start() 
   {
        _myRigidBody = GetComponent<Rigidbody>();
        _speed = (_attackingUnit.GetAttackerMoveSpeed()); //take value of _speed from AttackingUnitSO
        myMeshRenderer = GetComponent<MeshRenderer>();
   }

   private void Update() 
   {
          Move(_speed); //constantly move x axis
   }

   public void UnLoadHarvester() 
   {
        _isLoaded = false;
        this.myMeshRenderer.material.SetColor("_Red", Color.red);
   }
   
   public void LoadHarvester()
   {
        
        _isLoaded = true;
        this.myMeshRenderer.material.SetColor("_Green", Color.green);
   } 

    public bool IsHarvesterLoaded()
    {
        return _isLoaded;
    }

    private void Move(float speed) //move x axis
    {
        _myRigidBody.velocity = new Vector3 (speed, 0f, 0f);
    }

    public bool IsHarvester() 
    {
        return _attackingUnit.CanHarvest();
    }

    private void OnTriggerEnter(Collider other) 
    {
               if(other.gameObject.CompareTag(_crystalTag) && !IsHarvesterLoaded())
                    {
                         LoadHarvester();
                         _speed = -_speed; //flip direction of unit x
                         Destroy(other.gameObject);
                    }
          
               else if(other.gameObject.CompareTag(_spawnerTag) && IsHarvesterLoaded())
                    {
                         UnLoadHarvester();
                         Destroy(this.gameObject, 1f);
                    }     

               else if(other.gameObject.CompareTag(_unit)) //znici harvestera pri kolizi s jakoukoli jednotkou
               {
                    Destroy(this.gameObject);
               }
          
    }

   

}
