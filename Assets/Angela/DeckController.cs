using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckController : MonoBehaviour
{
    public List<Card> allCards;
    public List<Card> clanCards;
    public Deck currentDeck;
    public int comboIndex;

    /*for debugging
    void Start()
    {
        currentDeck = GetNewDeck();
        Shuffle(false, currentDeck);
        DrawFullHand(currentDeck);
        DiscardCard(1, currentDeck);
        PrintDeck();
    }
    */

    //fills deck with card data set
    public Deck GetNewDeck(Player _player)
    {
        Deck temp = new Deck();
        for(var i = 0; i < allCards.Count; i++){
            DeckAdd(allCards[i], temp);
        }

        //adds player's clan card
        if(_player.currentClan.clanName.Equals("Huma")){
            DeckAdd(clanCards[0], temp);
        } else if (_player.currentClan.clanName.Equals("Mani")){
            DeckAdd(clanCards[1], temp);
        } else if (_player.currentClan.clanName.Equals("Nih-Tee")){
            DeckAdd(clanCards[2], temp);
        }

        PopulateDraw(temp);
        return temp;
    }

    public Deck GetEnemyDeck(Enemy e){
        Deck temp = new Deck();
        for(var i = 0; i<e.enemyMoves.Count; i++){
            DeckAdd(e.enemyMoves[i], temp);
        }
        PopulateDraw(temp);
        return temp;
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
        
        for(var i = 0; i < shuffledCards.Count; i++){
            int rand = Random.Range(i, shuffledCards.Count);
            var temp = shuffledCards[i];
            shuffledCards[i] = shuffledCards[rand];
            shuffledCards[rand] = temp;
            
        }
        deck.drawPile = shuffledCards;
        deck.discardPile.Clear();
        if(includeHand){
            deck.hand.Clear();
            DrawUntilFull(deck);
        }
    }

    //takes card from top of pile, removes and puts in the hand
    public Card DrawCard(Deck deck){
        if(deck.drawPile.Count <= 0){
            Shuffle(false, deck);
        }
        Card c = deck.drawPile[0];

        //debugging
        Debug.Log("Drawing Card..." + c.cardName);

        deck.hand.Add(c);
        deck.drawPile.RemoveAt(0);

        //if this is buggy just comment out, its for the root system
        updateComboIndex(deck);
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

    //run when encounter starting, it makes the draw pile = to deck
    public void PopulateDraw(Deck deck){
        deck.drawPile = deck.deck;
    }

    //good to call after a turn, will draw until hand has 5 cards in it
    public void DrawUntilFull(Deck deck){
        //if this doesn't work then switch to a while loop
        var num = 5-deck.hand.Count;
        for(var i=0; i<num; i++){
            DrawCard(deck);
        }
    }

    //calculates the range of the root combo (returns the furthest index)
    public void updateComboIndex(Deck deck){
        CardType c = deck.hand[0].cardType;
        bool isCombo = true;
        var index = 1;
        var comboIndex = 0;
        while((index<5) && isCombo){
            if(deck.hand[index].cardType.Equals(c)){
                index++;
                comboIndex = index;
            } else{
                isCombo = false;
            }
        }
        this.comboIndex = comboIndex;
    }

    public Card getEnemyMove(Deck enemyDeck){
        return enemyDeck.hand[Random.Range(0, 5)];
    }
}