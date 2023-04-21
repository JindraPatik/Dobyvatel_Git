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
    private UnitActions _unitActions;
    private PlayerSO.Faction _myfaction;
    private float _unitStrenght;
    private bool _isDead;    
    

    private void Awake() 
    {
        _unitActions = _unitGO.GetComponent<UnitActions>(); //initialize reference to UnitActions
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
        _playerHealth -= _unitStrenght;
        Debug.Log(_playerHealth + " HP");
        // if(_playerHealth <= 0f)
        // {
        //     Die();
        // }
    }

    // private void Die() 
    // {
    //     Debug.Log(this.gameObject + "is DEAD. GAME OVER");
    //     Debug.Log(_playerHealth + " HP");
    //     _isDead = true;
    //     _gameOver.enabled = true;
    // }

    public bool isDead()
    {
        return _isDead;
    }

    private void OnTriggerEnter(Collider other) //Player(alive) collides with Unit
    {
        // while (!_isDead)
        {
            if(other != null && other.gameObject.CompareTag("Unit"))
            {
                TakedamageFromUnit();
                Destroy(other.gameObject);
            }

        }
        
    }




    
    

    
    
}
