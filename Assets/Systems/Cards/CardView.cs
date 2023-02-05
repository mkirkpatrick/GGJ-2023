using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardView : MonoBehaviour
{
    private BattleController battleController;
    public List<Sprite> frameSpriteList;

    public Card card;
    public int indexInHand;

    public Button cardButton;

    public TMP_Text cardName;
    public TMP_Text description;
    public Image image;
    public Image frame;

    private void Start()
    {
        battleController = BattleController.instance;
        cardButton.onClick.AddListener(() => CardClick());
    }

    public void UpdateCardView(int _index) {
        indexInHand = _index;
        cardName.text = card.cardName;
        description.text = card.cardDescription;
        image.sprite = card.cardImage;

        //frame.sprite = GetFrameSprite(card.cardType);
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

    public void CardClick() {
        battleController.PlayerTurn(card, indexInHand);
    }
}
