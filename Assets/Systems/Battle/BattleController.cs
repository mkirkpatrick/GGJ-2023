using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BattleController : MonoBehaviour
{
    public static BattleController instance;

    private DeckController deckController;
    private PlayerController playerController;
    private Player player;
    
    public BattleView battleView;
    public HandView handView;

    public Enemy enemy;
    public Enemy[] enemyStages = new Enemy[5];

    private void Start()
    {
        // Freaking Melt Your Face
        MusicController.instance.PlaySong(MusicController.SongTitles.Beetle_Battle);

        instance = this;

        deckController = GameController.instance.deckController;
        playerController = GameController.instance.playerController;
        player = playerController.player;

        // Load Enemy
        int stageCount = 0;
        enemy = enemyStages[stageCount]; //needs to change to load in the specific enemy SO
        print("Node: " + stageCount);
        enemy.deck = deckController.GetEnemyDeck(enemy);
        deckController.Shuffle(true, enemy.deck);

        player.deck = deckController.GetNewDeck(playerController.player);
        deckController.Shuffle(true, player.deck);

        handView.CreateHand();
        handView.UpdateHandView(player.deck.hand);

        battleView.UpdateView(player, enemy);
        
    }

    public void PlayerTurn(Card _card, int _index)
    {
        enemy.isEnemyAction = false;
        _card.use(player, enemy);
        deckController.DiscardCard(_index, player.deck);

        CheckStatus();

        deckController.DrawUntilFull(player.deck);
        handView.UpdateHandView(player.deck.hand);
        battleView.UpdateView(player, enemy);
    }

    void EnemyTurn()
    {
        enemy.isEnemyAction = !enemy.isEnemyAction;
        Card enemyCard = deckController.GetEnemyMove(enemy.deck);
        enemyCard.use(player, enemy);

    }

    void CardTurn()
    {
        //For when deck is up, player is choosing card
    }

    void CheckStatus()
    {
        if(enemy.healthCurrent <= 0)
        {
            Victory();
        }
        else if(player.healthCurrent <= 0)
        {
            Defeat();
        }
    }

    void Victory()
    {
        SceneManager.LoadScene("Root Map");
    }

    void Defeat()
    {
        SceneManager.LoadScene("Game Over");
    }
}
