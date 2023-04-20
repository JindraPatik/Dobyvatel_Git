using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="PlayerSO", fileName = "Player")]
public class PlayerSO : ScriptableObject
{
[SerializeField] Faction faction;
[SerializeField] private float _playerHealth;


public float GetPlayerHealh()
{
    return _playerHealth;
}


public Faction GetFaction()
{
    return _faction;
}

public enum Faction {Heroes = 0, Enemies = 1} 
    private Faction _faction;


    
}