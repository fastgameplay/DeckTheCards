using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardHolder : MonoBehaviour
{
    [SerializeField] float _height;
    [SerializeField] float _additionalHeight;
    [SerializeField] float _maxAngle;
    public int Length{get {return _cards.Count;}}

    List<Card> _cards = new List<Card>();
    float _halfAngle;
    float _stepAngle;

    void Awake(){
        _halfAngle = _maxAngle/2;
    }
    public void AddCard(Card card){
        _cards.Add(card);
        _stepAngle = _maxAngle/ (_cards.Count +1);
        RecalculateCards();
    }
    public Card GetCard(int id){
        return _cards[id];
    }

    public Vector3 CalculatePosition(float angle, float height){
        float x = height * Mathf.Sin(angle / Mathf.Rad2Deg);
        float y = height * Mathf.Cos(angle / Mathf.Rad2Deg);
        return new Vector3(x, y, 0);
    }


    public void RecalculateCards(){
        _cards.RemoveAll(s => s == null);

        for (int i = 0; i < _cards.Count; i++){
            float angle = ((i + 1) * _stepAngle) - _halfAngle;
            _cards[i].transform.localPosition = CalculatePosition(angle,_height);
            _cards[i].transform.localRotation = Quaternion.AngleAxis(angle, Vector3.back);
        }
    }

    public void MoveCardUp(int id){
        RecalculateCards();
        float angle = ((id + 1) * _stepAngle) - _halfAngle;
        _cards[id].transform.localPosition = CalculatePosition(angle,_height+_additionalHeight);
    }
}
