using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : MonoBehaviour
{
    public static BattleController instance;

    private DeckController deckController;
    public Deck deck;
    private PlayerController playerController;
    private Player player;
    
    public BattleView battleView;
    public HandView handView;

    public Enemy enemy;

    private void Start()
    {
        // Freaking Melt Your Face
        MusicController.instance.PlaySong(MusicController.SongTitles.Beetle_Battle);

        instance = this;

        deckController = GameController.instance.deckController;
        playerController = GameController.instance.playerController;
        player = playerController.player;

        // Load Enemy

        deck = deckController.GetNewDeck(playerController.player);
        deckController.Shuffle(true, deck);

        handView.CreateHand();
        handView.UpdateHandView(deck.hand);

        battleView.UpdateView(player, enemy);
        
    }

    public void PlayerTurn(Card _card, int _index)
    {
        enemy.isEnemyAction = !enemy.isEnemyAction;
        _card.use(player, enemy);
        deckController.DiscardCard(_index, deck);
        deckController.DrawUntilFull(deck);
        handView.UpdateHandView(deck.hand);
        battleView.UpdateView(player, enemy);
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
