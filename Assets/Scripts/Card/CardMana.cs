using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using TMPro;

public class CardMana : MonoBehaviour{
    [SerializeField] TMP_Text _manaText;
    [SerializeField] float _timeBetweenChanges = 0.1f;

    public int TargetMana{
        set{
            _targetMana = value;
            StartCoroutine (IEChangeMana());
        }
    }
    public int Mana {
        get{
            return _mana;
        }
        set{
            _mana = value;
            _manaText.text = value.ToString();
        }
    }
    int _mana;
    int _targetMana = -2147483648;

    public void EndCoroutine(){
        if(_targetMana != -2147483648){
            StopAllCoroutines();
            Mana = _targetMana;
        }       
    }

    IEnumerator IEChangeMana(){
        while (_mana != _targetMana){
            if(_mana > _targetMana){
                Mana -= 1;
            }
            else if (_mana < _targetMana){
                Mana += 1;
            }
            yield return new WaitForSeconds(_timeBetweenChanges);
        }
    }
}
