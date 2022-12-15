using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardHolder : MonoBehaviour
{
    public int Length{
        get {
            return _cards.Count;
        }
    }
    List<Card> _cards = new List<Card>();

    
    [SerializeField] float _maxAngle;

    float _halfAngle;
    float _stepAngle;

    void Awake(){
        _halfAngle = _maxAngle/2;
    }
    
    public void AddCard(Card card){
        _cards.Add(card);
        RecalculateCards();
    }
    public Card GetCard(int id){
        return _cards[id];
    }
    public void RemoveCard(Card card){
        _cards.Remove(card);
        RecalculateCards();
    }
    public void RecalculateCards(){

        _stepAngle = _maxAngle/ (_cards.Count +1);
        
        for (int i = 0; i < _cards.Count; i++){
            float angle = ((i + 1) * _stepAngle) - _halfAngle;
            _cards[i].Move(angle, false);
        }
    }

    public void SelectCard(int id){
        if(_cards.Count == 0) return;

        RecalculateCards();

        float angle = ((id + 1) * _stepAngle) - _halfAngle;
        _cards[id].Move(angle, true);
    }
}
