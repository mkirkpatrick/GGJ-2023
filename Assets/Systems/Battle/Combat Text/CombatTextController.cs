using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatTextController : MonoBehaviour
{
    public CombatText combatTextPrefab;
    public List<Color> textColors;
    public float time = 1f;

    public void SpawnCombatText(Transform _origin, Transform _opponent, Card _card, bool _isPlayer) {
        int attack = 0;
        int heal = 0;
        if (_isPlayer) {
            attack = PlayerController.instance.player.attackCharge;
            heal = PlayerController.instance.player.healCharge;
        }
         
        if (_card.cardType == CardType.Attack)
        {
            int _textValue = _card.effectValue + attack;
            ShowText(_textValue.ToString(), _opponent, 0);
        }
        else if (_card.cardType == CardType.Heal) {
            int _textValue = _card.effectValue + heal;
            ShowText(_textValue.ToString(), _origin, 1);
        }
        else if (_card.cardType == CardType.Huma)
        {
            int _textValue = _card.effectValue;
            ShowText(_textValue.ToString(), _opponent, 0);
        }
        else if (_card.cardType == CardType.Mani)
        {
            ShowText("5", _opponent, 0);
            ShowText("5", _origin, 1);
        }
        else if (_card.cardType == CardType.Nihtee)
        {
            ShowText("Bleed", _opponent, 0);
        }
    }
    public void SpawnDamageText(Transform _target, int _damageValue)
    {
            ShowText(_damageValue.ToString(), _target, 0);
    }
    public void SpawnHealText(Transform _target, int _healValue)
    {
        ShowText(_healValue.ToString(), _target, 1);
    }

    void ShowText(string _value, Transform _target, int _colorIndex)
    {
        CombatText newText = Instantiate(combatTextPrefab, _target);
        RectTransform rect = newText.GetComponent<RectTransform>();
        rect.anchoredPosition = new Vector2( Random.Range(-15f, 15f), Random.Range(5f, 15f));
        newText.Initialize(_value, textColors[_colorIndex], time);
    }
}
