using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player
{
    public Clan currentClan;
    public int healthCurrent;
    public int healthMax;

    public int nodeLocation = 0;

    public int attackCharge;
    public int healCharge;
    public int bleedValue;

    public DeckController deckController;
    public Deck deck;
    public Enemy[] enemyStages;

    public AnimationClip[] battleAnimations;

    public Player() {
        healthCurrent = 30;
        healthMax = 30;

        ResetStats();

        enemyStages = new Enemy[5];
    }

    public void ResetStats() {
        attackCharge = 0;
        healCharge = 0;
        bleedValue = 0;
    }
}
