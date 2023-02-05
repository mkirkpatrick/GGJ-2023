using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : MonoBehaviour
{
    private DeckController deckController;
    private PlayerController playerController;
    private Enemy enemy;
    public BattleView battleView;
    public HandView handView;

    private void Start()
    {
        deckController = GameController.instance.deckController;
        enemy = new Enemy();

        Deck currentDeck = deckController.GetNewDeck();
        deckController.Shuffle(false, currentDeck);

        //handView.cardSlots[0].card...

        // Load Player - health
        // Load Enemy

        //
    }

    void PlayerTurn()
    {

    }

    void EnemyTurn()
    {

    }

    void CardTurn()
    {
        //For when deck is up, player is choosing card
    }

    void Victory()
    {

    }

    void Defeat()
    {

    }
}
