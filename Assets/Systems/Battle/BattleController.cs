using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BattleController : MonoBehaviour
{
    public static BattleController instance;
    public CombatTextController combatTextController;

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

        StartCoroutine(BattleIntro());

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

    public IEnumerator BattleIntro()
    {
        GameController.instance.crossFade.GetComponent<CrossfadeView>().FadeState("BattleFadeIn");
        SoundEffectsController.instance.PlaySound("Damage 2");
        yield return new WaitForSeconds(2f);
    }

    public IEnumerator PlayerTurnActivate(Card _card, int _index)
    {
        isPlayerTurn = false;
        enemy.isEnemyAction = false;
        int cardValue = 0;

        //checking for root combo and acting accordingly
        if (deckController.isInCombo(_index, player.deck)){
            //plays all of the combo cards 
            List<Card> comboList = deckController.getComboCards(player.deck);
            for(int i = 0; i < comboList.Count; i++){
                comboList[i].use(player, enemy);
                deckController.DiscardCard(0, player.deck);
            }

            soundEffectsController.PlaySound("Card Shuffle");
        } else {
            //just plays the single card
            _card.use(player, enemy);
            deckController.DiscardCard(_index, player.deck);

            soundEffectsController.PlaySound("Card Flap");
        }

        yield return new WaitForSeconds(0.5f);

        deckController.DrawUntilFull(player.deck);
        handView.UpdateHandView(player.deck.hand);
        
        audioSource.PlayOneShot(battleSounds[1]);
        
        switch(_card.cardType)
        {
            case CardType.Attack:
                playerView.ChangeAnimState(PlayerView.AnimState.Attacking);
                yield return new WaitForSeconds(1f);
                enemyView.ChangeAnimState(EnemyView.AnimState.Damaged);
                combatTextController.SpawnCombatText(playerView.transform, enemyView.transform, _card);
                break;
            case CardType.Heal:
                playerView.ChangeAnimState(PlayerView.AnimState.Healing);
                combatTextController.SpawnCombatText(playerView.transform, enemyView.transform, _card);
                break;
            case CardType.Utility: 
                playerView.ChangeAnimState(PlayerView.AnimState.Tactic);
                break;
            case CardType.Huma:
                playerView.ChangeAnimState(PlayerView.AnimState.Huma);
                yield return new WaitForSeconds(1f);
                enemyView.ChangeAnimState(EnemyView.AnimState.Damaged);
                combatTextController.SpawnCombatText(playerView.transform, enemyView.transform, _card);
                break;
            case CardType.Mani:
                break;
            case CardType.Nihtee:
                break;
        }

        CheckBattleStatus();

        battleView.UpdateView(player, enemy);

        yield return new WaitForSeconds(1f);

        StartCoroutine( EnemyTurnActivate() );
    }

    public IEnumerator EnemyTurnActivate()
    {
        enemy.isEnemyAction = !enemy.isEnemyAction;
        Card enemyCard = deckController.GetEnemyMove(enemy.deck);
        enemyCard.use(player, enemy);
        

        if(enemyCard.cardType == CardType.Attack)
        {
            enemyView.ChangeAnimState(EnemyView.AnimState.Attacking);
            yield return new WaitForSeconds(1f);
            playerView.ChangeAnimState(PlayerView.AnimState.Damaged);
            combatTextController.SpawnCombatText(enemyView.transform, playerView.transform, enemyCard);
        }
        else if (enemyCard.cardType == CardType.Heal)
            combatTextController.SpawnCombatText(enemyView.transform, playerView.transform, enemyCard);

        battleView.UpdateView(player, enemy);

        yield return new WaitForSeconds(1f);
        CheckBleedEffect();

        yield return new WaitForSeconds(1f);
        CheckBattleStatus();
        NewTurn();
    }

    void CheckBleedEffect() {
        if (enemy.bleedValue > 0)
        {
            enemy.healthCurrent -= enemy.bleedValue;
            combatTextController.SpawnCombatText(enemyView.transform, enemy.bleedValue);
        }

        if (player.bleedValue > 0)
        {
            player.healthCurrent -= player.bleedValue;
            combatTextController.SpawnCombatText(playerView.transform, player.bleedValue);
        }
        battleView.UpdateView(player, enemy);
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
