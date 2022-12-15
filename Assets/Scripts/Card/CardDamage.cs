using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using TMPro;

public class CardDamage : MonoBehaviour
{
    [SerializeField] TMP_Text _damageText;
    [SerializeField] float _timeBetweenChanges = 0.1f;
    public int TargetDamage{
        set{
            _targetDamage = value;
            StartCoroutine (IEChangeDamage());
        }
    }
    public int Damage {
        get{
            return _damage;
        }
        set{
            _damage = value;
            _damageText.text = value.ToString();
        }
    }
    int _damage;
    int _targetDamage = -2147483648;

    public void EndCoroutine(){
        if(_targetDamage != -2147483648){
            StopAllCoroutines();
            Damage = _targetDamage;
        }       
    }

    IEnumerator IEChangeDamage(){
        while (_damage != _targetDamage){
            if(_damage > _targetDamage){
                Damage -= 1;
            }
            else if (_damage < _targetDamage){
                Damage += 1;
            }
            yield return new WaitForSeconds(_timeBetweenChanges);
        }
    }
}
