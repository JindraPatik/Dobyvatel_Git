using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _playerHealth = 100; 
    [SerializeField] private TMP_Text _PlayerHealthTXT;
    [SerializeField] private TMP_Text _ResourcesTXT;
    [SerializeField] public float ResourcesIncreasedPerSecond;
    [SerializeField] private Faction _faction;

    public float _resourcesValue = 0;

    void Update() 
    {
        _PlayerHealthTXT.text = ((int)_playerHealth).ToString();
    }

    void FixedUpdate()
    {
        _resourcesValue += ResourcesIncreasedPerSecond * Time.fixedDeltaTime;
        _ResourcesTXT.text = ((int)_resourcesValue).ToString();
    }

    
    // public void PayUnit(float price)
    // {

    // }
    

    
    public enum Faction {Heroes = 0, Enemies = 1}
}
