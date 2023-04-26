using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarvesterScript : MonoBehaviour
{
   [SerializeField] public AttackingUnitSO _attackingUnit;
   Rigidbody _myRigidBody;
   private float _speed, _initialSpeed;
   private const float _stop = 0f;
   private bool _isLoaded;
   private MeshRenderer myMeshRenderer;
   private const string _crystalTag = "Crystal";
   private const string _spawnerTag = "Spawner";  
   private const string _unit = "Unit";
   private const string _harvesterTag = "Harvester";
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
        _initialSpeed = _speed;
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
                         Destroy(other.gameObject);

                         StopHarvester();
                         MoveUp();
                         StartHarvester();
                         FlipDirection(); //flip direction of unit x
                    }

        else if(other.gameObject.CompareTag(_spawnerTag) && IsHarvesterLoaded())
                    {
                         UnLoadHarvester();
                         Destroy(this.gameObject, 1f);
                    }     

               else if(other.gameObject.CompareTag(_unit) && !IsHarvester()) //znici harvestera pri kolizi s jakoukoli jednotkou krom harvestera
                    {
                         Destroy(this.gameObject);
                    }

               
               
    }

    private void FlipDirection()
    {
          _speed = -_speed;
    }

    private void StopHarvester()
    {
          _speed = _stop;
          Debug.Log("stop???" + _speed);
    }

    private void StartHarvester()
    {
          _speed = _initialSpeed;
    }

    private void MoveUp()
    {
          Vector3 myPosition = _myRigidBody.transform.position;
          Vector3 desiredPosition = myPosition + new Vector3(0f, 30f, 0f);
          myPosition = Vector3.MoveTowards(myPosition, desiredPosition, 3f);
    }


     

}
