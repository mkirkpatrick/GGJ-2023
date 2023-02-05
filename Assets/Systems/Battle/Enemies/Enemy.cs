using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy Data", menuName = "ScriptableObjects/Enemy")]
[System.Serializable]
public class Enemy : ScriptableObject
{
    public string enemyName;
    public int healthCurrent;
    public int healthMax;
    public Sprite sprite;

    public List<Card> enemyMoves;
    public int bleedValue;
    public bool isEnemyAction;

    public Deck deck;

    public Enemy(){
        
    }
}
