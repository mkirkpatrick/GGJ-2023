using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class CardView : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
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
    public GameObject rootBorder;

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
        frame.sprite = GetFrameSprite(card.cardType);

        int comboIndex = PlayerController.instance.player.deck.comboIndex;


        if (_index <= comboIndex)
        {
            if (card.cardType == CardType.Attack || card.cardType == CardType.Heal)
            {
                ShowRootBorder(true);
            }
            else
            {
                ShowRootBorder(false);
            }
        } 
        else
        {
            ShowRootBorder(false);
        }
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

    public void ShowRootBorder(bool _showValue) { 
        rootBorder.SetActive(_showValue);
    }

    public void CardClick() {
        if(battleController.isPlayerTurn)
            StartCoroutine( battleController.PlayerTurnActivate(card, indexInHand) );
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        gameObject.transform.localScale = new Vector3(4, 4, 1);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        gameObject.transform.localScale = new Vector3(3, 3, 1);
    }
}
