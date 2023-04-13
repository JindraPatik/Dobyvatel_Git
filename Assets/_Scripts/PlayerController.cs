using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _playerHealth = 100; 
    [SerializeField] private TMP_Text _PlayerHealthTXT;
    [SerializeField] private Faction _faction;

    
    void Update() 
    {
        _PlayerHealthTXT.text = ((int)_playerHealth).ToString();
    }
    
    public enum Faction {Heroes = 0, Enemies = 1}
}
