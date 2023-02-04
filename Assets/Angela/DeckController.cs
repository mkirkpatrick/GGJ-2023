using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckController : MonoBehaviour
{
    public List<Card> allCards;
    public Deck currentDeck;

    // Start is called before the first frame update
    void Start()
    {
        currentDeck = GetNewDeck();
        Shuffle(false, currentDeck);
        DrawFullHand(currentDeck);
        DiscardCard(1, currentDeck);
        PrintDeck();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //fills deck with card data set
    public Deck GetNewDeck()
    {
        Deck temp = new Deck();
        for(var i=0; i<allCards.Count; i++){
            DeckAdd(allCards[i], temp);
        }
        PopulateDraw(temp);  
        return temp;
        //**need to add clan specific card based on players chosen clan**
    }

    public void PrintDeck(){
        Debug.Log("drawpile");
        foreach(Card c in currentDeck.drawPile){
            Debug.Log(c.cardName);
        }
        Debug.Log("hand");
        foreach(Card c in currentDeck.hand){
            Debug.Log(c.cardName);
        }
        Debug.Log("discard");
        foreach(Card c in currentDeck.discardPile){
            Debug.Log(c.cardName);
        }
    }

    //shuffles cards
    public void Shuffle(bool includeHand, Deck deck){
        List<Card> shuffledCards = new List<Card>();
        //adds in the cards in the hand if necessary
        if(includeHand){
            shuffledCards.AddRange(deck.hand);
        }
        shuffledCards.AddRange(deck.discardPile);
        shuffledCards.AddRange(deck.drawPile);
        //iterates through and shuffles the cards
        
        for(var i=0; i<shuffledCards.Count; i++){
            int rand = Random.Range(i, shuffledCards.Count);
            var temp = shuffledCards[i];
            shuffledCards[i] = shuffledCards[rand];
            shuffledCards[rand] = temp;
            
        }
        deck.drawPile = shuffledCards;
        deck.discardPile.Clear();
        if(includeHand){
            deck.hand.Clear();
            DrawFullHand(deck);
        }
    }

    //takes card from top of pile, removes and puts in the hand
    public Card DrawCard(Deck deck){
        Card c = deck.drawPile[0];
        Debug.Log("Drawing Card..." + c.cardName);
        deck.hand.Add(c);
        deck.drawPile.RemoveAt(0);
        return c;
    }

    //takes in index of which card was played, removes from hand and puts into discard
    public void DiscardCard(int i, Deck deck){
        deck.discardPile.Add(deck.hand[i]);
        deck.hand.RemoveAt(i);
    }

    //adds cards to deck
    public void DeckAdd(Card c, Deck deck){
        deck.deck.Add(c);
    }

    public void PopulateDraw(Deck deck){
        deck.drawPile = deck.deck;
    }

    public void DrawFullHand(Deck deck){
        for(var i=0; i<5; i++){
            DrawCard(deck);
        }
    }

}
