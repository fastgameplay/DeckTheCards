using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CardHolder))]
public class GenerateCards : MonoBehaviour
{
    [SerializeField] Card _cardPrefab;
    [SerializeField] Vector2Int _cardCountRange;
    CardHolder _holder;
    void Awake(){
        _holder = GetComponent<CardHolder>();
    }

    void Start(){
        int cardCount = Random.Range(_cardCountRange.x,_cardCountRange.y);
        for (int i = 0; i < cardCount; i++){
            _holder.AddCard(Instantiate(_cardPrefab,Vector3.zero,Quaternion.identity,transform));
        }
    }
}
