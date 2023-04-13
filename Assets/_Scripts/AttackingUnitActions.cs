using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackingUnitActions : MonoBehaviour
{
    [SerializeField] AttackingUnitSO _attackingUnit;
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
        
        Debug.Log(_myRigidBody.velocity.x);
    }
}
