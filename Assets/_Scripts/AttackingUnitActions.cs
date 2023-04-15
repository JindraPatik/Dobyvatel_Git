using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackingUnitActions : MonoBehaviour
{
    [SerializeField] public AttackingUnitSO _attackingUnit;
    Rigidbody _myRigidBody;
    
    void Start()
    {
        _myRigidBody = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        MoveForward();
    }

    private void MoveForward()
    {
        float speed = _attackingUnit.GetAttackerMoveSpeed();
        _myRigidBody.velocity = new Vector3 (speed, 0f, 0f);
    }

       private void MoveBackward()
    {
        float speed = _attackingUnit.GetAttackerMoveSpeed();
        _myRigidBody.velocity = new Vector3 (-speed, 0f, 0f);
    }

    private void Harvest()
    {
        {
            _attackingUnit._harvesterLoaded = true;
            MoveBackward();
        }
    }

    private void DeliverHarvest()
    {
        _attackingUnit._harvesterLoaded = false; 
    }

    private bool IsHarvester()
    {
        return _attackingUnit.CanHarvest();
    }
}


