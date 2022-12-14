using UnityEngine;


[RequireComponent(typeof(CardHealth))]
[RequireComponent(typeof(CardDamage))]
[RequireComponent(typeof(CardMana))]
public class Card : MonoBehaviour{
    public int Health { get{ return _cardHealth.Health; } set{ _cardHealth.Health = value; } }
    public int Damage { get{ return _cardDamage.Damage; } set{ _cardDamage.Damage = value; } }
    public int Mana { get{ return _cardMana.Mana; } set{ _cardMana.Mana = value; } }

    CardHealth _cardHealth;
    CardDamage _cardDamage;
    CardMana _cardMana;

    void Awake(){
        _cardHealth = GetComponent<CardHealth>();
        _cardDamage = GetComponent<CardDamage>();
        _cardMana = GetComponent<CardMana>();
    }
}
