using UnityEngine;
using TMPro;

public class CardDamage : MonoBehaviour
{
    [SerializeField] TMP_Text _damageText;
    public int Damage {
        get{
            return _damage;
        }
        set{
            _damage = value;
            _damageText.text = value.ToString();
        }
    }
    int _damage;
}
