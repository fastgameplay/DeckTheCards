using UnityEngine;
using TMPro;

public class CardHealth : MonoBehaviour{
    [SerializeField] TMP_Text _healthText;

    public int Health {
        get{
            return _health;
        }
        set{
            if(value <= 0) Death();
            _health = value;
            _healthText.text = value.ToString();
        }
    }

    int _health;


    void Death(){
        Destroy(gameObject);
    }
}
