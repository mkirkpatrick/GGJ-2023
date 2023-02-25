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
    private List<Card> playerTurnCards = new List<Card>();

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

        playerView.ChangeAnimState("Idle");

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

        //checking for root combo and acting accordingly
        if (deckController.isInCombo(_index, player.deck)){
            //plays all of the combo cards 
            List<Card> comboList = deckController.getComboCards(player.deck);
            for(int i = 0; i < comboList.Count; i++){
                comboList[i].use(player, enemy);
                playerTurnCards.Add(comboList[i]);
                deckController.DiscardCard(0, player.deck);
            }

            soundEffectsController.PlaySound("Card Shuffle");
        } else {
            //just plays the single card
            _card.use(player, enemy);
            playerTurnCards.Add(_card);
            deckController.DiscardCard(_index, player.deck);

            soundEffectsController.PlaySound("Card Flap");
        }

        //yield return new WaitForSeconds(0.5f); //pause for card sfx?

        deckController.DrawUntilFull(player.deck);
        handView.UpdateHandView(player.deck.hand);
        
        audioSource.PlayOneShot(battleSounds[1]);

        int textValue = 0;

        switch (_card.cardType)
        {
            case CardType.Attack:
                playerView.ChangeAnimState("Player_Attack1");
                yield return new WaitForSeconds(1f);
                enemyView.ChangeAnimState("Enemy_Damage1");
                foreach(Card card in playerTurnCards)
                    textValue += card.effectValue + player.attackCharge;
                combatTextController.SpawnDamageText(enemyView.transform, textValue);
                break;
            case CardType.Heal:
                playerView.ChangeAnimState("Player_Heal1");
                foreach (Card card in playerTurnCards)
                    textValue += card.effectValue + player.healCharge;
                combatTextController.SpawnHealText(playerView.transform, textValue);
                break;
            case CardType.Utility: 
                playerView.ChangeAnimState("Player_Tactic1");
                break;
            case CardType.Huma:
                playerView.ChangeAnimState("Player_HumaAttack");
                yield return new WaitForSeconds(1f);
                enemyView.ChangeAnimState("Enemy_Damage1");
                combatTextController.SpawnCombatText(playerView.transform, enemyView.transform, _card);
                break;
            case CardType.Mani:
                playerView.ChangeAnimState("Player_ManiAttack");
                yield return new WaitForSeconds(1.1f);
                enemyView.ChangeAnimState("Enemy_Damage1");
                combatTextController.SpawnCombatText(playerView.transform, enemyView.transform, _card);
                break;
            case CardType.Nihtee:
                combatTextController.SpawnCombatText(playerView.transform, enemyView.transform, _card);
                break;
        }

        bool stopBattle = CheckBattleStatus();

        battleView.UpdateView(player, enemy);

        if (!stopBattle)
        {
            yield return new WaitForSeconds(1f);

            StartCoroutine(EnemyTurnActivate());
        }
    }

    public IEnumerator EnemyTurnActivate()
    {
        enemy.isEnemyAction = !enemy.isEnemyAction;
        Card enemyCard = deckController.GetEnemyMove(enemy.deck);
        enemyCard.use(player, enemy);
        
        switch(enemyCard.cardType)
        {
            case CardType.Attack:
                enemyView.ChangeAnimState("Enemy_Attack1");
                yield return new WaitForSeconds(1f);
                playerView.ChangeAnimState("Player_Damage1");
                break;
            case CardType.Heal:
                enemyView.ChangeAnimState("Enemy_Heal1");
                yield return new WaitForSeconds(1f);
                break;
            case CardType.Utility:
                enemyView.ChangeAnimState("Enemy_Status1");
                yield return new WaitForSeconds(1f);
                break;
        }
        
        combatTextController.SpawnCombatText(enemyView.transform, playerView.transform, enemyCard);

        battleView.UpdateView(player, enemy);

        yield return new WaitForSeconds(1f);
        CheckBleedEffect();

        yield return new WaitForSeconds(1f);
        bool stopBattle = CheckBattleStatus();

        if(!stopBattle)
        {
            NewTurn();
        }
    }

    void CheckBleedEffect() {
        if (enemy.bleedValue > 0)
        {
            enemy.healthCurrent -= enemy.bleedValue;
            combatTextController.SpawnDamageText(enemyView.transform, enemy.bleedValue);
        }

        if (player.bleedValue > 0)
        {
            player.healthCurrent -= player.bleedValue;
            combatTextController.SpawnDamageText(playerView.transform, player.bleedValue);
        }
        battleView.UpdateView(player, enemy);
    }

    void NewTurn()
    {
        enemy.isEnemyAction = false;
        isPlayerTurn = true;
        playerTurnCards.Clear();
    }

    bool CheckBattleStatus()
    {
        if (enemy.healthCurrent <= 0)
        {
            StartCoroutine(Victory());
            return true;
        }
        else if (player.healthCurrent <= 0)
        {
            StartCoroutine(Defeat());
            return true;
        }
        else
        {
            return false;
        }
    }

    IEnumerator Victory()
    {
        enemyView.ChangeAnimState("Enemy_Death");

        yield return new WaitForSeconds(1f);

        soundEffectsController.PlaySound("Victory");

        yield return new WaitForSeconds(3f);

        GameController.instance.crossFade.GetComponent<CrossfadeView>().FadeState("FadeOut");

        yield return new WaitForSeconds(1f);

        enemy.resetEnemy();
        SceneManager.LoadScene("Root Map");
    }

    IEnumerator Defeat()
    {
        playerView.ChangeAnimState("Player_Death");

        yield return new WaitForSeconds(1f);

        GameController.instance.crossFade.GetComponent<CrossfadeView>().FadeState("FadeOut");

        yield return new WaitForSeconds(1f);

        enemy.resetEnemy();
        SceneManager.LoadScene("Game Over");
    }
}
