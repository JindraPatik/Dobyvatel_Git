// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class AttackingUnitActions : MonoBehaviour
// {
//     // [SerializeField] public AttackingUnitSO _attackingUnit;
//     // Rigidbody _myRigidBody;
//     // private float _speed;
    
    
    
// //     void Start()
// //     {
// //         _myRigidBody = GetComponent<Rigidbody>();
// //         _speed = (_attackingUnit.GetAttackerMoveSpeed()); //take value of _speed from AttackingUnitSO
        
// //     }

    
// //     void Update()
// //     {
// //         Move(_speed); //constantly move x axis 
// //     }

// //     private void Move(float speed) //move x axis
// //     {
// //         _myRigidBody.velocity = new Vector3 (speed, 0f, 0f);
// //     }


// //     public bool IsHarvester() 
// //     {
// //         return _attackingUnit.CanHarvest();
// //     }

// //     private void OnTriggerEnter(Collider other) //Harvester collision with crystal
// //     {
// //         if(other.gameObject.TryGetComponent(out HarvesterScript harvesterScript))
// //         {
// //             if (other.gameObject.tag == "Crystal" && IsHarvester() && !harvesterScript.IsHarvesterLoaded())
// //             {
// //                 Debug.Log("is loaded ve AuA " + harvesterScript.IsHarvesterLoaded());
                
// //                 _speed = -_speed; //flip direction of unit x
// //             }
            
// //         }

// //     }

   
// // }


