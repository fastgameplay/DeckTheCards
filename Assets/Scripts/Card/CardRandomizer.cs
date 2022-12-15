using UnityEngine;
[RequireComponent(typeof(CardHealth))]
[RequireComponent(typeof(CardDamage))]
[RequireComponent(typeof(CardMana))]
public class CardRandomizer : MonoBehaviour
{
    [SerializeField] Vector2Int _damageRange; 
    [SerializeField] Vector2Int _healthRange;
    [SerializeField] Vector2Int _manaRange;

    void Start(){
        GetComponent<CardHealth>().Health = Random.Range(_healthRange.x,_healthRange.y);
        GetComponent<CardDamage>().Damage = Random.Range(_damageRange.x,_damageRange.y);
        GetComponent<CardMana>().Mana = Random.Range(_manaRange.x,_manaRange.y);
    }

}
