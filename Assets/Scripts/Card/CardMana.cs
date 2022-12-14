using UnityEngine;
using TMPro;

public class CardMana : MonoBehaviour{
    [SerializeField] TMP_Text _manaText;
    public int Mana {
        get{
            return _mana;
        }
        set{
            _mana = value;
            _manaText.text = value.ToString();
        }
    }
    int _mana;

}
