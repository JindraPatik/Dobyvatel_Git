using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitActions : MonoBehaviour
{
public AttackingUnitSO _unit;
private float _myStrenght;
private float _speed;
Rigidbody _myRigidBody;
AttackingUnitSO.Faction _myFaction;
private const string _unitTag = "Unit";
private const string _harvesterTag = "Harvester";



private void Awake() 
{
    
}

private void Start() 
{
    _myRigidBody = GetComponent<Rigidbody>();
    _speed = (_unit.GetAttackerMoveSpeed()); //take value of _speed from AttackingUnitSO
    _myStrenght = _unit.GetAttackerStrenght();
    _myFaction = _unit.GetFaction();
}

private void Update() 
{
    Move(_speed); //constantly move x axis
}


private void Move(float speed) //move x axis
{
    _myRigidBody.velocity = new Vector3 (speed, 0f, 0f);
}


private void UnitDie() 
{
    Destroy(this.gameObject);
}

public AttackingUnitSO.Faction GetUnitFaction()
{
    return _myFaction;
}

public float GetUnitStrenght()
{
    return _myStrenght;
}

private void OnTriggerEnter(Collider other) 
{

    if(other.gameObject.TryGetComponent(out UnitActions unit))
    {
        if(_myFaction != unit.GetUnitFaction() && other.gameObject.CompareTag(_unitTag)) //pokud ma jednotka a utocnik jinou frakci
        
        {
            float attackerStrenght = unit.GetUnitStrenght();

            if(_myStrenght > attackerStrenght)
            {
                Destroy(other.gameObject);
                Debug.Log("Utocnik byl zabit!");
            }

            else if(_myStrenght < attackerStrenght)
            {
               UnitDie();
                Debug.Log("Moje jednotka byla zabita.");
            }

            else //remiza
            {
                UnitDie();
                Destroy(other.gameObject);
                Debug.Log("Jednotky se navzajem znicily.");
            }

        }
        
    }

}

}
