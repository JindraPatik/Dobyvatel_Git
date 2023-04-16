using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackingUnitActions : MonoBehaviour
{
    [SerializeField] public AttackingUnitSO _attackingUnit;
    Rigidbody _myRigidBody;
    private float _speed;
    private bool _harvesterIsLoaded;
    
    
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

    public bool IsHarvesterLoaded()
    {
        return _harvesterIsLoaded;
    }

    public void DeliverHarvest()
    {
        _harvesterIsLoaded = false;
        // Destroy(gameObject);
        Debug.Log("Harvester destroyed!!!");
    }

    public bool IsHarvester() 
    {
        return _attackingUnit.CanHarvest();
    }

    private void OnTriggerEnter(Collider other) 
    {
        
        if (other.gameObject.tag == "Crystal" && IsHarvester() && !_harvesterIsLoaded)
        {
            _speed = -_speed; //flip direction of unit x
            LoadHarvester(); 
            Debug.Log("kolize s crystalem");
        }
        
    }

   
}


