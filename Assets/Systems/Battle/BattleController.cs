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
    public PlayerView playerView;

    public Enemy enemy;

    public AudioSource audioSource;
    public AudioClip[] battleSounds;

    private void Start()
    {
        // Freaking Melt Your Face
        MusicController.instance.PlaySong(MusicController.SongTitles.Beetle_Battle);

        audioSource = GetComponent<AudioSource>();

        instance = this;

        deckController = GameController.instance.deckController;
        playerController = GameController.instance.playerController;
        player = playerController.player;

        // Load Enemy
        enemy = player.enemyStages[player.nodeLocation - 1]; //needs to change to load in the specific enemy SO
        enemy.deck = deckController.GetEnemyDeck(enemy);
        deckController.Shuffle(true, enemy.deck);

        //reset player stats 
        player.attackCharge = 0;
        player.healCharge = 0;
        player.bleedValue = 0;

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

        print(battleSounds[1]);
        audioSource.PlayOneShot(battleSounds[1]);



        /*
        if (_card.cardType == CardType.Attack)
        {
            battleView.enemyAnimator.Play("Player_Attack1");
            yield return new WaitForSeconds(1f);
            battleView.playerAnimator.Play("Enemy_Damage1");
            audioSource.PlayOneShot(battleSounds[0]);
            yield return new WaitForSeconds(1f);
            battleView.enemyAnimator.Play("Enemy_Idle");
            battleView.playerAnimator.Play("Player_Idle");
        }
        */
        playerView.ChangeAnimState(PlayerView.AnimState.Attacking);
        yield return new WaitForSeconds(1f);

        StartCoroutine( EnemyTurn() );
    }

    public IEnumerator EnemyTurn()
    {
        enemy.isEnemyAction = !enemy.isEnemyAction;
        Card enemyCard = deckController.GetEnemyMove(enemy.deck);
        enemyCard.use(player, enemy);
        battleView.UpdateView(player, enemy);

        /*
        if(enemyCard.cardType == CardType.Attack)
        {
            battleView.enemyAnimator.Play("Enemy_Attack1");
            yield return new WaitForSeconds(1f);
            battleView.playerAnimator.Play("Player_Damage1");
            audioSource.PlayOneShot(battleSounds[0]);
            yield return new WaitForSeconds(1f);
            battleView.enemyAnimator.Play("Enemy_Idle");
            battleView.playerAnimator.Play("Player_Idle");
        }
        */
        playerView.ChangeAnimState(PlayerView.AnimState.Damaged);
        yield return new WaitForSeconds(1f);

        enemy.healthCurrent -= enemy.bleedValue;
        player.healthCurrent -= player.bleedValue;
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
