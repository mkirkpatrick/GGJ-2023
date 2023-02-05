using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HandView : MonoBehaviour
{
    public Transform handContainer;
    public CardView cardPrefab;
    public List<CardView> cardViews;

    private void Awake()
    {
        cardViews = new List<CardView>();
    }

    public void CreateHand() {
        for (int i = 0; i < 5; i++)
        {
            CardView newCard = Instantiate(cardPrefab);
            cardViews.Add(newCard);
            newCard.gameObject.transform.SetParent(handContainer);
        }
    }
    public void UpdateHandView(List<Card> _cards)
    {
        for (int i = 0; i < 5; i++)
        {
            cardViews[i].card = _cards[i];
            cardViews[i].UpdateCardView(i);
        }
    }

    public void SelectCard(int _index) {
        //cardSlots[_index].SetActive(false);

    }

    private void AdjustHand()
    {
        //for(int i = 0; i < cardSlots.Length; i++)
        {

        }
    }
}
