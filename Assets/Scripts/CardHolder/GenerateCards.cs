using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CardHolder))]
public class GenerateCards : MonoBehaviour
{
    [SerializeField] Card _cardPrefab;
    [SerializeField] Vector2Int _cardCountRange;

    [SerializeField] float _height;
    [SerializeField] float _activeHeight;
    
    Vector3 _initialPosition{
        get{ return new Vector3(0,_height,0);}
    }
    CardHolder _holder;
    void Awake(){
        _holder = GetComponent<CardHolder>();
    }

    void Start(){
        int cardCount = Random.Range(_cardCountRange.x,_cardCountRange.y);
        for (int i = 0; i < cardCount; i++){
            Card currentCard = Instantiate(_cardPrefab, Vector3.zero, Quaternion.identity, transform);
            currentCard.transform.localPosition = _initialPosition;
            currentCard.GetComponent<CardMovement>().SetHeight(_height,_activeHeight);
            _holder.AddCard(currentCard);
        }
    }
}
