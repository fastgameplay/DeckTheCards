using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolderElementRandomizer : MonoBehaviour
{
    [SerializeField] CardHolder _cardHolder;
    [SerializeField] Vector2Int _randomRange;

    int additionalIndex{
        get{
            if(_cardHolder.Length < lastLength){
                lastLength = _cardHolder.Length;
                return 0;
            }
            lastLength = _cardHolder.Length;
            return 1;
        }
    }

    int currentID = -1;
    int lastLength = -1;
    public void RandomizeNext(){
        if(_cardHolder.Length == 0) return;

        currentID = (currentID + additionalIndex) % _cardHolder.Length;


        _cardHolder.SelectCard(currentID);

        Card card = _cardHolder.GetCard(currentID);
        card.transform.SetSiblingIndex(_cardHolder.Length);
        int value = Random.Range(_randomRange.x,_randomRange.y);

        switch(Random.Range(0,3)){
            case 0:
                card.Health = value;
                if(value <= 0) _cardHolder.RecalculateCards();
                break;
            case 1:
                card.Damage = value;
                break;
            case 2:
                card.Mana = value;
                break;
        }

    }
}
