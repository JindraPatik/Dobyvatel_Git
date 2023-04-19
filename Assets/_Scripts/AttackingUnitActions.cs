using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackingUnitActions : MonoBehaviour
{
    [SerializeField] public AttackingUnitSO _attackingUnit;
    Rigidbody _myRigidBody;
    private float _speed;
    public bool _harvesterIsLoaded = false;
    private AttackerSpawner attackerSpawner;
    
    
    void Start()
    {
        _myRigidBody = GetComponent<Rigidbody>();
        _speed = (_attackingUnit.GetAttackerMoveSpeed()); //take value of _speed from AttackingUnitSO
    }
    
    void Update()
    {
        Move(_speed); //constantly move x axis 
    }


    private void Move(float speed) //move x axis
    {
        _myRigidBody.velocity = new Vector3 (speed, 0f, 0f);
    }

    private void LoadHarvester()
    {
        _harvesterIsLoaded = true;
        
    }

    public void DeliverHarvest()
    {
        _harvesterIsLoaded = false;
        Debug.Log("DeliverHarvest");
    }

    public bool IsHarvesterLoaded()
    {
        return _harvesterIsLoaded;
    }

    public bool IsHarvester() 
    {
        return _attackingUnit.CanHarvest();

    }

    private void OnTriggerEnter(Collider other) //Harvester collision with crystal
    {
        AttackerSpawner attackerSpawner = other.gameObject.GetComponent<AttackerSpawner>();
        
        
        if (other.gameObject.tag == "Crystal" && IsHarvester() && !IsHarvesterLoaded()) //nefunguje isHarvesterLoaded
        {
            _speed = -_speed; //flip direction of unit x
            LoadHarvester();
            _harvesterIsLoaded = true; 
        }
        
    }

        // attackerSpawner.GetComponent<MeshRenderer>().material.SetColor("_color", Color.red); // zmen barvu nalozeneho
   
}


