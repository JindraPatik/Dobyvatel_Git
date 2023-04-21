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
    [SerializeField] private GameObject _unitGO;
    private UnitActions _unitActions;
    private PlayerSO.Faction _myfaction;
    private float _unitStrenght;    
    

    private void Awake() 
    {
        _unitActions = _unitGO.GetComponent<UnitActions>();
    }

    private void Start() 
    {
       
        _playerHealth = _playerSO.GetPlayerHealh();
        _unitStrenght = _unitActions._unit.GetAttackerStrenght();//nefunguje!!!
        Debug.Log("Unit damage tohle: " + _unitStrenght); //nefunguje!!!
    }
    
    // public float _resourcesValue = 0;

    void Update()
    {
        _PlayerHealthTXT.text = ((int)_playerHealth).ToString();
    }

    private void TakedamageFromUnit()
    {
        _playerHealth -= _unitStrenght;
        Debug.Log("Unit damage: " + _unitStrenght);

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
