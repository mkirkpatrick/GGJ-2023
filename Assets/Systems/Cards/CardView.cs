using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardView : MonoBehaviour
{
    public List<Sprite> frameSpriteList;

    public Card card;

    public TMP_Text cardName;
    public TMP_Text description;
    public Image image;
    public Image frame;

    public void UpdateCardView() {
        cardName.text = card.cardName;
        description.text = card.cardDescription;
        image.sprite = card.cardImage;

       frame.sprite = GetFrameSprite(card.cardType);
    }

    private Sprite GetFrameSprite(CardType _type) {

        switch (_type)
        {
            case CardType.Attack:
                return frameSpriteList[0];
            case CardType.Huma:
                return frameSpriteList[1];
            case CardType.Mani:
                return frameSpriteList[2];
            case CardType.Nihtee:
                return frameSpriteList[3];
            case CardType.Heal:
                return frameSpriteList[4];
            case CardType.Utility:
                return frameSpriteList[5];
            default:
                return null;
        }
    }
}
