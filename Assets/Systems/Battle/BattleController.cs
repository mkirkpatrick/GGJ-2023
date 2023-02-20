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
    private SoundEffectsController soundEffectsController;
    
    public BattleView battleView;
    public HandView handView;
    public PlayerView playerView;
    public EnemyView enemyView;

    public Enemy enemy;

    public bool isPlayerTurn = false;

    //TODO: Pull sound effects out to SoundEffectController and add reference
    public AudioSource audioSource;
    public AudioClip[] battleSounds;

    private void Start()
    {
        //Get References
        instance = this;
        deckController = GameController.instance.deckController;
        playerController = GameController.instance.playerController;
        soundEffectsController = SoundEffectsController.instance;

        // Freaking Melt Your Face
        MusicController.instance.PlaySong(MusicController.SongTitles.Beetle_Battle);

        audioSource = GetComponent<AudioSource>();

        LoadBattleScene();

        handView.CreateHand();
        handView.UpdateHandView(player.deck.hand);

        battleView.UpdateView(player, enemy);
        
    }

    private void LoadBattleScene() {
        // Load Player
        player = playerController.player;
        player.ResetStats();

        player.deck = deckController.GetNewDeck(playerController.player);
        deckController.Shuffle(true, player.deck);

        playerView.ChangeAnimState(PlayerView.AnimState.Idle);

        // Load Enemy
        enemy = player.enemyStages[player.nodeLocation - 1]; //needs to change to load in the specific enemy SO
        enemy.deck = deckController.GetEnemyDeck(enemy);
        deckController.Shuffle(true, enemy.deck);

        //Initialize first round
        isPlayerTurn = true;
    }

    public IEnumerator PlayerTurnActivate(Card _card, int _index)
    {
        isPlayerTurn = false;
        enemy.isEnemyAction = false;

        //checking for root combo and acting accordingly
        if (deckController.isInCombo(_index, player.deck)){
            //plays all of the combo cards 
            List<Card> comboList = deckController.getComboCards(player.deck);
            for(int i = 0; i < comboList.Count; i++){
                comboList[0].use(player, enemy);
                deckController.DiscardCard(0, player.deck);
            }
        } else {
            //just plays the single card
            _card.use(player, enemy);
            deckController.DiscardCard(_index, player.deck);
        }

        CheckBattleStatus();

        deckController.DrawUntilFull(player.deck);
        handView.UpdateHandView(player.deck.hand);
        battleView.UpdateView(player, enemy);

        audioSource.PlayOneShot(battleSounds[1]);
        
        if (_card.cardType == CardType.Attack)
        {
            playerView.ChangeAnimState(PlayerView.AnimState.Attacking);
            yield return new WaitForSeconds(1f);
            enemyView.ChangeAnimState(EnemyView.AnimState.Damaged);
            yield return new WaitForSeconds(1f);
        }
        else if(_card.cardType == CardType.Heal)
        {
            playerView.ChangeAnimState(PlayerView.AnimState.Healing);
            yield return new WaitForSeconds(1f);
        }
        else if(_card.cardType == CardType.Utility)
        {
            playerView.ChangeAnimState(PlayerView.AnimState.Tactic);
            yield return new WaitForSeconds(1f);
        }


        yield return new WaitForSeconds(1f);

        StartCoroutine( EnemyTurnActivate() );
    }

    public IEnumerator EnemyTurnActivate()
    {
        enemy.isEnemyAction = !enemy.isEnemyAction;
        Card enemyCard = deckController.GetEnemyMove(enemy.deck);
        enemyCard.use(player, enemy);
        battleView.UpdateView(player, enemy);

        if(enemyCard.cardType == CardType.Attack)
        {
            enemyView.ChangeAnimState(EnemyView.AnimState.Attacking);
            yield return new WaitForSeconds(1f);
            playerView.ChangeAnimState(PlayerView.AnimState.Damaged);
            yield return new WaitForSeconds(1f);
        }

        enemy.healthCurrent -= enemy.bleedValue;
        player.healthCurrent -= player.bleedValue;
        CheckBattleStatus();
        NewTurn();
    }

    void NewTurn()
    {
        enemy.isEnemyAction = false;
        isPlayerTurn = true;
    }

    void CheckBattleStatus()
    {
        if (enemy.healthCurrent <= 0)
        {
            enemy.resetEnemy();
            Victory();
        }
        else if (player.healthCurrent <= 0)
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
