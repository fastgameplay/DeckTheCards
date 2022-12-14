using UnityEngine;
using TMPro;

[RequireComponent(typeof(CardHealth))]
[RequireComponent(typeof(CardDamage))]
[RequireComponent(typeof(CardMana))]
[RequireComponent(typeof(CardMovement))]
public class Card : MonoBehaviour{
    public int Health { get{ return _cardHealth.Health; } set{ _cardHealth.TargetHealth = value; } }
    public int Damage { get{ return _cardDamage.Damage; } set{ _cardDamage.TargetDamage = value; } }
    public int Mana { get{ return _cardMana.Mana; } set{ _cardMana.TargetMana = value; } }

    public string Title{get {return _title.text;} set {_title.text = value;}}
    public string Description{get {return _description.text;} set {_description.text = value;}}

    [SerializeField] TMP_Text _title;
    [SerializeField] TMP_Text _description;

    CardHealth _cardHealth;
    CardDamage _cardDamage;
    CardMana _cardMana;
    CardMovement _cardMovement;

    void Awake(){
        _cardHealth = GetComponent<CardHealth>();
        _cardDamage = GetComponent<CardDamage>();
        _cardMana = GetComponent<CardMana>();
        _cardMovement = GetComponent<CardMovement>();
    }
    public void EndCoroutines(){
        _cardHealth.EndCoroutine();
        _cardDamage.EndCoroutine();
        _cardMana.EndCoroutine();
    }
    public void Move(float angle, bool isActive){
        _cardMovement.TargetAngle = angle;
        _cardMovement.IsActive = isActive;
    }


}
