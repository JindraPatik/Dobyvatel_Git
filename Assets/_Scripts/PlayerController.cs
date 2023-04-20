using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerSO _playerSO;
    [SerializeField] private float _playerHealth; 
    [SerializeField] private TMP_Text _PlayerHealthTXT;
    [SerializeField] private GameObject _unit;
    private UnitActions _unitActions;
    private PlayerSO.Faction _myfaction;
    

    private void Awake() 
    {
        _unitActions = _unit.GetComponent<UnitActions>();
    }

    private void Start() 
    {
       
        Debug.Log(_unitActions.GetUnitStrenght()); 
        _playerHealth = _playerSO.GetPlayerHealh(); //tohle nefunguje!!!
       
    }
    
    // public float _resourcesValue = 0;

    void Update()
    {
        _PlayerHealthTXT.text = ((int)_playerHealth).ToString();
    }

    private void TakedamageFromUnit()
    {
        _playerHealth -= _unitActions.GetUnitStrenght();
        Debug.Log("Unit damage: " + _unitActions.GetUnitStrenght());

    }


    private string GetMyFactionString()
    {
        string _myfaction = _playerSO.GetFaction().ToString();
        return _myfaction;
    }

    private string GetUnitFactionString()
    {
        string _unitFaction = _unitActions.GetUnitFaction().ToString();
        return _unitFaction;
    }

    private void OnTriggerEnter(Collider other) 
    {
        
        if(other.gameObject.CompareTag("Unit"))
        {
            TakedamageFromUnit();
            Debug.Log("collision with base");
        }
        
    }




    
    

    
    
}
