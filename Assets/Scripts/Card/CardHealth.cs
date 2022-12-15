
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using TMPro;

public class CardHealth : MonoBehaviour{
    [SerializeField] TMP_Text _healthText;
    [SerializeField] float _timeBetweenChanges = 0.1f;

    public int TargetHealth{
        set{
            _targetHealth = value;
            StartCoroutine (IEChangeHealth());
        }
    }

    public int Health {
        get{
            return _health;
        }
        set{
            if(value <= 0) {
                Death();
            }

            _health = value;
            _healthText.text = value.ToString();
        }
    }
    
    int _health ;
    int _targetHealth = -2147483648;

    public void EndCoroutine(){
        if(_targetHealth != -2147483648){
            StopAllCoroutines();
            Health = _targetHealth;
        }       
    }
    
    IEnumerator IEChangeHealth(){
        while (_health != _targetHealth){
            if(_health > _targetHealth){
                Health -= 1;
            }
            else if (_health < _targetHealth){
                Health += 1;
            }
            yield return new WaitForSeconds(_timeBetweenChanges);
        }
    }
    

    void Death(){
        GetComponentInParent<CardHolder>().RemoveCard(GetComponent<Card>());
        Destroy(gameObject);
    }
}   
