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

    private void Start()
    {
        // Freaking Melt Your Face
        MusicController.instance.PlaySong(MusicController.SongTitles.Beetle_Battle);

        instance = this;

        deckController = GameController.instance.deckController;
        playerController = GameController.instance.playerController;
        player = playerController.player;

        // Load Enemy
        enemy = player.enemyStages[player.nodeLocation - 1]; //needs to change to load in the specific enemy SO
        enemy.deck = deckController.GetEnemyDeck(enemy);
        deckController.Shuffle(true, enemy.deck);

        player.deck = deckController.GetNewDeck(playerController.player);
        deckController.Shuffle(true, player.deck);

        handView.CreateHand();
        handView.UpdateHandView(player.deck.hand);

        battleView.UpdateView(player, enemy);
        
    }

    public IEnumerator PlayerTurn(Card _card, int _index)
    {
        enemy.isEnemyAction = false;
        _card.use(player, enemy);
        deckController.DiscardCard(_index, player.deck);

        CheckStatus();

        deckController.DrawUntilFull(player.deck);
        handView.UpdateHandView(player.deck.hand);
        battleView.UpdateView(player, enemy);

        if(_card.cardType == CardType.Attack)
        {
            battleView.enemyAnimator.Play("Player_Attack1");
            yield return new WaitForSeconds(1f);
            battleView.playerAnimator.Play("Enemy_Damage1");
            yield return new WaitForSeconds(1f);
            battleView.enemyAnimator.Play("Enemy_Idle");
            battleView.playerAnimator.Play("Player_Idle");
        }

        StartCoroutine( EnemyTurn() );
    }

    public IEnumerator EnemyTurn()
    {
        enemy.isEnemyAction = !enemy.isEnemyAction;
        Card enemyCard = deckController.GetEnemyMove(enemy.deck);
        enemyCard.use(player, enemy);
        battleView.UpdateView(player, enemy);

        if(enemyCard.cardType == CardType.Attack)
        {
            battleView.enemyAnimator.Play("Enemy_Attack1");
            yield return new WaitForSeconds(1f);
            battleView.playerAnimator.Play("Player_Damage1");
            yield return new WaitForSeconds(1f);
            battleView.enemyAnimator.Play("Enemy_Idle");
            battleView.playerAnimator.Play("Player_Idle");
        }

        CheckStatus();
    }

    void CardTurn()
    {
        //For when deck is up, player is choosing card
    }

    void CheckStatus()
    {
        if(enemy.healthCurrent <= 0)
        {
            enemy.resetEnemy();
            Victory();
        }
        else if(player.healthCurrent <= 0)
        {
            enemy.resetEnemy();
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
