using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonCooldown : MonoBehaviour
{
    [SerializeField] Button _button; 
    [SerializeField] float _cooldownTime;

    public void StartCooldown()
        {
            _button.interactable = false;
            Invoke("EndCooldown", _cooldownTime);
        }
    
    private void EndCooldown()
        {
            _button.interactable = true;
        }


}
