using System;
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
   [SerializeField] private float _moveUpHeight;
   UnitSpawner _unitSpawner;
   [SerializeField] GameObject _spawner;
   [SerializeField] private float _moveUpTimeSpeed;
   [SerializeField] private float _startTime;
   [SerializeField] private float _endTime;
   [SerializeField] private Vector3 _goalRotation;
   private bool _isMoving = true;
   private bool _isMovingUp = false;
   [SerializeField] AnimationCurve _curve;

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
          if(_isMoving)
          {
               Move(_speed); //constantly move x axis
          }

          else 
          {
               Move(0f);

                    if(_isMovingUp)
                    {
                         MoveUp();
                         RotateOneEighty();
                    }

          }          

          if(_startTime == _endTime)
          {
               StartHarvester();
               _isMovingUp = false;
          }

        
          Debug.Log("Is loaded: " + IsHarvesterLoaded());

          
   }
   

   public void UnLoadHarvester() 
   {
        _isLoaded = false;
     //    this.myMeshRenderer.material.SetColor("_Red", Color.red);
   }
   
   public void LoadHarvester()
   {
        _isLoaded = true;
     //    this.myMeshRenderer.material.SetColor("_Green", Color.green);
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


    private void FlipDirection()
    {
          _speed = -_speed;
    }


    private void StartHarvester()
    {
          _isMoving = true;
    }


    private void StopHarvester()
    {
          _isMoving = false;
    }

    private void EnableMoveUp()
    {
          _isMovingUp = true;
    }

    private void MoveUp()
    {
          Vector3 myPosition = _myRigidBody.transform.position;
          Vector3 desiredPosition = new Vector3(_myRigidBody.transform.position.x, _moveUpHeight, _myRigidBody.transform.position.z);
          _startTime = Mathf.MoveTowards(_startTime, _endTime, _moveUpTimeSpeed * Time.deltaTime);
          _myRigidBody.transform.position = Vector3.MoveTowards(myPosition, desiredPosition, _curve.Evaluate(_startTime));
    }

    private void RotateOneEighty()
    {
          transform.rotation = Quaternion.Lerp(Quaternion.Euler(Vector3.zero), Quaternion.Euler(_goalRotation), _curve.Evaluate(_startTime));
    }


    private void OnTriggerEnter(Collider other) 
    {
               if(other.gameObject.CompareTag(_crystalTag) && !IsHarvesterLoaded())
                    {
                         LoadHarvester();
                         Destroy(other.gameObject); //destroy crystal
                         StopHarvester();
                         EnableMoveUp();
                         FlipDirection(); //flip direction of unit x

                    }

               else if(other.gameObject.CompareTag(_spawnerTag) && IsHarvesterLoaded())
                              {
                                   UnLoadHarvester();
                                   Debug.Break();
                                   Destroy(this.gameObject, 1f);
                    }     

               else if(other.gameObject.CompareTag(_unit) && !IsHarvester()) //znici harvestera pri kolizi s jakoukoli jednotkou krom harvestera
                    {
                         Destroy(this.gameObject);
                    }
               
    }

}
