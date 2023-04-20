using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Attacking Unit", fileName = "AttackingUnit")]
public class AttackingUnitSO : ScriptableObject
{
    [SerializeField] GameObject _prefab;
    [SerializeField] GameObject _spawnPoint;
    [SerializeField] float _attackerMoveSpeed;
    [SerializeField] private float _strenght;
    [SerializeField] private int _price;
    [SerializeField] public bool SpawnAvailable;
    [SerializeField] private bool _canHarvest;
    [SerializeField] Faction faction;
    
     public GameObject GetPrefab()
     {
               return _prefab;
     }

     public float GetAttackerMoveSpeed()
     {
          return _attackerMoveSpeed;
     }
     
     
     public float GetAttackerStrenght()
     {
          return _strenght;
     }

     public int GetAttackerPrice()
     {
          return _price;
     }

     public Vector3 GetAttackerSpawnPosition()
     {
          Vector3 attackerSpawnPosition = new Vector3 (_spawnPoint.transform.position.x, 0f, 0f);
          return attackerSpawnPosition;
     }

     public bool CanHarvest()
     {
          return _canHarvest;
     }

     public enum Faction {Heroes = 0, Enemies = 1} 
     private Faction _faction;

     public Faction GetFaction()
     {
          return _faction;
     }



}
