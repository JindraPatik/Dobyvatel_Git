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
    [SerializeField] private TMP_Text _gameOver;
    [SerializeField] private GameObject _harvester;
    HarvesterScript _harvesterScript;
    private UnitActions _unitActions;
    private PlayerSO.Faction _myfaction;
    private float _unitStrenght;
    private float _harvesterStrenght;
    private bool _isDead;    
    private const string _unitTag = "Unit";
    private const string _harvesterTag = "Harvester"; 
    

    private void Awake() 
    {
        _unitActions = _unitGO.GetComponent<UnitActions>(); //initialize reference to UnitActions
        _harvesterScript = _harvester.GetComponent<HarvesterScript>();
    }

    private void Start() 
    {
        _isDead = false; //starting alive ;)
        _gameOver.enabled = false; //napis Game over vyply
        _playerHealth = _playerSO.GetPlayerHealh(); //load HP from _playerSO
        _unitStrenght = _unitActions._unit.GetAttackerStrenght(); //load unit strenght from UnitSO
    }

    void Update()
    {
        _PlayerHealthTXT.text = ((int)_playerHealth).ToString(); //show Player's HP
    }

    private void TakedamageFromUnit() //decrease Player Health on hit
    {
        if(_playerHealth > 0f)
        {
            _playerHealth -= _unitStrenght;
            Debug.Log(_playerHealth + " HP");
        }
       
        else
        {
            Die();
        }
    }

    private void TakedamageFromHarvester()
    {
        _harvesterStrenght = _harvesterScript._attackingUnit.GetAttackerStrenght();
        _playerHealth -= _harvesterStrenght;
        Debug.Log(_playerHealth + " HP");

    }

    private void Die() 
    {
        _isDead = true;
        _gameOver.enabled = true;
    }

    public bool isDead()
    {
        return _isDead;
    }

    private void OnTriggerEnter(Collider other) //Player(alive) collides with Unit
    {
        {
            if(other != null && other.gameObject.CompareTag(_unitTag)) 
            {
                TakedamageFromUnit();
                Destroy(other.gameObject);
            }
            else if(other.gameObject.CompareTag(_harvesterTag))
            {
                TakedamageFromHarvester();
                Destroy(other.gameObject);
            }

        }
        
    }




    
    

    
    
}
