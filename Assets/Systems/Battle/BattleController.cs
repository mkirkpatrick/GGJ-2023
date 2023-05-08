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
    public Card playerCard;
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
        playerCard = _card;
        int prevPlayerHP = player.healthCurrent;
        int prevEnemyHP = enemy.healthCurrent;

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

        deckController.DrawUntilFull(player.deck);
        handView.UpdateHandView(player.deck.hand);
        
        audioSource.PlayOneShot(battleSounds[1]);

        //The ANIMATION ZONE ----------

        //Play animations
        if(_card.cardUserAnim != "Skip")
        {
            string playerAnimName = "Player_" + _card.cardUserAnim;
            playerView.ChangeAnimState(playerAnimName);
            yield return new WaitForSeconds(1f);
        }

        if (_card.effectValue > 0)
        {
            int textValue = 0;

            if (playerTurnCards.Count == 1)
                combatTextController.SpawnCombatText(playerView.transform, enemyView.transform, _card, true);
            else {
                if (_card.cardType == CardType.Attack) {
                    foreach (Card card in playerTurnCards)
                        textValue += card.effectValue + player.attackCharge;
                    combatTextController.SpawnDamageText(enemyView.transform, textValue);
                }
                else if (_card.cardType == CardType.Heal)
                {
                    foreach (Card card in playerTurnCards)
                        textValue += card.effectValue + player.healCharge;
                    combatTextController.SpawnHealText(playerView.transform, textValue);
                }
            }
        }

        //Reaction animation
        if (prevPlayerHP != player.healthCurrent || _card.cardType == CardType.Heal)
        {
            if (prevPlayerHP < player.healthCurrent || _card.cardType == CardType.Heal)
            {
                //Heal animation
                playerView.ChangeAnimState("Player_Heal1");
            }
            else
            {
                //Damage animation
                playerView.ChangeAnimState("Player_Damage1");
            }
        }
        if (prevEnemyHP != enemy.healthCurrent)
        {
            if (prevEnemyHP < enemy.healthCurrent)
            {
                //Heal animation
                enemyView.ChangeAnimState("Enemy_Heal1");
            }
            else
            {
                //Damage animation
                enemyView.ChangeAnimState("Enemy_Damage1");
            }
        }


        //Now leaving the ANIMATION ZONE ----------

        bool stopBattle = CheckBattleStatus();

        battleView.UpdateView(player, enemy);

        if (!stopBattle)
        {
            yield return new WaitForSeconds(1f);

            playerView.ChangeAnimState("Player_Idle");
            enemyView.ChangeAnimState("Enemy_Idle");

            StartCoroutine(EnemyTurnActivate());
        }
    }

    public IEnumerator EnemyTurnActivate()
    {
        int prevPlayerHP = player.healthCurrent;
        int prevEnemyHP = enemy.healthCurrent;

        enemy.isEnemyAction = !enemy.isEnemyAction;
        Card enemyCard = deckController.GetEnemyMove(enemy.deck);
        enemyCard.use(player, enemy);

        //The ANIMATION ZONE ----------

        if (enemyCard.cardUserAnim != "Skip")
        {
            string enemyAnimName = "Enemy_" + enemyCard.cardUserAnim;
            print(enemyAnimName);
            enemyView.ChangeAnimState(enemyAnimName);
            yield return new WaitForSeconds(1f);
        }

        //Reaction animation
        if (prevPlayerHP != player.healthCurrent || enemy.isEnemyAction == false)
        {
            if (prevPlayerHP < player.healthCurrent || enemyCard.cardType == CardType.Heal)
            {
                //Heal animation
                playerView.ChangeAnimState("Player_Heal1");
            }
            else if (prevPlayerHP > player.healthCurrent)
            {
                //Damage animation
                playerView.ChangeAnimState("Player_Damage1");
            }
        }
        if (prevEnemyHP != enemy.healthCurrent || enemy.isEnemyAction == true)
        {
            if (prevEnemyHP < enemy.healthCurrent || enemyCard.cardType == CardType.Heal)
            {
                //Heal animation
                enemyView.ChangeAnimState("Enemy_Heal1");
            }
            else if(prevEnemyHP > enemy.healthCurrent)
            {
                //Damage animation
                enemyView.ChangeAnimState("Enemy_Damage1");
            }
        }
        if(playerCard.cardName == "Reflect")
            combatTextController.SpawnCombatText(playerView.transform, enemyView.transform, enemyCard, false);
        else
            combatTextController.SpawnCombatText(enemyView.transform, playerView.transform, enemyCard, false);

        battleView.UpdateView(player, enemy);

        yield return new WaitForSeconds(1f);
        CheckBleedEffect();

        yield return new WaitForSeconds(1f);
        bool stopBattle = CheckBattleStatus();

        playerView.ChangeAnimState("Player_Idle");
        enemyView.ChangeAnimState("Enemy_Idle");

        if (!stopBattle)
        {
            NewTurn();
        }
    }

    void CheckBleedEffect() {
        if (enemy.bleedValue > 0)
        {
            enemy.healthCurrent -= enemy.bleedValue;
            enemy.healthCurrent = (int)Mathf.Clamp(enemy.healthCurrent, 0f, enemy.healthMax);
            combatTextController.SpawnDamageText(enemyView.transform, enemy.bleedValue);
        }

        if (player.bleedValue > 0)
        {
            player.healthCurrent -= player.bleedValue;
            player.healthCurrent = (int)Mathf.Clamp(player.healthCurrent, 0f, player.healthMax);
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
        MusicController.instance.StopMusic();
        soundEffectsController.PlaySound("Creature Death Groan Long");

        yield return new WaitForSeconds(1f);

        soundEffectsController.PlaySound("Victory");

        yield return new WaitForSeconds(2f);

        GameController.instance.crossFade.GetComponent<CrossfadeView>().FadeState("FadeOut");

        yield return new WaitForSeconds(1f);

        enemy.resetEnemy();

        playerController.CheckClanVictory(player.nodeLocation-1, deckController);

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
