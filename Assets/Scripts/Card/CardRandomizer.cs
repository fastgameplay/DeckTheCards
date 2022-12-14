using UnityEngine;
[RequireComponent(typeof(Card))]
public class CardRandomizer : MonoBehaviour
{
    [SerializeField] Vector2Int _damageRange; 
    [SerializeField] Vector2Int _healthRange;
    [SerializeField] Vector2Int _manaRange;

    Card _card;
    void Start(){
        _card = GetComponent<Card>();
        _card.Health = Random.Range(_healthRange.x,_healthRange.y);
        _card.Damage = Random.Range(_damageRange.x,_damageRange.y);
        _card.Mana = Random.Range(_manaRange.x,_manaRange.y);
    }

}
