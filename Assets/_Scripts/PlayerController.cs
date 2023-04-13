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

    private float _resourcesValue = 0;

    void Update() 
    {
        _PlayerHealthTXT.text = ((int)_playerHealth).ToString();
        Debug.Log("Resources v player Controlleru:" + _resourcesValue);
    }

    void FixedUpdate()
    {
        _ResourcesTXT.text = ((int)_resourcesValue).ToString();
        _resourcesValue += ResourcesIncreasedPerSecond * Time.fixedDeltaTime;
    }

    


    public float GetResourcesAvailable()
    {
        return _resourcesValue;
    }

    

    
    public enum Faction {Heroes = 0, Enemies = 1}
}
