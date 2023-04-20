using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField] PlayerSO _playerSO;
    [SerializeField] private float _playerHealth; 
    [SerializeField] private TMP_Text _PlayerHealthTXT;
    [SerializeField] private PlayerSO.Faction _myfaction;
    [SerializeField] GameObject _unit;

    private UnitActions _unitActions;
    AttackingUnitSO.Faction _unitFaction;

    private void Awake() 
    {
        _unitActions = _unit.GetComponent<UnitActions>();
    }

    private void Start() 
    {
        _unitFaction = _unitActions.GetUnitFaction();
        _playerHealth = _playerSO.GetPlayerHealh();
        _myfaction = _playerSO.GetFaction();


        Debug.Log(this.gameObject + " faction: " + _myfaction);
    }
    
    // public float _resourcesValue = 0;

    void Update()
    {
        _PlayerHealthTXT.text = ((int)_playerHealth).ToString();
    }



    
    

    
    
}
